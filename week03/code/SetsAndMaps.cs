using System.ComponentModel;
using System.Text.Json;

public static class SetsAndMaps
{
    /// <summary>
    /// The words parameter contains a list of two character 
    /// words (lower case, no duplicates). Using sets, find an O(n) 
    /// solution for returning all symmetric pairs of words.  
    ///
    /// For example, if words was: [am, at, ma, if, fi], we would return :
    ///
    /// ["am & ma", "if & fi"]
    ///
    /// The order of the array does not matter, nor does the order of the specific words in each string in the array.
    /// at would not be returned because ta is not in the list of words.
    ///
    /// As a special case, if the letters are the same (example: 'aa') then
    /// it would not match anything else (remember the assumption above
    /// that there were no duplicates) and therefore should not be returned.
    /// </summary>
    /// <param name="words">An array of 2-character words (lowercase, no duplicates)</param>
    public static string[] FindPairs(string[] words)
    {
        // TODO Problem 1 - ADD YOUR CODE HERE
        var set = new HashSet<string>(words);
        List<string> pairs = new List<string>();

        foreach (var word in words) {   
            // reverse the word
            char [] wordReversed = word.ToCharArray();
            Array.Reverse(wordReversed);
            string reversed = new string(wordReversed);
            
            // check if the reversed word is in the set
            // and the word is not the same as the reversed word
            if (set.Contains(reversed) && word != reversed) {
                pairs.Add(word + " & " + reversed);

                // remove the words from the set to avoid duplicates
                set.Remove(word);
                set.Remove(reversed); 
            }
            
        }
        return pairs.ToArray();
    }

    /// <summary>
    /// Read a census file and summarize the degrees (education)
    /// earned by those contained in the file.  The summary
    /// should be stored in a dictionary where the key is the
    /// degree earned and the value is the number of people that 
    /// have earned that degree.  The degree information is in
    /// the 4th column of the file.  There is no header row in the
    /// file.
    /// </summary>
    /// <param name="filename">The name of the file to read</param>
    /// <returns>fixed array of divisors</returns>
    public static Dictionary<string, int> SummarizeDegrees(string filename)
    {
        var degrees = new Dictionary<string, int>();
        foreach (var line in File.ReadLines(filename))
        {
            var fields = line.Split(",");
            // TODO Problem 2 - ADD YOUR CODE HERE
            var degree = fields[3];
            var count = 1;

            if (degrees.ContainsKey(degree)) {
                degrees[degree] += count;
            } else {
                degrees[degree] = count;
            }
        }
        return degrees;
    }

    /// <summary>
    /// Determine if 'word1' and 'word2' are anagrams.  An anagram
    /// is when the same letters in a word are re-organized into a 
    /// new word.  A dictionary is used to solve the problem.
    /// 
    /// Examples:
    /// is_anagram("CAT","ACT") would return true
    /// is_anagram("DOG","GOOD") would return false because GOOD has 2 O's
    /// 
    /// Important Note: When determining if two words are anagrams, you
    /// should ignore any spaces.  You should also ignore cases.  For 
    /// example, 'Ab' and 'Ba' should be considered anagrams
    /// 
    /// Reminder: You can access a letter by index in a string by 
    /// using the [] notation.
    /// </summary>
    public static bool IsAnagram(string word1, string word2)
    {
        // TODO Problem 3 - ADD YOUR CODE HERE
        // remove spaces from the words
        string word1NoSpace = word1.Replace(" ", "");
        string word2NoSpace = word2.Replace(" ", "");

        // check if the words have the same length
        if (word1NoSpace.Length == word2NoSpace.Length) {
            var dictionary1 = new Dictionary<char, int>();
            var dictionary2 = new Dictionary<char, int>();

            // count the frequency of each letter in the word
            // and store it in a dictionary
            // use to lower to ignore cases
            foreach (var letter in word1NoSpace.ToLower()) {
                if (dictionary1.ContainsKey(letter)) {
                    dictionary1[letter] += 1;
                } else {
                    dictionary1[letter] = 1;
                }
            }

            // count the frequency of each letter in the word
            // and store it in a dictionary
            // use to lower to ignore cases
            foreach (var letter in word2NoSpace.ToLower()) {
                if (dictionary2.ContainsKey(letter)) {
                    dictionary2[letter] += 1;
                } else {
                    dictionary2[letter] = 1;
                }
            }
            
            // check if the dictionaries are equal
            return dictionary1.OrderBy(x => x.Key).SequenceEqual(dictionary2.OrderBy(x => x.Key));
        } else {
            return false;
        }
    }

    /// <summary>
    /// This function will read JSON (Javascript Object Notation) data from the 
    /// United States Geological Service (USGS) consisting of earthquake data.
    /// The data will include all earthquakes in the current day.
    /// 
    /// JSON data is organized into a dictionary. After reading the data using
    /// the built-in HTTP client library, this function will return a list of all
    /// earthquake locations ('place' attribute) and magnitudes ('mag' attribute).
    /// Additional information about the format of the JSON data can be found 
    /// at this website:  
    /// 
    /// https://earthquake.usgs.gov/earthquakes/feed/v1.0/geojson.php
    /// 
    /// </summary>
    public static string[] EarthquakeDailySummary()
    {
        const string uri = "https://earthquake.usgs.gov/earthquakes/feed/v1.0/summary/all_day.geojson";
        using var client = new HttpClient();
        using var getRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);
        using var jsonStream = client.Send(getRequestMessage).Content.ReadAsStream();
        using var reader = new StreamReader(jsonStream);
        var json = reader.ReadToEnd();
        var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };

        var featureCollection = JsonSerializer.Deserialize<FeatureCollection>(json, options);

        // TODO Problem 5:
        // 1. Add code in FeatureCollection.cs to describe the JSON using classes and properties 
        // on those classes so that the call to Deserialize above works properly.
        // 2. Add code below to create a string out each place a earthquake has happened today and its magnitude.
        List<string> results = new List<string>();
        foreach (var feature in featureCollection.features)
        {
            string result = $"{feature.properties.place} - Mag {feature.properties.mag}";
            results.Add(result);
        }
        // 3. Return an array of these string descriptions.
        return results.ToArray();
    }
}
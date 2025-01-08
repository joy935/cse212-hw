public static class Arrays
{
    /// <summary>
    /// This function will produce an array of size 'length' starting with 'number' followed by multiples of 'number'.  For 
    /// example, MultiplesOf(7, 5) will result in: {7, 14, 21, 28, 35}.  Assume that length is a positive
    /// integer greater than 0.
    /// </summary>
    /// <returns>array of doubles that are the multiples of the supplied number</returns>
    public static double[] MultiplesOf(double number, int length)
    {
        // TODO Problem 1 Start
        // Remember: Using comments in your program, write down your process for solving this problem
        // step by step before you write the code. The plan should be clear enough that it could
        // be implemented by another person.

        // create an array of doubles with the length specified
        double [] result = new double[length]; 

        // loop through the array to calculate the multiples of the number
        for (int i = 0; i < length; i++)
        { 
            // add the next multiple of the number to the array
            result[i] = number * (i + 1);
        }

        // return the array of multiples
        return result; // replace this return statement with your own
    }

    /// <summary>
    /// Rotate the 'data' to the right by the 'amount'.  For example, if the data is 
    /// List<int>{1, 2, 3, 4, 5, 6, 7, 8, 9} and an amount is 3 then the list after the function runs should be 
    /// List<int>{7, 8, 9, 1, 2, 3, 4, 5, 6}.  The value of amount will be in the range of 1 to data.Count, inclusive.
    ///
    /// Because a list is dynamic, this function will modify the existing data list rather than returning a new list.
    /// </summary>
    public static void RotateListRight(List<int> data, int amount)
    {
        // TODO Problem 2 Start
        // Remember: Using comments in your program, write down your process for solving this problem
        // step by step before you write the code. The plan should be clear enough that it could
        // be implemented by another person.

        // verify that the amount is within the range of 1 to data.Count
        amount = amount % data.Count;

        // create a temporary list to store the rotated values
        List<int> tempList = new List<int>();

        // add the values that will be rotated to the temporary list
        tempList.AddRange(data.GetRange(data.Count - amount, amount));

        // add the rest of the values to the temporary list
        tempList.AddRange(data.GetRange(0, data.Count - amount));
        
        // loop through the data list to update the values
        for (int i = 0; i < data.Count; i++)
        {
            // update the values in the data list
            data[i] = tempList[i];
        }
    }
}

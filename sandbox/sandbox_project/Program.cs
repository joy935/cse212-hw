using System;

// public class Program
// {
//     static void Main(string[] args)
//     {
//         // This project is here for you to use as a "Sandbox" to play around
//         // with any code or ideas you have that do not directly apply to
//         // one of your projects.

//         Console.WriteLine("Hello Sandbox World!");
//     }
// }

//-----------------------------------
// Week 3 Interview Question testing
//-----------------------------------

// 1. Intersection of Two Sets
// Describe how you would write a function to find the intersection of two sets. 
// Your solution should NOT use the built-in intersection method.
// Highlight the time complexity of your solution
// Highlight the at least 3 test cases
var set1 = new HashSet<int> { 1, 2, 3, 4, 5 };
var set2 = new HashSet<int> { 3, 5, 6, 4 };
var intersection = new HashSet<int>();

foreach (var item in set1) { // O(n) operation so linear time, depends on the number of elements in the set
    if (set2.Contains(item)) { // O(1) operation so constant time
        intersection.Add(item); // O(1) operation so constant time
    }
} 
Console.WriteLine(string.Join(", ", intersection)); // 3, 4, 5

// test 1: sets with one element in common
// test 2: sets with all elements in common
// test 3: sets with no intersection
// test 4: sets with no elements

// 2. Union of Two Sets
// Describe how you would write a function to find the union of two sets.
// Your solution should NOT use the built-in union method.
// Highlight the time complexity of your solution
// Highlight the at least 3 test cases
var set3 = new HashSet<int> { 1, 2, 3, 4, 5 };
var set4 = new HashSet<int> { 3, 5, 6, 4 };
var union = new HashSet<int>(set3); // O(n) operation so linear time, depends on the number of elements in the set

foreach (var item in set4) { // O(n) operation so linear time, depends on the number of elements in the set
    if (!union.Contains(item)) { // O(1) operation so constant time
        union.Add(item); // O(1) operation so constant time
    }
}
Console.WriteLine(string.Join(", ", union)); // 1, 2, 3, 4, 5, 6

// test 1: sets with two identical sets
// test 2: sets with no elements in common
// test 3: sets with no elements

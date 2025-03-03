using System.Globalization;

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
        //
        /*
            Plan to solve the MultiplesOf problem

            Steps to find the multiples:
                    1- Create a list variable to store the multiples, 
                    a choice made given the variable nature of the list size, 
                    since the number of multiples depends directly on the value of the length variable.

                    2- Make a loop where from 1 to length:
                        a) Calculate the multiple of length by number.
                        b) Include this value in the list.
                    3- Convert the list to an array, since this is the function's return format.
                    4- Return the array in the function's return.

        */
        List<double> multiples = new List<double>();
        for (double i = 1; i<= length; i++)
        {
            multiples.Add(i*number);
        }

        return multiples.ToArray(); // replace this return statement with your own
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
        /*
            Plan to solve the RotateListRight problem
            
            Steps to rotate:

                1- Create a for loop that will iterate the number of times defined in the amount variable.
                    a) Here an example: for (int i = 1; i<= amount; i++)
                    b)At each iteration the index will be increased by one unit until it reaches the value 
                        defined in amount.
                2- Inside the for loop.
                    a) Get the last element of the list and save it in an auxiliary variable.
                    b) Remove the last element of the list.
                    c) Insert the contents of the auxiliary variable (Last element of the list) 
                    at the beginning of the list, causing a right rotation.
        */

        for (int i = 1; i<= amount; i++)
        {
            int aux = data[data.Count - 1];
            data.RemoveAt(data.Count - 1);
            data.Insert(0,aux);
        }

    }
}

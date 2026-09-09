public static class Arrays
{
    /// <summary>
    /// This function will produce an array of size 'length' starting with 'number' followed by multiples of 'number'. For 
    /// example, MultiplesOf(7, 5) will result in: {7, 14, 21, 28, 35}. Assume that length is a positive
    /// integer greater than 0.
    /// </summary>
    /// <returns>array of doubles that are the multiples of the supplied number</returns>
    public static double[] MultiplesOf(double number, int length)
    {
        // 1. Create a new array with the requested length.
        // 2. Loop through each position in the array.
        // 3. Calculate the multiple of the given number using the current position.
        // 4. Store the calculated multiple in the array.
        // 5. Return the completed array.

        var multiples = new double[length];

        for (var i = 0; i < length; i++)
        {
            multiples[i] = number * (i + 1);
        }

        return multiples;
    }

    /// <summary>
    /// Rotate the 'data' to the right by the 'amount'. For example, if the data is 
    /// List<int>{1, 2, 3, 4, 5, 6, 7, 8, 9} and an amount is 3 then the list after the function runs should be 
    /// List<int>{7, 8, 9, 1, 2, 3, 4, 5, 6}. The value of amount will be in the range of 1 to data.Count, inclusive.
    ///
    /// Because a list is dynamic, this function will modify the existing data list rather than returning a new list.
    /// </summary>
    public static void RotateListRight(List<int> data, int amount)
    {
        // 1. Calculate the index where the last 'amount' elements begin.
        // 2. Create a new list containing the last 'amount' elements.
        // 3. Remove those elements from the original list.
        // 4. Insert the saved elements at the beginning of the original list.
        // 5. The original list is now rotated to the right by 'amount' positions.

        var startIndex = data.Count - amount;

        var lastElements = data.GetRange(startIndex, amount);

        data.RemoveRange(startIndex, amount);

        data.InsertRange(0, lastElements);
    }
}

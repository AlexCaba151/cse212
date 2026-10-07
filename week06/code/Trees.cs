public static class Trees
{
    /// <summary>
    /// Given a sorted list (sortedNumbers), create a balanced BST. If the values in the
    /// sortedNumbers were inserted in order from left to right into the BST, then it
    /// would resemble a linked list (unbalanced). To get a balanced BST, the
    /// InsertMiddle function is called to find the middle item in the list to add
    /// first to the BST. The InsertMiddle function takes the whole list but also takes
    /// a range (first to last) to consider. For the first call, the full range of 0 to
    /// Length-1 is used.
    /// </summary>
    public static BinarySearchTree CreateTreeFromSortedList(int[] sortedNumbers)
    {
        var bst = new BinarySearchTree(); // Create an empty BST to start with
        InsertMiddle(sortedNumbers, 0, sortedNumbers.Length - 1, bst);
        return bst;
    }

    /// <summary>
    /// This function will attempt to insert the item in the middle of 'sortedNumbers' into
    /// the 'bst' tree. The middle is determined by using indices represented by 'first' and
    /// 'last'.
    /// </summary>
    private static void InsertMiddle(
        int[] sortedNumbers,
        int first,
        int last,
        BinarySearchTree bst)
    {
        // Stop when there are no more values to insert.
        if (first > last)
        {
            return;
        }

        // Find the middle index.
        int middle = (first + last) / 2;

        // Insert the middle value into the BST.
        bst.Insert(sortedNumbers[middle]);

        // Recursively insert the middle value from the left half.
        InsertMiddle(sortedNumbers, first, middle - 1, bst);

        // Recursively insert the middle value from the right half.
        InsertMiddle(sortedNumbers, middle + 1, last, bst);
    }
}
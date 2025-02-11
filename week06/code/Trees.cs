public static class Trees
{
    /// <summary>
    /// Given a sorted list (sorted_list), create a balanced BST.  If the values in the
    /// sortedNumbers were inserted in order from left to right into the BST, then it
    /// would resemble a linked list (unbalanced). To get a balanced BST, the
    /// InsertMiddle function is called to find the middle item in the list to add
    /// first to the BST. The InsertMiddle function takes the whole list but also takes
    /// a range (first to last) to consider.  For the first call, the full range of 0 to
    /// Length-1 used.
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
    /// For example, if the function was called on:
    ///
    /// sortedNumbers = new[]{10, 20, 30, 40, 50, 60};
    /// first = 0;
    /// last = 5;
    /// 
    /// then the value 30 (index 2 which is the middle) would be added 
    /// to the 'bst' (the insert function in the <see cref="BinarySearchTree"/> can be used
    /// to do this).   
    ///
    /// Subsequent recursive calls are made to insert the middle from the values 
    /// before 30 and the values after 30.  If done correctly, the order
    /// in which values are added (which results in a balanced bst) will be:
    /// 
    /// 30, 10, 20, 50, 40, 60
    /// 
    /// This function is intended to be called the first time by CreateTreeFromSortedList.
    ///
    /// The purpose for having the first and last parameters is so that we do 
    /// not need to create new sub-lists when we make recursive calls.  Avoid 
    /// using list slicing to create sub-lists to solve this problem.    
    /// </summary>
    /// <param name="sortedNumbers">input numbers that are already sorted</param>
    /// <param name="first">the first index in the sortedNumbers to insert</param>
    /// <param name="last">the last index in the sortedNumbers to insert</param>
    /// <param name="bst">the BinarySearchTree in which to insert the values</param>
    private static void InsertMiddle(int[] sortedNumbers, int first, int last, BinarySearchTree bst)
    {
       
        // TODO Start Problem 5

        if (sortedNumbers.Length == 0)
        {
            return;
        }
        else
        {
            int mid = (last - first) / 2;
           
            bst.Insert(sortedNumbers[first + mid]);
            if (mid == 0)
            {
                if (last-first == 1)
                {
                    InsertMiddle(sortedNumbers, first + mid + 1, last, bst);
                }
                return;
            }
            InsertMiddle(sortedNumbers, first, first + mid, bst);
            InsertMiddle(sortedNumbers, first + mid + 1, last, bst);
        }
        
        

        /*
        if (sortedNumbers.Length > 1 )
        {
            int mid = (last - first) / 2;
            bst.Insert(sortedNumbers[mid]);
            (int[] firstHalf, int[] secondHalf) = SplitArray(sortedNumbers);
            if (firstHalf.Length > 0)
            {
                InsertMiddle(firstHalf, 0, firstHalf.Length-1, bst);
            }
            if (secondHalf.Length > 0)
            {
                InsertMiddle(secondHalf, 0, secondHalf.Length-1, bst);
            } 
        }
        else
        {
            bst.Insert(sortedNumbers[0]);
        }
        
        */
    }


    static (int[], int[]) SplitArray(int[] array)
    {
        int mid = array.Length / 2;
        int[] firstHalf = new int[mid];
        int[] secondHalf = new int[array.Length - mid];

        Array.Copy(array, 0, firstHalf, 0, mid);
        Array.Copy(array, mid, secondHalf, 0, array.Length - mid);

        return (firstHalf, secondHalf);
    }


    
}
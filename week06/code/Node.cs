public class Node
{
    public int Data { get; set; }
    public Node? Right { get; private set; }
    public Node? Left { get; private set; }

    public Node(int data)
    {
        this.Data = data;
    }

    public void Insert(int value)
    {
        // TODO Start Problem 1

        if (value < Data)
        {
            // Insert to the left
            if (Left is null)
                Left = new Node(value);
            else
                Left.Insert(value);
        }
        else
        {
            if (value > Data)
            {
                // Insert to the right
                if (Right is null)
                    Right = new Node(value);
                else
                    Right.Insert(value);
            }
        }
    }

    public bool Contains(int value)
    {
        // TODO Start Problem 2

        if (value == Data)
        {
            return true;
        }
        else
        {
            if (value < Data)
            {
                // Insert to the left
                if (Left is null)
                    return false;
                else
                    return Left.Contains(value);
            }
            else
            {
                if (value > Data)
                {
                    // Insert to the right
                    if (Right is null)
                        return false;
                    else
                        return Right.Contains(value);
                }
            }
        }
        return false;
    }

    public int GetHeight()
    {
        // TODO Start Problem 4
        int i = 1;
        int j = 1;
        int res = 0;

        if (Right != null)
        {
            i += Right.GetHeight();
        }
        if (Left != null)
        {
            j += Left.GetHeight();
        }

        if (i == j)
        { 
            res = i;
        }
        else
        {
            if (i > j)
            {
                res = i;
            }
            else
            {
                res = j;
            }
        }
        return res; // Replace this line with the correct return statement(s)
    }
}
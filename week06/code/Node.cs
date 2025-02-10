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
        if (value == Data)
            return; // No duplicates allowed
        
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
            // Insert to the right
            if (Right is null)
                Right = new Node(value);
            else
                Right.Insert(value);
        }
    }

    public bool Contains(int value)
    {
        // TODO Start Problem 2
        if (value == Data)
            return true; // Found the value
        
        if (value < Data)
        {
            // Search to the left
            if (Left is null)
                return false; // Not found
            else
                return Left.Contains(value); // Recursively search
        } else {
            // Search to the right
            if (Right is null)
                return false; // Not found
            else
                return Right.Contains(value); // Recursively search
        }
    }

    public int GetHeight()
    {
        // TODO Start Problem 4
        if (Left is null && Right is null)
            return 1; // One node has a height of 1

        int leftHeight;
        int rightHeight;

        if (Left is not null) {
            leftHeight = Left.GetHeight();
        } else {
            leftHeight = -1; // Height of -1 for null nodes
        }
        
        if (Right is not null) {
            rightHeight = Right.GetHeight();
        } else {
            rightHeight = -1; // Height of -1 for null nodes
        }

        return 1 + Math.Max(leftHeight, rightHeight);
    }
}
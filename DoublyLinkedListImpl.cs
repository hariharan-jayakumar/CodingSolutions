public class DoublyLinkedListImpl {
    Node first = null;
    Node last = null;

    public DoublyLinkedListImpl()
    {
    }

    public Node AddNewNode(int key, int value)
    {
        Node nodeRef = new Node(key, value);
        if(first == null)
        {
            first = last = nodeRef;
        }
        else
        {
            last.child = nodeRef;
            nodeRef.parent = last;
            last = nodeRef;
        }
        return nodeRef;
    }

    public void MoveToLast(Node recentNode)
    {
        if (recentNode == last)
        {
            return;
        }

        Node recentNodeParent = recentNode.parent;
        if (recentNodeParent == null)
        {
            first = recentNode.child;
        }
        else
        {
            recentNodeParent.child = recentNode.child;
        }

        recentNode.child.parent = recentNodeParent;
        recentNode.parent = last;
        last.child = recentNode;
        last = recentNode;
    }

    public int RemoveLRUNode()
    {
        Node firstNode = first;
        first.child.parent = null;
        first = first.child;
        return firstNode._key;
    }


    public void Print()
    {
        StringBuilder sb = new StringBuilder();
        Node currentNode = first;
        while (currentNode != null)
        {
            sb.Append('(');
            sb.Append(currentNode._key);
            sb.Append(",");
            sb.Append(currentNode._value);
            sb.Append(")");
            sb.Append(",");
            currentNode = currentNode.child;
        }
        //Console.WriteLine(sb.ToString());
    }
}
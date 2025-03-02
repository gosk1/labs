namespace Lab02;

public class LinkedListVector
{
    private Node head;

    private class Node
    {
        public int Value;
        public Node Next;
        
        public Node()
        {
            Value = 0;
            Next = null;
        }

        public Node(int value)
        {
            Value = value;
            Next = null;
        }
    }

    public LinkedListVector()
    {
        var r = new Random();
        
        head = new Node(r.Next(100));
        Node cur = head;
        
        for (int i = 0; i < 5; i++)
        {
            cur.Next = new Node(r.Next(100));
            cur = cur.Next;
        }
    }
    
    public LinkedListVector(int length)
    {
        var r = new Random();
        
        head = new Node(r.Next(100));
        Node cur = head;
        
        for (int i = 0; i < length; i++)
        {
            cur.Next = new Node(r.Next(100));
            cur = cur.Next;
        }
    }

    public int this[int idx]
    {
        get
        {
            if (0 <= idx && idx <= Length)
            {
                Node cur = head;
                for (int i = 0; i < idx; i++)
                {
                    cur = cur.Next;
                }

                return cur.Value;
            }
            else
            {
                throw new IndexOutOfRangeException("Linked list index out of range");
            }
        }
        set
        {
            if (0 <= idx && idx <= Length)
            {
                Node cur = head;
                for (int i = 0; i < idx; i++)
                {
                    cur = cur.Next;
                }

                cur.Value = value;
            }
            else
            {
                throw new IndexOutOfRangeException("Linked list index out of range");
            }
        }
    }

    public int Length
    {
        get
        {
            if (head == null)
            {
                return -1;
            }

            int length = 0;
            Node cur = head;
            while (cur.Next != null)
            {
                cur = cur.Next;
                length++;
            }

            return length;
        }
    }

    public double GetNorm()
    {
        double acc = 0;
        Node cur = head;
        for (int i = 0; i < Length; i++)
        {
            acc += Math.Pow(cur.Value, 2);
            cur = cur.Next;
        }

        return Math.Sqrt(acc);
    }

    public void AddToStart(int value)
    {
        Node tmp = new Node(value);
        tmp.Next = head;
        head = tmp;
    }
    
    public void AddToEnd(int value)
    {
        AddByIndex(Length, value);
    }

    public void AddByIndex(int idx, int value)
    {
        if (0 <= idx && idx <= Length)
        {
            Node cur = head;
            for (int i = 0; i < idx - 1; i++)
            {
                cur = cur.Next;
            }

            Node tmp = new Node(value);
            tmp.Next = cur.Next;
            cur.Next = tmp;
        }
        else
        {
            throw new IndexOutOfRangeException("Linked list index out of range");
        }
    }

    public void DeleteFromStart()
    {
        head = head.Next;
    }

    public void DeleteFromEnd()
    {
        Node cur = head;
        for (int i = 0; i < Length - 1; i++)
        {
            cur = cur.Next;
        }

        cur.Next = null;
    }
    
    public void DeleteByIndex(int idx)
    {
        if (0 <= idx && idx <= Length)
        {
            Node cur = head;
            for (int i = 0; i < idx - 1; i++)
            {
                cur = cur.Next;
            }

            cur.Next = cur.Next.Next;
        }
        else
        {
            throw new IndexOutOfRangeException("Linked list index out of range");
        }
    }

    public void Log(string message = "")
    {
        if (message != "")
        {
            Console.Write($"{message}: ");
        }
        var cur = head;
        Console.Write("{");
        while (cur.Next != null)
        {
            if (cur.Next.Next == null)
            {
                Console.Write(cur.Value);
            }
            else
            {
                Console.Write(cur.Value + ", ");
            }
            cur = cur.Next;
        }
        Console.WriteLine("}");
    }
}
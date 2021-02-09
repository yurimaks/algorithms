namespace DataStructure
{
    public class LinkedList
    {
        public class Node
        {
            public Node(int v)
            {
                val = v;
            }
            public int val { get; set; }
            public Node next { get; set; }
        }

        public Node head { get; set; }

        public LinkedList()
        {
            head = null;
        }

        public void AddFront(int data)
        {
            var newNode = new Node(data);
            if (head == null)
            {
                head = newNode;
                return;
            }
            
            newNode.next = head;
            head = newNode;
        }

        public void AddBack(int data)
        {
            var newNode = new Node(data);
            if (head == null)
            {
                head = newNode;
                return;
            }

            var current = head;
            while (current.next != null)
            {
                current = current.next;
            }

            current.next = newNode;
        }

        public int Size()
        {
            if (head == null)
            {
                return 0;
            }

            var count = 1;
            var current = head;
            while (current.next != null)
            {
                current = current.next;
                count++;
            }

            return count;
        }

        public void DeleteValue(int value)
        {
            if (head == null)
            {
                return;
            }

            if (head.val == value)
            {
                head = null;
                return;
            }
            
            var current = head;
            while (current.next != null)
            {
                if (current.next.val == value)
                {
                    current.next = current.next.next;
                    return;
                }

                current = current.next;
            }
        }

        public void DeleteTail()
        {
            if (head == null)
            {
                return;
            }
            
            if (head.next == null)
            {
                head = null;
            }
            
            var pointer1 = head;
            var pointer2 = head.next;

            //Programming trick to find the one-before-the-last node
            while (pointer2.next != null)
            {
                pointer1 = pointer1.next;
                pointer2 = pointer2.next;
            }

            pointer1.next = null;
        }
        
        public int GetValueBeforeLast()
        {
            if (head == null)
            {
                return -1;
            }
            
            var pointer1 = head;
            var pointer2 = head.next;

            //Programming trick to find the one-before-the-last node
            while (pointer2.next != null)
            {
                pointer1 = pointer1.next;
                pointer2 = pointer2.next;
            }

            return pointer1.val;
        }

        public int Middle()
        {
            if (head == null)
            {
                return -1;
            }
            
            var slow = head;
            var fast = head;

            //Programming trick to find the one-before-the-last node
            while (fast?.next != null)
            {
                fast = fast.next.next;
                slow = slow.next;
            }

            return slow.val;
        }

        public int GetFirst()
        {
            if (head == null) return -1;

            return head.val;
        }

        public int GetLast()
        {
            if (head == null) return -1;

            var pointer = head;

            while (pointer.next != null)
            {
                pointer = pointer.next;
            }

            return pointer.val;
        }
    }
}
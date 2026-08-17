namespace LinkedListIntersection
{
    // Two acyclic singly linked lists. Find the first node where they merge (if any),
    // using O(1) extra memory and O(n + m) time.
    public class ListNode
    {
        public int Val;
        public ListNode? Next;

        public ListNode(int val, ListNode? next = null)
        {
            Val = val;
            Next = next;
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            // shared tail: 4 -> 5 -> 6 -> 7 -> null
            ListNode shared = new(4, new ListNode(5, new ListNode(6, new ListNode(7))));

            ListNode listA = new(1, new ListNode(2, new ListNode(3, shared)));
            ListNode listB = new(1, new ListNode(2, shared));

            ListNode? intersection = GetIntersectionNode(listA, listB);
            Console.WriteLine(intersection is null
                ? "Lists do not merge."
                : $"Lists merge at node with value: {intersection.Val}");

            ListNode disjointA = new(1, new ListNode(2));
            ListNode disjointB = new(9, new ListNode(8));
            Console.WriteLine(GetIntersectionNode(disjointA, disjointB) is null
                ? "Lists do not merge."
                : "Unexpected merge.");
        }

        // Walk both lists in lockstep; when a pointer hits the end, redirect it to the
        // other list's head. Both pointers then travel len(A) + len(B) nodes total, so
        // they either meet exactly at the first shared node or reach null together.
        public static ListNode? GetIntersectionNode(ListNode headA, ListNode headB)
        {
            ListNode? pointerA = headA;
            ListNode? pointerB = headB;

            while (!ReferenceEquals(pointerA, pointerB))
            {
                pointerA = pointerA is null ? headB : pointerA.Next;
                pointerB = pointerB is null ? headA : pointerB.Next;
            }

            return pointerA;
        }
    }
}

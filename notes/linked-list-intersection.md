# Merging Linked Lists (Intersection Point)

Given the heads of two acyclic singly linked lists, determine — in O(1)
extra memory and O(n + m) time — whether they merge into the same node, and
if so, find the first shared node.

## Idea

Checking every pair of nodes is O(n·m). Instead, walk both lists with two
pointers in lockstep. When a pointer reaches the end of its list, redirect
it to the *other* list's head. Both pointers then travel `len(A) + len(B)`
nodes total before either meeting at the first common node or hitting
`null` together (no intersection) — the length difference cancels out.

## Original notes

![Handwritten notes for merging linked lists](images/linked-list-intersection.png)

## Edge cases

- Lists aren't the same length
- Lists don't intersect at all
- Intersection at the very first node (both heads equal)

## Complexity

Time: O(n + m), Space: O(1)

Code: [`../LinkedListIntersection`](../LinkedListIntersection)

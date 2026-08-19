<div align="center">

![Analytical Tasks](docs/assets/banner.png)

</div>

Algorithm problems worked out by hand in [Notewise](notewise) on a tablet,
then implemented as small C# console projects — one folder per task, each
with its own write-up and the original handwritten page.

## Tasks

| Task | Concept | Complexity |
| --- | --- | --- |
| [Poisoned Vial Identification](PoisonedVialIdentification) | Binary encoding | O(log V) animals |
| [Linked List Intersection](LinkedListIntersection) | Two pointers | O(n + m) time, O(1) space |
| [Guess Number Higher or Lower](GuessNumberHigherOrLower) | Binary search | O(log n) |
| [Maximum Subarray Sum](MaximumSubarraySum) | Kadane's algorithm | O(n) time, O(1) space |

## Run

```bash
git clone https://github.com/hristianivanov/analytical-tasks.git
cd analytical-tasks
dotnet run --project <TaskFolderName>
```

## Adding a New Task

1. Solve it by hand in Notewise; drop the exported page into [`notewise/`](notewise).
2. `dotnet new console -n TaskName` and add it to `analytical-tasks.slnx`.
3. Implement the solution in `TaskName/Program.cs`.
4. Add `TaskName/README.md` — problem statement, the handwritten page image, approach, complexity, run command (use an existing task folder as the template).
5. Add a row to the table above.

# Guess Number Higher or Lower

A number `num` between 1 and n is picked at random. `guess(x)` returns `0`
if `x == num`, and tells you whether to go higher or lower otherwise. Find
`num` with the minimum number of guesses in the worst case.

![Handwritten note](handwritten-note.png)

## Approach

Binary search: each guess halves the remaining range, so the worst case is
`O(log n)` guesses instead of `O(n)` for a linear scan.

**Edge cases:** range is a plain sorted numeric range 1..n, and `num` is
always guaranteed to be inside it.

## Complexity

Worst-case / average-case: `O(log n)` — for n = 1000, that's ≤ 10 guesses.
Space: `O(1)`

## Run

```bash
dotnet run --project GuessNumberHigherOrLower
```

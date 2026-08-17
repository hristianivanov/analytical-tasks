# Guess Number Higher or Lower

A number `num` between 1 and n is picked at random. `guess(x)` returns `0`
if `x == num`, and tells you whether to go higher or lower otherwise. Find
`num` with the minimum number of guesses in the worst case.

## Idea

Binary search: each guess halves the remaining range, so the worst case is
`O(log n)` guesses instead of `O(n)` for a linear scan.

## Edge cases

- Is the range guaranteed to be sorted? Yes — it's a plain numeric range.
- Is `num` guaranteed to be in range? Yes.

## Complexity

Worst-case / average-case: O(log n) — for n = 1000, that's ≤ 10 guesses.
Space: O(1)

Code: [`../GuessNumberHigherOrLower`](../GuessNumberHigherOrLower)

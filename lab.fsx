//#### Binary Tree as DU *)
type Tree =
    | Empty
    | Node of int * Tree * Tree

//#### Binary Tree as DU  *)

let tree =
    Node (8,
     Node (3,
      Node (1, Empty, Empty),
      Node (6,
       Node (4, Empty, Empty),
       Node (7, Empty, Empty))),
     Node (10,
      Empty,
      Node (14,
       Node (13, Empty, Empty),
       Empty)))

printf "This is what a tree looks like: %A" tree

let sprintfResult = sprintf "%A" tree

//### Example 1.1
let rec countInternal (tree: Tree) : int =
    match tree with
    | Empty -> 0
    | Node (_, Empty, Empty) -> 0
    | Node (_, left, right) ->
        1 + countInternal left + countInternal right

let ``example 1.1`` = countInternal tree

//### Exercise 1.1
//Sum values of all leaves in tree
let rec sumLeaves (tree: Tree) : int =
    match tree with
    | Node(x: int, Empty, Empty) -> x
    | Node(_, left, right) -> sumLeaves left + sumLeaves right
    | Empty -> 0

let ``exercise 1.1`` = sumLeaves tree

//### Example 1.2
(* Collecting **leaf values** from tree into a list *)
let rec collectLeaves (tree : Tree) : int list =
    match tree with
    | Empty -> []
    | Node (v, Empty, Empty) -> [v]
    | Node (_, left, right) ->
        collectLeaves left @ collectLeaves right

let ``example 1.2`` = collectLeaves tree

//### Exercise 1.2
// Collect **all values** from tree into a list in-order
let rec collectInOrder (tree : Tree) : int list =
    match tree with
    | Node(x :int, left, right) -> [x] @ collectInOrder left @ collectInOrder right   
    | Empty -> []

let ``exercise 1.2`` = collectInOrder tree

//### Exercise 1.3
// Check if tree is sorted
let isSorted (tree: Tree) : bool =
    let a = collectInOrder tree
    let b = List.sort a
    a = b 

let ``exercise 1.3`` = isSorted tree


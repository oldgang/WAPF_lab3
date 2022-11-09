let SHOW x = printf "%A\n" x

type Shape =
    | Square of float
    // `*` in type declarations stands for tuples
    | Rectangle of float * float
    | Circle of float

type Tree =
    | Empty
    | Node of int * Tree * Tree

//#### Binary Tree as DU

let tree =
    Node
        (8,
         Node(3, Node(1, Empty, Empty), Node(6, Node(4, Empty, Empty), Node(7, Empty, Empty))),
         Node(10, Empty, Node(14, Node(13, Empty, Empty), Empty)))


//### Exercise 1.1
//##Sum values of all leaves in tree

//#### --------------- Your code goes below --------------- *)
let rec sumLeaves (tree: Tree): int = 0

let ``exercise 1.1`` = sumLeaves tree
(** #### Value of ``exercise 1.1`` *)
SHOW ``exercise 1.1``

//### Exercise 1.2
//##Collect **all values** from tree into a list in-order

//#### --------------- Your code goes below --------------- *)
let rec collectInOrder (tree: Tree): int list = []

let ``exercise 1.2`` = collectInOrder tree
(** #### Value of ``exercise 1.2`` *)
SHOW ``exercise 1.2``

//### Exercise 1.3
//##Check if tree is sorted

//#### --------------- Your code goes below --------------- *)
let isSorted (tree: Tree): bool = false

let ``exercise 1.3`` = isSorted tree
(** #### Value of ``exercise 1.3`` *)
SHOW ``exercise 1.3``

//### Exercise 1.4
//##Insert element into Binary Search Tree

//#### --------------- Your code goes below --------------- *)
let rec insertBST (value: int) (tree: Tree): Tree = Empty

let ``exercise 1.4`` = insertBST 5 tree |> collectInOrder
//** #### Value of ``exercise 1.4`` *)
SHOW ``exercise 1.4``

//### Exercise 2.1
//Check if hand is *Flush*

//#### Modelling cards *)
type Figure =
    | Two
    | Three
    | Four
    | Five
    | Six
    | Seven
    | Eight
    | Nine
    | Ten
    | Jack
    | Queen
    | King
    | Ace

type Suit =
    | Diamonds
    | Spades
    | Hearts
    | Clubs

// Type alias for a tuple
type Card = Figure * Suit

// Type alias for a list
type Hand = Card list


//Note: `List.forall` could be useful
//#### --------------- Your code goes below --------------- *)
let handFlush =
    [ (King, Clubs)
      (Queen, Clubs)
      (Nine, Clubs)
      (Eight, Clubs)
      (Five, Clubs) ]

let isFlush (hand: Hand): bool = false

let ``exercise 2.1`` = isFlush handFlush
//** #### Value of ``exercise 2.1`` *)
SHOW ``exercise 2.1``

//### Exercise 2.2
//##Check if hand is *Full House*

//#### --------------- Your code goes below --------------- *)
let handFullHouse =
    [ (King, Clubs)
      (King, Spades)
      (Nine, Clubs)
      (Nine, Diamonds)
      (Nine, Spades) ]

let isFullHouse (hand: Hand): bool = false

let ``exercise 2.2`` = isFullHouse handFullHouse
//** #### Value of ``exercise 2.2`` *)
SHOW ``exercise 2.2``

type Point = { X: float; Y: float }

type CenteredShape = { Shape: Shape; Center: Point }
//### Exercise 2.3
//##Check if first shape is circumcircle of second shape.
//##First shape must be a circle, second a square or rectangle or circle

//#### --------------- Your code goes below --------------- *)

let isCircumCircle (centeredCircle: CenteredShape) (centeredShape: CenteredShape): bool = false

let ``exercise 2.3`` =
    [ ({ Shape = Circle(sqrt 2.0)
         Center = { X = 0.0; Y = 0.0 } },
       { Shape = Square 2.0
         Center = { X = 0.0; Y = 0.0 } })

      ({ Shape = Circle(sqrt 2.0)
         Center = { X = 1.0; Y = 0.0 } },
       { Shape = Square 2.0
         Center = { X = 0.0; Y = 0.0 } })

      ({ Shape = Square 2.5
         Center = { X = 0.0; Y = 0.0 } },
       { Shape = Rectangle(3., 4.)
         Center = { X = 0.0; Y = 0.0 } })

      ({ Shape = Circle 2.5
         Center = { X = 0.0; Y = 0.0 } },
       { Shape = Rectangle(3., 4.)
         Center = { X = 0.0; Y = 1.0 } }) ]
    |> List.map (fun (first, second) -> isCircumCircle first second)
//** #### Value of ``exercise 2.3`` *)
SHOW ``exercise 2.3``

//### Exercise 2.4
//##Scale centered shape

//#### --------------- Your code goes below --------------- *)
let scale (magnitude: float) (centeredShape: CenteredShape): CenteredShape = centeredShape

let ``exercise 2.4`` =
    [ { Shape = Circle(sqrt 2.0)
        Center = { X = 0.0; Y = 0.0 } }
      { Shape = Square 1.0
        Center = { X = 0.0; Y = 3.0 } }
      { Shape = Rectangle(3., 4.)
        Center = { X = 0.0; Y = 1.0 } } ]
    |> List.map (scale 2.0)

//** #### Value of ``exercise 2.4`` *)
SHOW ``exercise 2.4``



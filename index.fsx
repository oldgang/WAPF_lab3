﻿(*
- title : Functional Data Structures
- description : Functional Data Structures
- author : Tomasz Heimowski
- theme : night
- transition : default

***

//### Functional Data Structures

    [lang=bash]
    git clone https://github.com/manuxx/wapf-fsharp-data-clean.git

or download ZIP from [here](https://github.com/manuxx/wapf-fsharp-data-clean/archive/master.zip), then in **Command Prompt**:

    [lang=bash]
    cd fsharp-workshops-data
    .\build.cmd KeepRunning

slides are regenerated when the script (.\slides\index.fsx) is **saved**

==> **NOTE:** this is a different GIT repository, don't mix it with the one from previous workshops

*)


// ##################################### SECTION 1
//## Sum Types
//### Discriminated Unions

//### New Stuff 1.1
//#### Discriminated Unions reminder *)
type Shape =
    | Square of float
    // `*` in type declarations stands for tuples
    | Rectangle of float * float
    | Circle of float

(**

---

//#### Binary Tree as DU *)
type Tree =
    | Empty
    | Node of int * Tree * Tree

(**

---

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

(**
![bst](images/bst.png)

---

//### printf and sprintf for debugging *)

printf "This is what a tree looks like: %A" tree

let sprintfResult = sprintf "%A" tree

(** #### Value of ``sprintfResult`` *)
(*** include-value: ``sprintfResult`` ***)





(**
---

//### Example 1.1
Counting internal nodes (nodes that have at least one non-empty child) *)
let rec countInternal (tree: Tree) : int =
    match tree with
    | Empty -> 0
    | Node (_, Empty, Empty) -> 0
    | Node (_, left, right) ->
        1 + countInternal left + countInternal right

let ``example 1.1`` = countInternal tree
(** #### Value of ``example 1.1`` *)
(*** include-value: ``example 1.1`` ***)
(**


---

//### Exercise 1.1

Sum values of all leaves in tree

//#### --------------- Your code goes below --------------- *)
let rec sumLeaves (tree: Tree) : int =
    match tree with
    | Node(x: int, Empty, Empty) -> x
    | Node(_, left, right) -> sumLeaves left + sumLeaves right
    | Empty -> 0

let ``exercise 1.1`` = sumLeaves tree
(** #### Value of ``exercise 1.1`` *)
(*** include-value: ``exercise 1.1`` ***)
(**





---

//### New Stuff 1.2
//#### List concatenation operator *)
let firstList = [1; 3; 5]
let secondList = [2 .. 10]
let concatenatedList = firstList @ secondList
(** #### Value of ``concatenatedList`` *)
(*** include-value: ``concatenatedList`` ***)
(**

---

//#### In-Order traversal

![inorder](images/inorder.png)

---

//### Example 1.2
Collecting **leaf values** from tree into a list *)
let rec collectLeaves (tree : Tree) : int list =
    match tree with
    | Empty -> []
    | Node (v, Empty, Empty) -> [v]
    | Node (_, left, right) ->
        collectLeaves left @ collectLeaves right

let ``example 1.2`` = collectLeaves tree
(** #### Value of ``example 1.2`` *)
(*** include-value: ``example 1.2`` ***)
(**

---

//### Exercise 1.2
Collect **all values** from tree into a list in-order

//#### --------------- Your code goes below --------------- *)
let rec collectInOrder (tree : Tree) : int list =
    []

let ``exercise 1.2`` = collectInOrder tree
(** #### Value of ``exercise 1.2`` *)
(*** include-value: ``exercise 1.2`` ***)
(**





---

//### Exercise 1.3
Check if tree is sorted

//#### --------------- Your code goes below --------------- *)
let isSorted (tree: Tree) : bool =
    false

let ``exercise 1.3`` = isSorted tree
(** #### Value of ``exercise 1.3`` *)
(*** include-value: ``exercise 1.3`` ***)
(**





---

//### Example 1.4
Manipulating the tree (immutability) *)
let rec incrementValues (tree: Tree) : Tree =
    match tree with
    | Empty -> Empty
    | Node (v, left, right) ->
        Node (v + 1, incrementValues left, incrementValues right)

let ``example 1.4`` = incrementValues tree |> collectInOrder
(** #### Value of ``example 1.4`` *)
(*** include-value: ``example 1.4`` ***)
(**

---

//### Exercise 1.4
Insert element into Binary Search Tree

//#### --------------- Your code goes below --------------- *)
let rec insertBST (value: int) (tree: Tree) : Tree =
    Empty

let ``exercise 1.4`` = insertBST 5 tree |> collectInOrder
//** #### Value of ``exercise 1.4`` *)
//* include-value: ``exercise 1.4`` ***)

//### Summary: Sum Types (Discriminated Unions)

//* DUs represent distinct cases that **sum up** to the represented Type
//* DUs types can be defined in recursive way (e.g. Node in Tree)
//* DUs are immutable - can make a copy, but not mutate

//### Links
//* [Discriminated Unions - Adding types together](https://fsharpforfunandprofit.com/posts/discriminated-unions/) by Scott Wlaschin
//* [Introduction to recursive types](https://fsharpforfunandprofit.com/posts/recursive-types-and-folds/) by Scott Wlaschin


// ##################################### SECTION 1
//## Product Types
//### Tuples, Records


//### New Stuff 2.1
//#### Modelling cards *)
type Figure =
    | Two  | Three | Four  | Five
    | Six  | Seven | Eight | Nine
    | Ten  | Jack  | Queen | King | Ace

type Suit = Diamonds | Spades | Hearts | Clubs

// Type alias for a tuple
type Card = Figure * Suit

// Type alias for a list
type Hand = Card list


//### Anonymous (lambda) functions  *)
let oddNumbers =
    [1 .. 10]
    |> List.filter (fun n -> n % 2 = 1)
//** #### Value of ``oddNumbers`` *)
//* include-value: ``oddNumbers`` ***)

//### Pattern matching tuples *)
let kingSpades = King, Spades
let (figure, suit) = kingSpades
let isKingSpades =
    match kingSpades with
    | King, Spades -> true
    | _ -> false
//** #### Value of ``figure`` *)
//* include-value: ``figure`` ***)
//** #### Value of ``suit`` *)
//* include-value: ``suit`` ***)
//** #### Value of ``isKingSpades`` *)
//* include-value: ``isKingSpades`` ***)

//### Tuple helper functions *)
let queenHearts = Queen, Hearts
let queen = fst queenHearts
let hearts = snd queenHearts
//** #### Value of ``queen`` *)
//* include-value: ``queen`` ***)
//** #### Value of ``hearts`` *)
//* include-value: ``hearts`` ***)

//### Example 2.1
Checking all cards *)
let threeKings =
    [ (King, Clubs)
      (King, Diamonds)
      (King, Hearts) ]

let ``example 2.1`` =
    threeKings
    |> List.forall (fun (figure,suit) -> figure = King)
//** #### Value of ``example 2.1`` *)
//* include-value: ``example 2.1`` ***)

//### Poker hands

//### Exercise 2.1
//Check if hand is *Flush*

//Note: `List.forall` could be useful
//#### --------------- Your code goes below --------------- *)
let handFlush = [ (King, Clubs); (Queen, Clubs); 
                  (Nine, Clubs); (Eight, Clubs); (Five, Clubs) ]

let isFlush (hand: Hand) : bool =
    false

let ``exercise 2.1`` = isFlush handFlush
//** #### Value of ``exercise 2.1`` *)
//* include-value: ``exercise 2.1`` ***)

//### New Stuff 2.2
//#### List.Map *)
let mapModThree =
    [1 .. 10]
    |> List.map (fun n -> n % 3 = 0)
//** #### Value of ``mapModThree`` *)
//* include-value: ``mapModThree`` ***)

//#### List.GroupBy *)
let groupModThree =
    [1 .. 10]
    |> List.groupBy (fun n -> n % 3)
//** #### Value of ``groupModThree`` *)
//* include-value: ``groupModThree`` ***)

//### Example 2.2
//##Counting occurences  
let ``example 2.2`` =
    ["Ananas"; "Banan"; "Agrest"; "Cukinia"; "Cebula"; "Aronia"]
    |> List.groupBy (fun word -> word.ToCharArray().[0])
    |> List.map (fun (letter,words) -> (letter,words.Length))
//** #### Value of ``example 2.2`` *)
//* include-value: ``example 2.2`` ***)

//### Exercise 2.2
//##Check if hand is *Full House*

//#### --------------- Your code goes below --------------- *)
let handFullHouse = [ (King, Clubs); (King, Spades); 
                      (Nine, Clubs); (Nine, Diamonds); (Nine, Spades) ]

let isFullHouse (hand: Hand) : bool =
    false

let ``exercise 2.2`` = isFullHouse handFullHouse
//** #### Value of ``exercise 2.2`` *)
//* include-value: ``exercise 2.2`` ***)

//### New Stuff 2.3
//#### Records *)

type Point =
    { X : float
      Y : float }

type CenteredShape =
    { Shape : Shape
      Center : Point }

//#### Record fields (labeled) *)

let point = { X = 2.0; Y = 4.5 }
let positionedShape = { Shape = Square 3.0; Center = point }
let pointX = point.X
let shapeField = positionedShape.Shape
//** #### Value of ``pointX`` *)
//* include-value: ``pointX`` ***)

//** #### Value of ``shapeField`` *)
//* include-value: ``shapeField`` ***)


//#### Deconstructing records *)

let { Shape = shape; Center = { X = x; Y = y } } = positionedShape

//** #### Value of ``x`` *)
//* include-value: ``x`` ***)

//** #### Value of ``shape`` *)
//* include-value: ``shape`` ***)


//#### Record structural equality *)

let shapesAreEqual =
    positionedShape = { Shape = Square 3.0; Center = point }

//** #### Value of ``shapesAreEqual`` *)
//* include-value: ``shapesAreEqual`` ***)


//### Example 2.3
Working with records *)
let withCenterIn point shapes =
    shapes
    |> List.filter (fun shape -> shape.Center = point)

let ``example 2.3`` =
    [ { Shape = Circle (sqrt 2.0); Center = { X = 0.0; Y = 0.0 } }
      { Shape = Square 2.0;        Center = { X = 0.0; Y = 0.0 } }
      { Shape = Rectangle (3.,4.); Center = { X = 0.0; Y = 1.0 } } ]
    |> withCenterIn { X = 0.0; Y = 0.0 }
//** #### Value of ``example 2.3`` *)
//* include-value: ``example 2.3`` ***)

//### Example 2.3.1
Pattern matching with records deconstruction *)
let isCentralGoldenRectangle = function
    | { Shape = Rectangle (width, height); Center = {X = 0.0; Y = 0.0} }
        when abs (width / height - 1.618) < 0.001  -> true
    | _ -> false
let ``example 2.3.1`` =
    [ { Shape = Circle (sqrt 2.0); Center = { X = 0.0; Y = 0.0 } }
      { Shape = Square 2.0;        Center = { X = 0.0; Y = 0.0 } }
      { Shape = Rectangle (1.618, 1.); Center = { X = 5.0; Y = 1.0 } }
      { Shape = Rectangle (1.618, 1.); Center = { X = 0.0; Y = 0.0 } } ]
    |> List.map isCentralGoldenRectangle
//** #### Value of ``example 2.3.1`` *)
//* include-value: ``example 2.3.1`` ***)

//### Exercise 2.3
//##Check if first shape is circumcircle of second shape.
//##First shape must be a circle, second a square or rectangle or circle

//#### --------------- Your code goes below --------------- *)

let isCircumCircle
    (centeredCircle: CenteredShape)
    (centeredShape:  CenteredShape)
    : bool =
    false

let ``exercise 2.3`` =
    [ ( { Shape = Circle (sqrt 2.0); Center = { X = 0.0; Y = 0.0 } },
        { Shape = Square 2.0;        Center = { X = 0.0; Y = 0.0 } } )

      ( { Shape = Circle (sqrt 2.0); Center = { X = 1.0; Y = 0.0 } },
        { Shape = Square 2.0;        Center = { X = 0.0; Y = 0.0 } } )

      ( { Shape = Square 2.5;        Center = { X = 0.0; Y = 0.0 } },
        { Shape = Rectangle (3.,4.); Center = { X = 0.0; Y = 0.0 } } )

      ( { Shape = Circle 2.5;        Center = { X = 0.0; Y = 0.0 } },
        { Shape = Rectangle (3.,4.); Center = { X = 0.0; Y = 1.0 } } ) ]
    |> List.map (fun (first,second) -> isCircumCircle first second)
//** #### Value of ``exercise 2.3`` *)
//* include-value: ``exercise 2.3`` ***)

//### New Stuff 2.4
//#### Record copy-and-update expression *)

let zeroSquare = { Shape = Square 2.0; Center = { X = 0.0; Y = 0.0 } }

let squareMoved =
    { zeroSquare with Center = { X = 2.0; Y = 1.0 } }

let circleWithSameCenter =
    { zeroSquare with Shape = Circle 3.0 }

//** #### Value of ``squareMoved`` *)
//* include-value: ``squareMoved`` ***)

//** #### Value of ``circleWithSameCenter`` *)
//* include-value: ``circleWithSameCenter`` ***)



//### Example 2.4
//##Translate centered shape

let translate (vectorPoint: Point) (shape: CenteredShape) : CenteredShape =
    { shape with Center =
                 { X = shape.Center.X + vectorPoint.X;
                   Y = shape.Center.Y + vectorPoint.Y } }

let ``example 2.4`` =
    [ { Shape = Circle (sqrt 2.0); Center = { X = 0.0; Y = 0.0 } }
      { Shape = Square 2.0;        Center = { X = 0.0; Y = 3.0 } }
      { Shape = Rectangle (3.,4.); Center = { X = 0.0; Y = 1.0 } } ]
    |> List.map (translate { X = -2.0; Y = -3.0 })

//** #### Value of ``example 2.4`` *)
//* include-value: ``example 2.4`` ***)

//### Exercise 2.4
Scale centered shape

//#### --------------- Your code goes below --------------- *)
let scale (magnitude: float) (centeredShape: CenteredShape) : CenteredShape  =
    centeredShape

let ``exercise 2.4`` =
    [ { Shape = Circle (sqrt 2.0); Center = { X = 0.0; Y = 0.0 } }
      { Shape = Square 1.0;        Center = { X = 0.0; Y = 3.0 } }
      { Shape = Rectangle (3.,4.); Center = { X = 0.0; Y = 1.0 } } ]
    |> List.map (scale 2.0)

//** #### Value of ``exercise 2.4`` *)
//* include-value: ``exercise 2.4`` ***)

//### Summary: Product Types (Tuples, Records)

//* Type aliases are used for better understanding of code
//* Tuples represent a **product** of two (or more) types
//* Records also represent **product** of subtypes and provide additional functionality
//* Tuples are fine to represent intermediate results, Records better for modelling


//### Links

//* [Tuples - Multiplying types together](https://fsharpforfunandprofit.com/posts/tuples/) by Scott Wlaschin
//* [Records - Extending tuples with labels](https://fsharpforfunandprofit.com/posts/records/) by Scott Wlaschin


// ##################################### SECTION 3
//## Lists


//### Bowling score kata ([details](http://codingdojo.org/cgi-bin/index.pl?KataBowling))


//### Bowling scoring

(*

    "XXXXXXXXXXXX" // 12 rolls: 12 strikes
    10+10+10 + 10+10+10 + 10+10+10 + 10+10+10 + 10+10+10 + ... = 300

    "9-9-9-9-9-9-9-9-9-9-" // 20 rolls: 10 pairs of 9 and miss
    9 + 9 + 9 + 9 + 9 + 9 + 9 + 9 + 9 + 9 = 90

    "5/5/5/5/5/5/5/5/5/5/5" // 21 rolls: 10 pairs of 5 and spare, with a final 5
    10+5 + 10+5 + 10+5 + 10+5 + 10+5 + ... = 150

    "X9/5/72XXX9-8/9/X"
    10+9+1  + 9+1+5  + 5+5+7 + 7+2   + 10+10+10 +
    10+10+9 + 10+9+0 + 9+0   + 8+2+9 + 9+1+10   = 187

    "X4/2-" // What is the score?

*)

//### New Stuff 3.1
//#### Active patterns *)
let (|Digit|_|) char =
    let zero = System.Convert.ToInt32 '0'
    if System.Char.IsDigit char then
        Some (System.Convert.ToInt32 char - zero)
    else
        None

let digit =
    match '5' with
    | Digit x -> "a digit " + x.ToString()
    | _ -> "not a digit"
//** #### Value of ``digit`` *)
//* include-value: ``digit`` ***)

//### Example 3.1
pattern match on next value and aliases *)
let rec clearPredsOf5 list =
    match list with
    | [] -> []
    | _ :: 5 :: tail -> 0 :: clearPredsOf5 (5 :: tail)
    | x :: rest -> x :: clearPredsOf5 rest

let ``example 3.1`` = clearPredsOf5 ([1..10] @ [5;5;5])
//** #### Value of ``example 3.1`` *)
//* include-value: ``example 3.1`` ***)


//### New stuff 3.2
//#### Symbol alias in pattern matching 

//### Same code as previous with symbol alias 
let rec clearPredsOf5WA list =
    match list with
    | [] -> []
    | _ :: (5 :: _ as rest) -> 0 :: clearPredsOf5WA rest
    | x :: rest -> x :: clearPredsOf5WA rest


//### Exercise 3.1
Implement `parseScore`.

//#### --------------- Your code goes below --------------- *)
let rec parseScore (chars: char list) : int option list =
    []

let ``exercise 3.1`` = parseScore ['X'; '4'; '/'; '2'; '-'; 'N']
//** #### Value of ``exercise 3.1`` *)
//* include-value: ``exercise 3.1`` ***)

//### Exercise 3.2
//##Implement `countScore`

//#### --------------- Your code goes below --------------- *)
let rec countScore (scores: int list) : int =
    0

let ``exercise 3.2`` =
    [ [10; 10; 10; 10; 10; 10; 10; 10; 10; 10; 10; 10]
      [9; 0; 9; 0; 9; 0; 9; 0; 9; 0; 9; 0; 9; 0; 9; 0; 9; 0; 9; 0]
      [5; 5; 5; 5; 5; 5; 5; 5; 5; 5; 5; 5; 5; 5; 5; 5; 5; 5; 5; 5; 5]
      [10; 9; 1; 5; 5; 7; 2; 10; 10; 10; 9; 0; 8; 2; 9; 1; 10] ]
    |> List.map countScore
//** #### Value of ``exercise 3.2`` *)
//* include-value: ``exercise 3.2`` ***)

//### Summary: Lists

//* List are idiomatic for F#
//* Pattern matching combined with recursion allow to represent complex list algorithms in elegant way


//### Links

//* [F# Lists](https://msdn.microsoft.com/en-us/visualfsharpdocs/conceptual/lists-%5Bfsharp%5D) - MSDN
//* [F# Lists](http://www.dotnetperls.com/list-fs) - DotNet Pearls


//### sequenceOpts function *)
let sequenceOpts (optionals: 'a option list) : 'a list option =
    let rec sequence' acc optionals =
        match optionals, acc with
        | [],_ ->
            Option.map List.rev acc
        | Some h :: t, Some acc ->
            sequence' (Some (h :: acc)) t
        | _ ->
            None

    sequence' (Some []) optionals

let oneOption = sequenceOpts [Some "abc"; Some "def"; Some "ghi"]
//** #### Value of ``oneOption`` 
//* include-value: ``oneOption`` 

//### Homework 1
//##Implement `bowlingScore`.

//###Hint: Use `sequenceOpts` to convert from list of options to option of list
let bowlingScore (score: string) : int option =
    Some 0

let ``homework 1`` =
    ["XXXXXXXXXXXX"
     "9-9-9-9-9-9-9-9-9-9-"
     "5/5/5/5/5/5/5/5/5/5/5"
     "X9/5/72XXX9-8/9/X" ]
    |> List.map bowlingScore

//** #### Value of ``homework 1`` *)
//* include-value: ``homework 1`` ***)

//### Homework 2
//###Write new, **tail-recursive** versions of `parseScore` and `countScore`.
//###Implement `bowlingScoreTail` to use those 2 new functions

let rec parseScoreTail
    (chars: char list)
    (acc : int option list)
    : int option list =
    []

let rec countScoreTail (scores: int list) (acc : int) : int =
    0

let bowlingScoreTail (score: string) : int option =
    Some 0

let ``homework 2`` = bowlingScoreTail "XXXXXXXXXXXX"
//** #### Value of ``homework 2`` *)
//* include-value: ``homework 2`` ***)

//## Summary

//* Sum Types (Discriminated Unions)
//* Product Types (Tuples, Records)
//* Lists



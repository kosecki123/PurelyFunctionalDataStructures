module BinaryTreeTest

open BinaryTree
open NUnit.Framework
open Swensen.Unquote

let createNode value = Tree (Empty, value, Empty)
let simpleTree = Tree (createNode(5) , 6, createNode(7))

[<Test>]
let ``isMember given element 4 and singleNode 4 returns true`` () =
    let tree = (createNode 4)
    isMember 4  tree =! true

[<Test>]
let ``isMember given element 8 and simpleTree (does not contain 8) returns false`` () =
    isMember 8 simpleTree =! false

[<Test>]
let ``isMember given element 4 and simpleTree (5 is in left branch) returns true`` () =
    isMember 5 simpleTree =! true

[<Test>]
let ``isMember given element 6 and simpleTree (6 is at the top) returns true`` () =
    isMember 6 simpleTree =! true

[<Test>]
let ``insert given element 9 and simpleTree return tree with 9 added in node 7`` () =
    let result = insert 9 simpleTree
    isMember 9 result =! true

[<Test>]
let ``isMember2 given element 4 and singleNode 4 returns true`` () =
    let tree = (createNode 4)
    isMember2 4  tree =! true

[<Test>]
let ``isMember2 given element 8 and simpleTree (does not contain 8) returns false`` () =
    isMember2 8 simpleTree =! false

[<Test>]
let ``isMember2 given element 4 and simpleTree (5 is in left branch) returns true`` () =
    isMember2 5 simpleTree =! true

[<Test>]
let ``isMember2 given element 6 and simpleTree (6 is at the top) returns true`` () =
    isMember2 6 simpleTree =! true    
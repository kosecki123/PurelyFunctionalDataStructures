module BinaryTreeOpTest

open BinaryTreeOp
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
    isMember 7 result =! true
    isMember 9 result =! true

[<Test>]
let ``mkPerfectTree creates a perfect binary tree with given depth`` () =
     let depth = 4
     let tree = mkPerfectTree 4
     let n = (2 <<< depth) - 1
     
     [ 1..n ]
     |> Seq.iter (fun i -> test <@ isMember i tree @>)
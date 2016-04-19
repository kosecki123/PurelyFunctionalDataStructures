module BinaryTreeTest

open BinaryTree
open NUnit.Framework
open Swensen.Unquote

let singleNode = TreeElement 4
let simpleTree = BinaryTree (TreeElement 4, 6, TreeElement 7)

[<Test>]
let ``treeMember given element 4 and singleNode 4 returns true`` () =
    treeMember 4 singleNode =! true

[<Test>]
let ``treeMember given element 8 and simpleTree (does not contain 8) returns false`` () =
    treeMember 8 simpleTree =! false

[<Test>]
let ``treeMember given element 4 and simpleTree (4 is in left branch) returns true`` () =
    treeMember 4 simpleTree =! true

[<Test>]
let ``treeMember given element 6 and simpleTree (6 is at the top) returns true`` () =
    treeMember 6 simpleTree =! true
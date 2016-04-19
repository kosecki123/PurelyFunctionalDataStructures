module BinaryTreeTest

open BinaryTree
open NUnit.Framework
open Swensen.Unquote

let singleNode = Element 4
let simpleTree = Tree (Element 4, 6, Element 7)

[<Test>]
let ``isMember given element 4 and singleNode 4 returns true`` () =
    isMember 4 singleNode =! true

[<Test>]
let ``isMember given element 8 and simpleTree (does not contain 8) returns false`` () =
    isMember 8 simpleTree =! false

[<Test>]
let ``isMember given element 4 and simpleTree (4 is in left branch) returns true`` () =
    isMember 4 simpleTree =! true

[<Test>]
let ``isMember given element 6 and simpleTree (6 is at the top) returns true`` () =
    isMember 6 simpleTree =! true
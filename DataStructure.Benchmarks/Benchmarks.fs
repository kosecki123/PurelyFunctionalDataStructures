module Benchmarks

open BinaryTree
open BenchmarkDotNet.Attributes
open DataStructure.CSharp

type Bench() =
    let createNode value = Tree (Empty, value, Empty)
    let simpleTree = Tree (createNode(5) , 6, createNode(7))

    let tree = 
        let root = new TreeNode<int>(6)
        root.Left <- new TreeNode<int>(5)
        root.Right <- new TreeNode<int>(7)

        root

    [<Benchmark>]
    member this.FSharpRecursiveIsMember () =
        BinaryTree.isMember 5 simpleTree |> ignore

    [<Benchmark>]
    member this.FSharpRecursiveIsMember2 () =
        BinaryTree.isMember2 5 simpleTree |> ignore

    [<Benchmark>]
    member this.CSharpNonRecursiveIsMember () =
        BinarySearchTree.IsMember(5, tree) |> ignore

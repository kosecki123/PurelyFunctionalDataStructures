module Benchmarks

open BenchmarkDotNet.Attributes
open DataStructure.CSharp

type Bench() =
    let createNode value = BinaryTree.Tree (BinaryTree.Empty, value, BinaryTree.Empty)
    let simpleTree = BinaryTree.Tree (createNode(5) , 6, createNode(7))
    
    let createNodeOp value = BinaryTreeOp.Tree (BinaryTreeOp.Empty, value, BinaryTreeOp.Empty)
    let simpleTreeOp = BinaryTreeOp.Tree (createNodeOp(5) , 6, createNodeOp(7))

    let tree = 
        let root = new BinaryTree<int>(6)
        root.Left <- new BinaryTree<int>(5)
        root.Right <- new BinaryTree<int>(7)

        root

    [<Benchmark>]
    member this.MkPerfectTree () =
        BinaryTree.mkPerfectTree 5 |> ignore

    [<Benchmark>]
    member this.MkPerfectTreeOp () =
        BinaryTreeOp.mkPerfectTree 5 |> ignore

    [<Benchmark>]
    member this.FSharpRecursiveIsMember () =
        BinaryTree.isMember 5 simpleTree |> ignore

    [<Benchmark>]
    member this.FSharpRecursiveIsMember2 () =
        BinaryTreeOp.isMember 5 simpleTreeOp |> ignore

    [<Benchmark>]
    member this.CSharpNonRecursiveIsMember () =
        BinarySearchTree.IsMember(5, tree) |> ignore

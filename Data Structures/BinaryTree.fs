module BinaryTree

type BinaryTree<'a when 'a : comparison> = 
    | Empty
    | Tree of BinaryTree<'a> * 'a * BinaryTree<'a>

// 2d comparisons
let rec isMember (element : 'a) (tree : BinaryTree<'a>) = 
    match tree with
    | Empty -> false
    | Tree(left, top, right) -> 
        if top < element then isMember element right
        else if top > element then isMember element left
        else true

// 2d comparisons
let rec insert (element : 'a) (tree : BinaryTree<'a>) = 
    match tree with
    | Empty -> Tree(Empty, element, Empty)
    | Tree(left, top, right) -> 
        if top < element then Tree(left, top, insert element right)
        else if top > element then Tree(insert element left, top, right)
        else tree

let mkPerfectTree depth = 
    let n = (2 <<< depth) - 1
    let root = (n - 1) / 2
    [ 1..n ] |> List.fold (fun acc i -> insert i acc) (Tree(Empty, root, Empty))

module BinaryTreeOp

type BinaryTree<'a when 'a : comparison> = 
    | Empty
    | Tree of BinaryTree<'a> * 'a * BinaryTree<'a>

// d + 1 comparisons
let isMember (element : 'a) (tree : BinaryTree<'a>) = 
    let rec isMemberRec (element : 'a) (candidate : 'a) (tree : BinaryTree<'a>) = 
        match tree with
        | Empty -> candidate = element
        | Tree(left, top, right) -> 
            if top < element then isMemberRec element candidate right
            else isMemberRec element top left
    
    match tree with
    | Tree(_, top, _) -> isMemberRec element top tree
    | _ -> raise (System.Exception "Fuck you")

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
    
    let split (coll : 'a list) = 
        let index = (coll.Length - 1) / 2
        List.splitAt index coll
        |> function (l,(t::r)) -> (l, t, r)
    
    let rec tree (left, top, right : 'a list) = 
        let buildTree = 
            match (left, top, right) with
            | ([ _ ], _, [ _ ]) -> fun v -> Tree(Empty, v |> List.head, Empty)
            | _ -> split >> tree
        Tree(left |> buildTree, top, right |> buildTree)
    
    [ 1..n ]
    |> split
    |> tree
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
        if top < element then insert element right
        else if top > element then insert element left
        else tree

// d + 1 comparisons
let isMember2 (element : 'a) (tree : BinaryTree<'a>) = 
    let rec isMember2 (element : 'a) (candidate : 'a) (tree : BinaryTree<'a>) = 
        match tree with
        | Empty -> candidate = element
        | Tree(left, top, right) -> 
            if top < element then isMember2 element candidate right
            else isMember2 element top left
    
    let top tree = 
        match tree with
        | Tree(_, top, _) -> top
        | _ -> raise (System.Exception "Fuck you")
    
    isMember2 element (top tree) tree

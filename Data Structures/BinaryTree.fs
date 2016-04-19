module BinaryTree

type BinaryTree<'a when 'a:comparison> = 
    | Empty
    | Tree of BinaryTree<'a> * 'a * BinaryTree<'a>

let rec isMember (element :'a) (tree :BinaryTree<'a>) =
    match tree with 
    | Empty -> false
    | Tree (left, top, right) -> 
        if top < element then isMember element right
        else if top > element then isMember element left
        else true
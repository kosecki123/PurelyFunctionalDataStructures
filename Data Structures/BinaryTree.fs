module BinaryTree

type Tree<'a when 'a:comparison> = 
    | TreeElement of 'a
    | BinaryTree of Tree<'a> * 'a * Tree<'a>

let rec treeMember (element :'a) (tree :Tree<'a>) =
    match tree with 
    | TreeElement a -> a = element
    | BinaryTree (left, top, right) -> 
        if top < element then treeMember element right
        else if top > element then treeMember element left
        else true
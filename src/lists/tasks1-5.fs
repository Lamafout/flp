open System

let readList n =
    let rec readListRec n acc =
        match n with
        | 0 -> acc
        | k -> 
            let el = Console.ReadLine() |> int
            let newAcc = acc@[el]
            readListRec (k - 1) newAcc
    readListRec n []

let rec printList list =
    match list with
    | [] -> Console.ReadKey()
    | head::tail ->
        Console.WriteLine(head.ToString())
        printList tail

let rec reduceRec list (f: int -> int -> int) (predicate: int -> bool) acc =
    match list with
    | [] -> acc
    | head :: tail ->
        let newAcc = if predicate head then f acc head else acc
        reduceRec tail f predicate newAcc

let min list =
    let answer = reduceRec list (fun x y -> if x < y then x else y) (fun _ -> true) 100000000
    answer

let count list =
    let answer = reduceRec list (fun x y -> x + 1) (fun y -> y % 2 > 0) 0
    answer

[<EntryPoint>]
let main  argv =
    let arr = readList 5
    printList arr
    Console.WriteLine(count arr)
    0

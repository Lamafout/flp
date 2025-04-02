open System

let rec findMinIndexChurch list index minIndex minValue =
    match list with
    | [] -> minIndex
    | head :: tail ->
        if head < minValue then
            findMinIndexChurch tail (index + 1) index head
        else
            findMinIndexChurch tail (index + 1) minIndex minValue

let rec toChurchList lst =
    match lst with
    | [] -> fun f acc -> acc
    | x::xs -> fun f acc -> f x (toChurchList xs f acc)

let findMinIndexList lst =
    let rec aux lst index minIndex minValue =
        match lst with
        | [] -> minIndex
        | x::xs ->
            if x < minValue then
                aux xs (index + 1) index x
            else
                aux xs (index + 1) minIndex minValue
    match lst with
    | [] -> failwith "Empty list"
    | x::xs -> aux xs 1 0 x

[<EntryPoint>]
let main argv =
    let inputList = [3; 1; 4; 1; 5; 9; 2; 6; 5; 3; 5]
    let churchList = toChurchList inputList
    let minIndexChurch = findMinIndexChurch inputList 0 0 (List.head inputList)
    let minIndexList = findMinIndexList inputList
    printfn "Минимальный индекс (Church): %d" minIndexChurch
    printfn "Минимальный индекс (List): %d" minIndexList
    0

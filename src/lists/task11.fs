open System

let rec minIndexChurch (list: int list) (minVal: int) (minIdx: int) (currIdx: int) =
    match list with
    | [] -> minIdx
    | head :: tail ->
        let newMinVal, newMinIdx = if head < minVal then head, currIdx else minVal, minIdx
        minIndexChurch tail newMinVal newMinIdx (currIdx + 1)

let findMinIndexChurch list =
    match list with
    | [] -> -1
    | head :: tail -> minIndexChurch tail head 0 1

let findMinIndexList (list: int list) =
    match list with
    | [] -> -1
    | _ -> list |> List.mapi (fun i x -> (i, x)) |> List.minBy (fun (i, x) -> x) |> fst

[<EntryPoint>]
let main argv =
    let testList = [5; 2; 8; 1; 9]
    let resultChurch = findMinIndexChurch testList
    let resultList = findMinIndexList testList
    Console.WriteLine("Church method result: " + resultChurch.ToString())
    Console.WriteLine("List method result: " + resultList.ToString())
    0
open System

let mostFrequent (list: 'a list) =
    match list with
    | [] -> failwith "Empty List"
    | _ ->
        list
        |> List.groupBy id
        |> List.map(fun (key, group) -> (key, List.length group))
        |> List.maxBy snd
        |> fst

[<EntryPoint>]
let main argv =
    let myList = [1; 2; 3; 2; 4; 2; 5; 3; 2]
    try
        let result = mostFrequent myList
        printfn "Список: %A" myList
        printfn "Самый частый элемент: %d" result
    with
    | :? System.Exception as e -> printfn "Ошибка: %s" e.Message
    0
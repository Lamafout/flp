open System

let sumOfDigits (n: int) =
    let absN = abs n
    let rec sumDigits acc num =
        if num = 0 then acc
        else sumDigits (acc + (num % 10)) (num / 10)
    sumDigits 0 absN

let countDivisors (n: int) =
    let absN = abs n
    let rec count d limit =
        if d > limit then 0
        else if absN % d = 0 then
            let pair = if d * d = absN then 1 else 2 
            pair + count (d + 1) (absN / d)
        else
            count (d + 1) limit
    if absN = 0 then 0 else count 1 absN


let buildTuples (listA: int list) (listB: int list) (listC: int list) =
    let sortedA = listA |> List.sortByDescending id
    
    let sortedB = listB |> List.sortBy (fun x -> (sumOfDigits x, abs x))
    
    let sortedC = listC |> List.sortByDescending (fun x -> (countDivisors x, abs x))
    
    let minLength = List.min [List.length sortedA; List.length sortedB; List.length sortedC]
    
    List.zip3
        (sortedA |> List.take minLength)
        (sortedB |> List.take minLength)
        (sortedC |> List.take minLength)

[<EntryPoint>]
let main argv =
    let listA = [5; 2; 8; 1; 9]
    let listB = [12; 3; 45; 7; -13]
    let listC = [6; 15; 8; 4; 10]
    
    let result = buildTuples listA listB listC
    printfn "Список A: %A" listA
    printfn "Список B: %A" listB
    printfn "Список C: %A" listC
    printfn "Результат: %A" result
    0
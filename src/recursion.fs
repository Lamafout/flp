open System

let rec sumDigitsUp num =
    if num = 0 then 0
    else (num % 10) + (sumDigitsUp (num / 10))

let sumDigitsDown num =
    let rec sumDigitsDownLoop num current =
        if num = 0 then current
        else sumDigitsDownLoop (num / 10) (current + (num % 10))
    sumDigitsDownLoop num 0

[<EntryPoint>]
let main argv =
    let num = Console.ReadLine() |> int
    printfn "Результат путём рекурсии вверх: %d" (sumDigitsUp num)
    printfn "Результат путём рекурсии вниз: %d" (sumDigitsDown num)
    0
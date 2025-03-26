open System

let circleArea radius = Math.PI * radius * radius

let cylinderVolume radius height = circleArea radius * height

[<EntryPoint>]
let main argv = 
    let inputedRadius = Console.ReadLine() |> float
    let inputedHeight = Console.ReadLine() |> float
    printfn "Answer: %f" (cylinderVolume inputedRadius inputedHeight)
    0
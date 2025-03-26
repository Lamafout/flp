open System

let circleArea radius = Math.PI * radius * radius

let multipleArea area height = area * height 

let cylinderVolume = circleArea >> multipleArea 

[<EntryPoint>]
let main argv = 
    let inputedRadius = Console.ReadLine() |> float
    let inputedHeight = Console.ReadLine() |> float
    let volume = cylinderVolume inputedRadius inputedHeight
    printfn "Answer: %f" volume
    0
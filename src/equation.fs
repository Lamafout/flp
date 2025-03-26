module EquationSolver

let solve (a, b, c) = 
    let D = (b * b) - (4.0 * a * c) in
        ((-b + sqrt(D)) / (2.0 * a), (-b - sqrt(D)) / (2.0 * a))

[<EntryPoint>]
let main argv =
    printfn "Answer: %f, %f" (fst(solve (1.0, 5.0, 4.0))) (snd(solve (1.0, 5.0, 4.0)))
    0

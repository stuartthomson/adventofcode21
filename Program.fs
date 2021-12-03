// Learn more about F# at http://docs.microsoft.com/dotnet/fsharp

open System
open Loaders
open Day1
open Day2

[<EntryPoint>]
let main argv =

    let result = day2part1()
    printfn "Result part 1 is %i" result

    let result2 = day2part2()
    printfn "Result part 2 is %i" result2

    0 // return an integer exit code
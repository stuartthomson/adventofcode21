// Learn more about F# at http://docs.microsoft.com/dotnet/fsharp

open System
open Loaders
open Day1
open Day2
open Day3

[<EntryPoint>]
let main argv =

    let result = day3part1()
    printfn "%s" <| result.ToString()

    printfn "Result part 1 is %i" result

    0 // return an integer exit code
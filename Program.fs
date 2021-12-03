// Learn more about F# at http://docs.microsoft.com/dotnet/fsharp

open System

//-------------------------------------------------------------------------------------------------
// Load a file as a list of integers
//-------------------------------------------------------------------------------------------------
let readAsInts filename =
    IO.File.ReadAllLines(filename) |> Seq.map(fun line -> int line)

//-------------------------------------------------------------------------------------------------
// Count the number of times a sequence increases
//-------------------------------------------------------------------------------------------------
let countIncreases numbers =
    numbers
    |> Seq.windowed 2
    |> Seq.where (fun pair -> pair.[1] > pair.[0])
    |> Seq.length

//-------------------------------------------------------------------------------------------------
// Read the input and count the number of times it increases
//-------------------------------------------------------------------------------------------------
let day1part1 () =
    readAsInts("./inputs/1.txt")
    |> countIncreases

//-------------------------------------------------------------------------------------------------
// Read the input and calculate length 3 sums of the input, count increases
//-------------------------------------------------------------------------------------------------
let day1part2 () =
    readAsInts("./inputs/1.txt")
    |> Seq.windowed 3
    |> Seq.map(fun window -> Seq.sum window)
    |> countIncreases

[<EntryPoint>]
let main argv =

    let result = day1part1()
    printfn "Result part 1 is %i" result

    let result2 = day1part2()
    printfn "Result part 2 is %i" result2

    0 // return an integer exit code
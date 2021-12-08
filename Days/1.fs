// A comment
module Day1
    open Loaders

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

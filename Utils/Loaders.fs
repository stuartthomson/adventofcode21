module Loaders

    open System

    //-------------------------------------------------------------------------------------------------
    // Load a file as a list of integers
    //-------------------------------------------------------------------------------------------------
    let readAsInts filename =
        IO.File.ReadAllLines(filename) |> Seq.map(fun line -> int line)

    //---------------------------------------------------------------------------------------------
    // Load a file as a list of strings
    //---------------------------------------------------------------------------------------------
    let readAsStrings = IO.File.ReadAllLines
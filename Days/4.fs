// Day 4
module Day4
    open Loaders

    type Square =
        struct
            val number: int
            val checked: bool

            new (number: string) = {number = int number; checked = false}
        end

    type BingoCard =
        struct
            val state: Square[,]
            new (state: string[][]) = { state = state |> array2D |> Array2D.map (fun number -> new Square(number)) }

        end

    let parseHeader(fileContents: string[]) =
        fileContents
            |> Seq.head
            |> fun line -> line.Split(',')
            |> Seq.map int
            |> Seq.toArray

    let parseBingo(fileContents: string[]) =
        // todo: I need to split on whitespace at some point!!

        // each of these is a list of 5 strings, one for each line
        let chunks =
            fileContents
            |> Seq.skip 1          // skip the header
            |> Seq.chunkBySize 6   // Each bingo card is 5 lines, plus one whitespace
            |> Seq.map Seq.tail    // Remove the whitespace line
            |> Seq.map Seq.toArray

        chunks
            |> Seq.map Seq.map Seq.chunkBySize 2



    let day4part1 () =
        let fileContents = readAsStrings("./inputs/4.txt")

        let numbers =
            fileContents
            |> Seq.head
            |> fun line -> line.Split(',')
            |> Seq.map int
            |> Seq.toArray

        numbers.[1]

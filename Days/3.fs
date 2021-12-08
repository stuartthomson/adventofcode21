// Day 3
module Day3
    open Loaders

    let invert (digit: int) =
        match digit with
        | 1 -> 0
        | 0 -> 1
        | _ -> raise <| new System.ArgumentException("invalid digit")

    let toDecimal(digits: list<int>) =
        let stringRep =
            digits
            |> List.map (sprintf "%i")
            |> String.concat ""

        System.Convert.ToInt64(stringRep, 2)

    type BitState =
        struct
            val counter: list<int>
            val length: int
            new (size: int) = {counter = [for _ in 1..size -> 0]; length = 0}
            new (counter: list<int>, length: int) = {counter = counter; length = length}

            member this.mostCommonBit(bitValue: int) =
                match bitValue > (this.length/2) with
                | true -> 1
                | false -> 0

            member this.gammaBinary() =
                List.map this.mostCommonBit this.counter

            member this.epsilonBinary() =
                this.gammaBinary()
                |> List.map invert

            member this.gammaDecimal() =
                toDecimal(this.gammaBinary())

            member this.epsilonDecimal() =
                toDecimal(this.epsilonBinary())
        end

    let countBits(bitState: BitState)(bitString: string) =
        let bits =
            Seq.toList bitString
            |> List.map System.Globalization.CharUnicodeInfo.GetDigitValue

        BitState(
            List.map2 (+) bitState.counter bits,
            bitState.length + 1
        )

    let day3part1 () =
        let bits = new BitState(12)

        let thing =
            readAsStrings("./inputs/3.txt")
            |> Seq.fold countBits bits

        thing.gammaDecimal() * thing.epsilonDecimal()
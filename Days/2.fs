// Day 2
module Day2
    open Loaders

    //---------------------------------------------------------------------------------------------
    // The possible moves
    //---------------------------------------------------------------------------------------------
    let [<Literal>] Forward = "forward"
    let [<Literal>] Backward = "backward"
    let [<Literal>] Up = "up"
    let [<Literal>] Down = "down"
    type Direction = Forward | Backward | Up | Down

    let matchDirection (word: string): Direction =
        match word with
        | "forward"  -> Forward
        | "backward" -> Backward
        | "up"       -> Up
        | "down"     -> Down
        | _          -> raise <| new System.ArgumentException("Invalid instruction")

    //---------------------------------------------------------------------------------------------
    // The position of the submarine
    //---------------------------------------------------------------------------------------------
    type SubPosition =
        struct
            val depth: int
            val position: int
            val aim: int

            new(depth: int, position: int) = {depth = depth; position = position; aim = 0}
            new(depth: int, position: int, aim: int) = {depth = depth; position = position; aim = aim}
        end

    // Instructions like "forward 5"
    let parseInstruction(instruction: string) =
        let pieces = instruction.Split(" ")
        (matchDirection(pieces.[0]), int pieces.[1])

    // note the curried type
    let moveSubPart1(subPosition: SubPosition)(instruction: string) =
        let (direction, amount) = parseInstruction instruction
        match direction with
        | Forward  -> new SubPosition(subPosition.depth, subPosition.position + amount)
        | Backward -> new SubPosition(subPosition.depth, subPosition.position - amount)
        | Up       -> new SubPosition(subPosition.depth - amount, subPosition.position)
        | Down     -> new SubPosition(subPosition.depth + amount, subPosition.position)

    let moveSubPart2(sub: SubPosition)(instruction: string) =
        let (direction, amount) = parseInstruction instruction
        match direction with
        | Forward  -> new SubPosition(sub.depth + (amount*sub.aim), sub.position + amount, sub.aim)
        | Backward -> new SubPosition(sub.depth - (amount*sub.aim), sub.position - amount, sub.aim)
        | Up       -> new SubPosition(sub.depth, sub.position, sub.aim - amount)
        | Down     -> new SubPosition(sub.depth, sub.position, sub.aim + amount)

    let day2part1 () =
        let position = new SubPosition()

        let newPosition =
            readAsStrings("./inputs/2.txt")
            |> Seq.fold moveSubPart1 position

        newPosition.depth * newPosition.position

    let day2part2 () =
        let position = new SubPosition()

        let newPosition =
            readAsStrings("./inputs/2.txt")
            |> Seq.fold moveSubPart2 position

        newPosition.depth * newPosition.position
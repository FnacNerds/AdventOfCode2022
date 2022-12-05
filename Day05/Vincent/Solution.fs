namespace AdventOfCode2022.Day05

open AdventOfCode2022.Common
open Microsoft.FSharp.Core
open FSharp.Core.Operators.Checked

[<RequireQualifiedAccess>]
module Solution =

    let pop1 (count: int) (list: 'a list) : 'a list * 'a list =
        let rec loop count list acc =
            match count, list with
            | 0, _ -> (acc, list)
            | _, [] -> (acc, [])
            | _, x :: xs -> loop (count - 1) xs (x :: acc)

        loop count list []

    let pop2 (count: int) (list: 'a list) : 'a list * 'a list =
        list |> List.take count, list |> List.skip count

    let solution popFunction input =
        let data = DataParser.parse input

        let rec performMoves (moves: Move list) (stacks: Stack list) : Stack list =
            match moves with
            | [] -> stacks
            | move :: otherMoves ->
                let _, stackToPickFrom = stacks |> List.item move.Origin.Value
                let unstacked, newList = popFunction move.Count stackToPickFrom

                let newStacks = [
                    for stackId, items as original in stacks do
                        if stackId = move.Origin then
                            (stackId, newList)
                        elif stackId = move.Destination then
                            (stackId, unstacked @ items)
                        else
                            original
                ]

                performMoves otherMoves newStacks

        performMoves data.Moves data.Stacks
        |> List.map (snd >> List.head >> CrateId.value)
        |> String.ofSeq

    let part1 = solution pop1
    let part2 = solution pop2

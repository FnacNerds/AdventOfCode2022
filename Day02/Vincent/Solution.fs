namespace AdventOfCode2022.Day02

open AdventOfCode2022.Common
open Microsoft.FSharp.Core
open FSharp.Core.Operators.Checked

[<Measure>]
type score

[<RequireQualifiedAccess>]
module Solution =

    let calculateScore outcome =
        let ``score for sharpe I selected`` =
            match outcome.MyPlay with
            | Rock -> 1<score>
            | Paper -> 2<score>
            | Scissors -> 3<score>

        let ``score for game result`` =
            match outcome.Result with
            | Win -> 6<score>
            | Draw -> 3<score>
            | Loss -> 0<score>

        ``score for sharpe I selected`` + ``score for game result``


    let part1 input =

        input
        |> DataParser.parse
        |> List.mapSnd (function
            | Y -> Paper
            | X -> Rock
            | Z -> Scissors)
        |> List.mapFst' RockPaperScissors.fight
        |> List.map (GameOutcome.init' >> calculateScore)
        |> List.sum

    let part2 input =

        let getMatchingPlay (opponent: RockPaperScissors, expectedOutcome) =
            match expectedOutcome with
            | Draw -> opponent
            | Win -> opponent.nemesis
            | Loss -> opponent.slave

        input
        |> DataParser.parse
        |> List.mapSnd (function
            | X -> Loss
            | Y -> Draw
            | Z -> Win)
        |> List.mapFst' getMatchingPlay
        |> List.map (GameOutcome.init >> calculateScore)
        |> List.sum

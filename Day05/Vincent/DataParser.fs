namespace AdventOfCode2022.Day05

open FParsec
open AdventOfCode2022.Common.FParsec
open AdventOfCode2022.Day05

[<RequireQualifiedAccess>]
module DataParser =

    let space = skipChar ' '
    let skipNewlines c = skipArray c skipNewline

    let parseStackId =
        (pchar '1' >>% StackId 0)
        <|> (pchar '2' >>% StackId 1)
        <|> (pchar '3' >>% StackId 2)
        <|> (pchar '4' >>% StackId 3)
        <|> (pchar '5' >>% StackId 4)
        <|> (pchar '6' >>% StackId 5)
        <|> (pchar '7' >>% StackId 6)
        <|> (pchar '8' >>% StackId 7)
        <|> (pchar '9' >>% StackId 8)

    let parseCrate =
        (pstring "   " >>% None)
        <|> (pipe3 (skipChar '[') anyChar (skipChar ']') (fun _ c _ -> Some(CrateId c)))

    let parseCrateLine = sepBy1 parseCrate space

    let parseCrates = backtrackingSepBy1 parseCrateLine newline

    let parseStackIds = sepBy1 ((space >>. parseStackId) .>> space) space

    let parseCratesMapping =
        pipe2
            (parseCrates .>> newline)
            parseStackIds
            (fun crates stackIds ->
                List.zip stackIds (crates |> List.transpose |> List.map (List.choose id))
                |> List.map Stack
            )

    let parseMove =
        pipe3
            ((skipString "move ") >>. pint32)
            ((skipString " from ") >>. parseStackId)
            ((skipString " to ") >>. parseStackId)
            Move.init

    let parseMoves = sepBy1 parseMove newline

    let parseContents =
        pipe2 (parseCratesMapping .>> (skipNewlines 2)) parseMoves Data.init

    let parse = (run (parseContents .>> eof)) >> unwrap

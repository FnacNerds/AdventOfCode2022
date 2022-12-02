namespace AdventOfCode2022.Day02

open FParsec
open AdventOfCode2022.Common.FParsec
open AdventOfCode2022.Day02

[<RequireQualifiedAccess>]
module DataParser =

    let ``parse opponent's play`` =
        (pchar 'A' >>% Rock) <|> (pchar 'B' >>% Paper) <|> (pchar 'C' >>% Scissors)

    let ``parse expected play result`` =
        (pchar 'X' >>% X) <|> (pchar 'Y' >>% Y) <|> (pchar 'Z' >>% Z)

    let ``parse line`` =
        ``parse opponent's play`` .>> skipChar ' ' .>>. ``parse expected play result``

    let ``parse contents`` = sepBy1 ``parse line`` newline
    let parse = (run (``parse contents`` .>> eof)) >> unwrap

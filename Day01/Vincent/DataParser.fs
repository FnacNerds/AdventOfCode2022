namespace AdventOfCode2022.Day01

open FParsec
open AdventOfCode2022.Common.FParsec

[<RequireQualifiedAccess>]
module DataParser =

    let parseSequence = backtrackingSepBy1 pint32 newline

    let parseContents = sepBy1 parseSequence (newLines 2)

    let parse = (run (parseContents .>> eof)) >> unwrap

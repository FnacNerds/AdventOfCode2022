namespace AdventOfCode2022.Day04

open FParsec
open AdventOfCode2022.Common.FParsec
open AdventOfCode2022.Day04

[<RequireQualifiedAccess>]
module DataParser =

    let parseSegment = pipe2 (pint32 .>> skipChar '-') pint32 Segment.init

    let parseLine = pipe2 (parseSegment .>> skipChar ',') parseSegment Assignment.init

    let parseContents = sepBy1 parseLine newline

    let parse = (run (parseContents .>> eof)) >> unwrap

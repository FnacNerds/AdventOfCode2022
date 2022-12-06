namespace AdventOfCode2022.Day06

open FParsec
open AdventOfCode2022.Common.FParsec

[<RequireQualifiedAccess>]
module DataParser =

    let parse = (run (many1 (many1CharsTill anyChar (skipNewline <|> eof)))) >> unwrap

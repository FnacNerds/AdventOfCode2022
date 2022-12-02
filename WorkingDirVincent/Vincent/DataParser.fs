namespace AdventOfCode2022.{{{Project}}}

open FParsec
open AdventOfCode2022.Common.FParsec
open FSharp.Core.Operators.Checked
open AdventOfCode2022.{{{Project}}}

[<RequireQualifiedAccess>]
module DataParser =

    let parseContents = fail "Not implemented"
    
    let parse = (run (parseContents .>> eof)) >> unwrap

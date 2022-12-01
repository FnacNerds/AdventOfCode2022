namespace AdventOfCode2022.Day01

open AdventOfCode2022.Common
open Microsoft.FSharp.Core

[<RequireQualifiedAccess>]
module Solution =

    let part1 = DataParser.parse >> Seq.map Seq.sum >> Seq.max

    let part2 =
        DataParser.parse
        >> Seq.map Seq.sum
        >> Seq.sortDescending
        >> Seq.take 3
        >> Seq.sum

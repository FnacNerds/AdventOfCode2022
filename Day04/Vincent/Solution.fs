namespace AdventOfCode2022.Day04

open AdventOfCode2022.Common
open Microsoft.FSharp.Core

[<RequireQualifiedAccess>]
module Solution =

    let solution f = DataParser.parse >> Seq.countWhere f

    let part1 =
        solution (fun a ->
            (a.Elf1.Start <= a.Elf2.Start && a.Elf2.Stop <= a.Elf1.Stop)
            || (a.Elf1.Start >= a.Elf2.Start && a.Elf2.Stop >= a.Elf1.Stop)
        )

    let part2 =
        solution (fun a -> a.Elf1.Stop >= a.Elf2.Start && a.Elf2.Stop >= a.Elf1.Start)

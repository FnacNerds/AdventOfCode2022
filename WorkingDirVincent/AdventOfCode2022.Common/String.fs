namespace AdventOfCode2022.Common

[<RequireQualifiedAccess>]
module String =
    let trim (s: string) : string = s.Trim()
    let ofSeq (c: char seq) : string = c |> Seq.toArray |> System.String

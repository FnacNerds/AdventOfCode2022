namespace AdventOfCode2022.Common

[<RequireQualifiedAccess>]
module Seq =
    let countWhere (predicate: 'T -> bool) (seq: 'T seq) =
        seq |> Seq.filter predicate |> Seq.length

    let groupByFst list =
        list |> Seq.groupBy fst |> Seq.map (fun (a, b) -> (a, (b |> Seq.map snd)))

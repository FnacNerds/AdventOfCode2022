namespace AdventOfCode2022.Day06

open AdventOfCode2022.Common
open Microsoft.FSharp.Core
open FSharp.Core.Operators.Checked

[<RequireQualifiedAccess>]
module Solution =

    let solve size lst =
        let index =
            lst
            |> Seq.windowed size
            |> Seq.mapi Tuple2.init
            |> Seq.find (fun (_, items) -> items |> Seq.distinct |> Seq.length = size)
            |> fst

        index + size


    
    let part1 = DataParser.parse >> List.map (solve 4)
    let part2 = DataParser.parse >> List.map (solve 14)

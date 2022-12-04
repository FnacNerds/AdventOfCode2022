namespace AdventOfCode2022.Day03

open AdventOfCode2022.Common
open Microsoft.FSharp.Core
open FSharp.Core.Operators.Checked

[<RequireQualifiedAccess>]
module Solution =

    let itob i = 1UL <<< i

    let btoi b =
        let rec btoi' b index =
            if b &&& 1UL = 1UL then
                index
            else
                btoi' (b >>> 1) (index + 1)

        (btoi' b 0)

    let part1 =
        DataParser.parse
        >> Seq.map (
            (Seq.map itob >> Seq.toArray)
            >> (fun a ->
                let halfIndex = a.Length / 2

                [ 0 .. (halfIndex - 1) ]
                |> Seq.fold (fun (left, right) index -> (left ||| a[index], right ||| a[index + halfIndex])) (0UL, 0UL)
            )
            >> Tuple.join (&&&)
            >> btoi
        )
        >> Seq.sum

    let part2 =
        DataParser.parse
        >> Seq.map ((Seq.map itob) >> Seq.reduce (|||))
        >> Seq.chunkBySize 3
        >> Seq.map (Seq.reduce (&&&) >> btoi)
        >> Seq.sum

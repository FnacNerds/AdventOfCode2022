namespace AdventOfCode2022.Common

[<RequireQualifiedAccess>]
module Array =
    let mapTuple f = Array.map (fun a -> (a, f a))

    let splitInHalf arr =
        (Array.sub arr 0 (arr.Length / 2), Array.sub arr (arr.Length / 2) (arr.Length / 2))

    let increment (arr: int array) (index: int) : int array =
        arr[index] <- arr.[index] + 1
        arr

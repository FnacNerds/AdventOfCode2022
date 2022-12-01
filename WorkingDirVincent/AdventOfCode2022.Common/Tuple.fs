namespace AdventOfCode2022.Common

[<RequireQualifiedAccess>]
module Tuple =
    let map f (a, b) = (f a, f b)
    let join f (a, b) = f a b

[<RequireQualifiedAccess>]
module Tuple2 =
    let inline apply2 f (x1, x2) (y1, y2) = (f x1 y1, f x2 y2)

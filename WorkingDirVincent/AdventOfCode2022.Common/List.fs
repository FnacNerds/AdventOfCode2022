namespace AdventOfCode2022.Common

[<RequireQualifiedAccess>]
module List =
    let fold0 f l = l |> List.fold (fun s i -> f (s, i)) 0
    let mapTuple f = List.map (fun a -> (a, f a))

    let mapTupleResult f =
        List.map (fun a ->
            match f a with
            | Ok b -> Ok(a, b)
            | Error(e) -> Error(e)
        )

    let groupByFst list =
        list |> List.groupBy fst |> List.map (fun (a, b) -> (a, (b |> List.map snd)))

    let mapSnd f list =
        list |> List.map (fun (a, b) -> (a, f b))

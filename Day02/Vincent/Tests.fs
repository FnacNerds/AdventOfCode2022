namespace AdventOfCode2022.Day02

open NUnit.Framework
open FSharp.Data.LiteralProviders
open FsUnit

[<Timeout(2000)>]
module Tests =

    type sample = TextFile.data.sample
    type input = TextFile.data.input

    let [<Test>] ``Test 1.1`` () = Solution.part1 sample.Text |> should equal 15
    let [<Test>] ``Test 1.2`` () = Solution.part1 input.Text |> should equal 14264
    let [<Test>] ``Test 2.1`` () = Solution.part2 sample.Text |> should equal 12
    let [<Test>] ``Test 2.2`` () = Solution.part2 input.Text |> should equal 12382
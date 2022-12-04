namespace AdventOfCode2022.{{{Project}}}

open NUnit.Framework
open FSharp.Data.LiteralProviders
open FSharp.Core.Operators.Checked
open FsUnit

[<Timeout(2000)>]
module Tests =

    type sample = TextFile.data.sample
    type input = TextFile.data.input

    let [<Test>] ``Test 1.1`` () = Solution.part1 sample.Text |> should equal -1
    let [<Test>] ``Test 1.2`` () = Solution.part1 input.Text |> should equal -1
    let [<Test>] ``Test 2.1`` () = Solution.part2 sample.Text |> should equal -1
    let [<Test>] ``Test 2.2`` () = Solution.part2 input.Text |> should equal -1
namespace AdventOfCode2022.Day01

open NUnit.Framework
open FSharp.Data.LiteralProviders
open FsUnit

module Tests =

    type sample = TextFile.data.sample
    type input = TextFile.data.input

    let [<Test>] ``Test 1.1`` () = Solution.part1 sample.Text |> should equal 24000
    let [<Test>] ``Test 1.2`` () = Solution.part1 input.Text |> should equal 64929 
    let [<Test>] ``Test 2.1`` () = Solution.part2 sample.Text |> should equal 45000 
    let [<Test>] ``Test 2.2`` () = Solution.part2 input.Text |> should equal 193697

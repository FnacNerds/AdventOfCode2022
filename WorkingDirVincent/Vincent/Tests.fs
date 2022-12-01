namespace AdventOfCode2022.{{{Project}}}

open Swensen.Unquote
open NUnit.Framework
open FSharp.Data.LiteralProviders
open FSharp.Core.Operators.Checked

[<Timeout(2000)>]
module Tests =

    type sample = TextFile.data.sample
    type input = TextFile.data.input

    let [<Test>] ``Test 1.1`` () = test <@ (Solution.part1 sample.Text) = TODO @>
    let [<Test>] ``Test 1.2`` () = test <@ (Solution.part1 input.Text) = TODO @>
    let [<Test>] ``Test 2.1`` () = test <@ (Solution.part2 sample.Text) = TODO @>
    let [<Test>] ``Test 2.2`` () = test <@ (Solution.part2 input.Text) = TODO @>

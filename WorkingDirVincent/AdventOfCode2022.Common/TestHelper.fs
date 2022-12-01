namespace AdventOfCode2022.Common

open NUnit.Framework

[<RequireQualifiedAccess>]
module TestHelper =
    let run
        ((part1: 'input -> 'output1, (expectedS1: 'output1, expectedI1: 'output1)),
         (part2: 'input -> 'output2, (expectedS2: 'output2, expectedI2: 'output2)))
        (sample: 'input, input: 'input)
        =
        Assert.AreEqual(expectedS1, (part1 sample), "Part 1 - sample")
        Assert.AreEqual(expectedI1, (part1 input), "Part 1 - input")
        Assert.AreEqual(expectedS2, (part2 sample), "Part 2 - sample")
        Assert.AreEqual(expectedI2, (part2 input), "Part 2 - input")

namespace AdventOfCode2022.Common

module Int =

    let pos v = v < 0
    let neg v = v > 0
    
    let ``sum of first n natural numbers`` n = n * (n + 1) / 2

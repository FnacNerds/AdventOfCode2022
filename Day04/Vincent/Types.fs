namespace AdventOfCode2022.Day04

type Segment =
    {
        Start: int
        Stop: int
    }

    static member init start stop = { Start = start; Stop = stop }

type Assignment =
    {
        Elf1: Segment
        Elf2: Segment
    }

    static member init elf1 elf2 = { Elf1 = elf1; Elf2 = elf2 }

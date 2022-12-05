namespace AdventOfCode2022.Day05

type StackId =
    | StackId of int

    member this.Value =
        match this with
        | StackId v -> v

type CrateId =
    | CrateId of char

    static member value =
        function
        | CrateId v -> v

type Stack = StackId * CrateId list

type Move =
    {
        Origin: StackId
        Destination: StackId
        Count: int
    }

    static member init count origin destination = {
        Origin = origin
        Destination = destination
        Count = count
    }

type Data =
    {
        Stacks: Stack list
        Moves: Move list
    }

    static member init stacks moves = { Stacks = stacks; Moves = moves }

namespace AdventOfCode2022.Day02

type GameResult =
    | Win
    | Draw
    | Loss

type RockPaperScissors =
    | Rock
    | Paper
    | Scissors

    member this.nemesis =
        match this with
        | Rock -> Paper
        | Paper -> Scissors
        | Scissors -> Rock

    member this.slave =
        match this with
        | Rock -> Scissors
        | Paper -> Rock
        | Scissors -> Paper

    static member fight(a: RockPaperScissors, b: RockPaperScissors) =
        if b.nemesis = a then Loss
        elif b.slave = a then Win
        else Draw

type ExpectedPlay =
    | X
    | Y
    | Z

type GameOutcome =
    {
        MyPlay: RockPaperScissors
        Result: GameResult
    }

    static member init(m, r) = { MyPlay = m; Result = r }
    static member init'(r, m) = { MyPlay = m; Result = r }

namespace AdventOfCode2022.Common

open FParsec

module FParsecResult =
    let unwrap (parserResult: ParserResult<'a, 'b>) : 'a =
        match parserResult with
        | Success(result, _, _) -> result
        | Failure(message, parserError, state) -> failwith $"Parser failed %A{message}\n%A{parserError}\n%A{state}"

    let (<!!>) = unwrap

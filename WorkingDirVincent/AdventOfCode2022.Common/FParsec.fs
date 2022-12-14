namespace AdventOfCode2022.Common

open System.ComponentModel.DataAnnotations
open FParsec

module FParsec =
    let unwrap (parserResult: ParserResult<'a, 'b>) : 'a =
        match parserResult with
        | Success(result, _, _) -> result
        | Failure(message, parserError, state) -> failwith $"Parser failed %A{message}\n%A{parserError}\n%A{state}"

    let newLines c = parray c newline

    // https://stackoverflow.com/questions/45653927/fparsec-backtracking-sepby
    let backtrackingSepBy1 p sep =
        pipe2 p (many (sep >>? p)) (fun hd tl -> hd :: tl)

    let (>>>) (p: Parser<'a,'u>) (q: Parser<'b,'u>): Parser<unit, 'u> =
         pipe2 p q (fun _ _ -> ())

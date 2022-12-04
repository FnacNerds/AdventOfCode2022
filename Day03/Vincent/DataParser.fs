namespace AdventOfCode2022.Day03

open FParsec
open AdventOfCode2022.Common.FParsec

[<RequireQualifiedAccess>]
module DataParser =

    let parseId =
        (pchar 'a' >>% 1)
        <|> (pchar 'b' >>% 2)
        <|> (pchar 'c' >>% 3)
        <|> (pchar 'd' >>% 4)
        <|> (pchar 'e' >>% 5)
        <|> (pchar 'f' >>% 6)
        <|> (pchar 'g' >>% 7)
        <|> (pchar 'h' >>% 8)
        <|> (pchar 'i' >>% 9)
        <|> (pchar 'j' >>% 10)
        <|> (pchar 'k' >>% 11)
        <|> (pchar 'l' >>% 12)
        <|> (pchar 'm' >>% 13)
        <|> (pchar 'n' >>% 14)
        <|> (pchar 'o' >>% 15)
        <|> (pchar 'p' >>% 16)
        <|> (pchar 'q' >>% 17)
        <|> (pchar 'r' >>% 18)
        <|> (pchar 's' >>% 19)
        <|> (pchar 't' >>% 20)
        <|> (pchar 'u' >>% 21)
        <|> (pchar 'v' >>% 22)
        <|> (pchar 'w' >>% 23)
        <|> (pchar 'x' >>% 24)
        <|> (pchar 'y' >>% 25)
        <|> (pchar 'z' >>% 26)
        <|> (pchar 'A' >>% 27)
        <|> (pchar 'B' >>% 28)
        <|> (pchar 'C' >>% 29)
        <|> (pchar 'D' >>% 30)
        <|> (pchar 'E' >>% 31)
        <|> (pchar 'F' >>% 32)
        <|> (pchar 'G' >>% 33)
        <|> (pchar 'H' >>% 34)
        <|> (pchar 'I' >>% 35)
        <|> (pchar 'J' >>% 36)
        <|> (pchar 'K' >>% 37)
        <|> (pchar 'L' >>% 38)
        <|> (pchar 'M' >>% 39)
        <|> (pchar 'N' >>% 40)
        <|> (pchar 'O' >>% 41)
        <|> (pchar 'P' >>% 42)
        <|> (pchar 'Q' >>% 43)
        <|> (pchar 'R' >>% 44)
        <|> (pchar 'S' >>% 45)
        <|> (pchar 'T' >>% 46)
        <|> (pchar 'U' >>% 47)
        <|> (pchar 'V' >>% 48)
        <|> (pchar 'W' >>% 49)
        <|> (pchar 'X' >>% 50)
        <|> (pchar 'Y' >>% 51)
        <|> (pchar 'Z' >>% 52)

    let parseLine = many1 parseId
    let parseContents = sepBy1 parseLine newline
    let parse = (run (parseContents .>> eof)) >> unwrap

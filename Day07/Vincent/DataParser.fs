namespace AdventOfCode2022.Day07

open FParsec
open AdventOfCode2022.Common.FParsec
open AdventOfCode2022.Day07

[<RequireQualifiedAccess>]
module DataParser =

    let nlOrEof = skipNewline <|> eof

    let space = skipChar ' '

    let parseCd =
        ((skipString "cd" >>> space)
         >>. (((skipString "/" >>> nlOrEof) >>% TargetFolder.Root)
              <|> ((skipString ".." >>> nlOrEof) >>% TargetFolder.Parent)
              <|> ((many1CharsTill anyChar nlOrEof) |>> TargetFolder.Named)))
        |>> Command.CD

    let parseLsOutputForFile: Parser<LsOutput, unit> =
        ((puint32 .>> skipString " ") .>>. (many1CharsTill anyChar nlOrEof))
        |>> LsOutput.File

    let parseLsOutputForDir =
        (skipString "dir " >>. (many1CharsTill anyChar nlOrEof) |>> LsOutput.Folder)

    let parseLsOutput = many (parseLsOutputForFile <|> parseLsOutputForDir)
    let parseLs = ((skipString "ls" >>> nlOrEof) >>. parseLsOutput) |>> Command.LS

    let parseCommand = (parseCd <|> parseLs)

    let parseContents = many1 (skipChar '$' >>> space >>. parseCommand)

    let parse = (run (parseContents .>> eof)) >> unwrap

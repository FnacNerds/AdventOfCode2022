namespace AdventOfCode2022.Day07

type FileSize = uint32
type FileName = string
type FolderName = string

[<RequireQualifiedAccess>]
type TargetFolder =
    | Root
    | Parent
    | Named of FolderName

[<RequireQualifiedAccess>]
type LsOutput =
    | File of (FileSize * FileName)
    | Folder of FolderName

[<RequireQualifiedAccess>]
type Command =
    | LS of LsOutput list
    | CD of TargetFolder

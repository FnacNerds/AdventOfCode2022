namespace AdventOfCode2022.Day07

open AdventOfCode2022.Common
open Microsoft.FSharp.Core
open FSharp.Core.Operators.Checked

type Folder = {
    FilesSize: FileSize
    SubFolders: Folder list
}

[<RequireQualifiedAccess>]
module Solution =

    let rec getLsOutputs acc path commands =
        match commands with
        | [] -> acc
        | command :: otherCommands ->
            match command with
            | Command.CD targetFolder ->
                match targetFolder with
                | TargetFolder.Root -> getLsOutputs acc [] otherCommands
                | TargetFolder.Parent ->
                    match path with
                    | [] -> getLsOutputs acc [] otherCommands
                    | _ :: otherFolders -> getLsOutputs acc otherFolders otherCommands
                | TargetFolder.Named folderName -> getLsOutputs acc (folderName :: path) otherCommands
            | Command.LS lsOutputs -> getLsOutputs ((path, lsOutputs) :: acc) path otherCommands

    let rec buildFoldersTree folderPath lsOutputs =
        let filesSize, subFolders =
            lsOutputs
            |> Map.find folderPath
            |> List.fold
                (fun (filesSize, folders) lsOutput ->
                    match lsOutput with
                    | LsOutput.File(size, _name) -> (size + filesSize, folders)
                    | LsOutput.Folder subFolderName ->
                        let folder = buildFoldersTree (subFolderName :: folderPath) lsOutputs
                        (filesSize, folder :: folders)
                )
                (0u, [])

        {
            FilesSize = filesSize
            SubFolders = subFolders
        }

    let rec getFoldersSize (folder: Folder) : FileSize * FileSize list =
        match folder.SubFolders with
        | [] -> (folder.FilesSize, [])
        | subFolders ->
            let subFoldersSizes = subFolders |> List.map getFoldersSize
            let subFoldersSize = subFoldersSizes |> List.map fst
            let totalSubFoldersSize = subFoldersSize |> List.sum
            let subFolders = subFoldersSize @ (subFoldersSizes |> List.collect snd)
            let selfSize = totalSubFoldersSize + folder.FilesSize
            (selfSize, subFolders)

    let getAllSizes input =
        let rootSize, subFoldersSizes =
            input
            |> DataParser.parse
            |> getLsOutputs [] []
            |> Map.ofList
            |> buildFoldersTree []
            |> getFoldersSize

        rootSize :: subFoldersSizes

    let part1 input =

        input |> getAllSizes |> Seq.where (fun x -> x < 100000u) |> Seq.sum

    let part2 input =
        let diskSize = 70000000u
        let requiredFreeSpace = 30000000u

        let uInt32s = input |> getAllSizes

        let rootSize = uInt32s |> Seq.max

        let freeSpace = diskSize - rootSize
        let spaceToFree = requiredFreeSpace - freeSpace

        uInt32s |> List.sort |> List.find (fun x -> x >= spaceToFree)

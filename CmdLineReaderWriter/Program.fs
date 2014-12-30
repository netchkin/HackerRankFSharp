
// Learn more about F# at http://fsharp.net
// See the 'F# Tutorial' project for more help.

open System
open IntroductionLib

[<EntryPoint>]
let main argv = 
    let rawInput = stdin.ReadToEnd()
    let inputArgs = GeneralFunctions.ParseParameters rawInput
    
    let result = 
        inputArgs.data
            |> ListReplication.ReplicateLists inputArgs.operationArg
            |> GeneralFunctions.MakeListPrintable
    
    stdout.Write(result)

    Console.ReadKey()
    0 // return an integer exit code

(*
let ReadLines = ReadLines' System.std (System.Console.ReadLine()) []
    in let rec ReadLines' x l = 
            match x with
                | x when x = "" -> l
                | x -> ReadLines' (System.Console.ReadLine()) l::x

*)
    


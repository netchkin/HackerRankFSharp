
// Learn more about F# at http://fsharp.net
// See the 'F# Tutorial' project for more help.

open System

let FunSplit (separator:string) (text:string) =
        text.Split([|separator|], StringSplitOptions.RemoveEmptyEntries) 

let ParseToList (text:string) (separator:string) =
    text
    |> FunSplit separator
    |> Array.toList

let ParseDefault text =
    ParseToList text Environment.NewLine

let ParseToPair text = 
    match ParseDefault text with
    | [] -> (0, [])
    | replicationCount::realList -> 
        (Int32.Parse(replicationCount), realList)
    
let ReplicateLists text = 
    let pair = ParseToPair text
    pair |> snd
    |> List.collect (fun ch -> List.replicate (fst pair) ch)
    |> (fun l -> String.Join(Environment.NewLine, l))

stdout.Write(ReplicateLists (stdin.ReadToEnd()))

[<EntryPoint>]
let main argv = 
    let s : string = stdin.ReadToEnd()

    printfn "%s" s
    0 // return an integer exit code

(*
let ReadLines = ReadLines' System.std (System.Console.ReadLine()) []
    in let rec ReadLines' x l = 
            match x with
                | x when x = "" -> l
                | x -> ReadLines' (System.Console.ReadLine()) l::x

*)
    


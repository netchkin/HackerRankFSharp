namespace IntroductionLib


type Class1() = 
    member this.X = "F#"

module TryOut =
    open System

    let testArgs a b =
        Console.WriteLine("a: {0}, b: {1}", a, b)
    
    let testArgs2 (args : string[]) = 
        if args.Length = 2 then
            printfn "1:%s, 2: %s" args.[0] args.[1]
        else 
            failwith "you've got it wrong"

    let ReadTest =
        let input = System.Console.ReadLine()
        input

    /// identity
    let genericTest (arg : 'a) = 
        arg

module common =
    let one = 1

module ListReplication =
    open System
    open Microsoft.FSharp

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

    // problem solution: stdout.Write(ReplicateLists (stdin.ReadToEnd()))
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

/// TODO: make it beautiful
module GeneralFunctions =
    open System

    type Input = { operationArg: int; data: list<int> }

    let private FunSplit (separator:string) (text:string) =
        text.Split([|separator|], StringSplitOptions.RemoveEmptyEntries) 

    let private ParseParametersToList (separator:string) (text:string) =
        text
        |> FunSplit separator
        |> Array.toList

    let private ParseParametersToIntListDefault text =
        text
        |> ParseParametersToList Environment.NewLine
        |> List.map (fun element -> Int32.Parse(element))

    let ParseParameters text = 
        match ParseParametersToIntListDefault text with
        | [] -> 
            { operationArg = 0; data = [] }
        | replicationCount::dataList -> 
            { operationArg = replicationCount; data = dataList }

    // TODO: is there .ToString()less variant that would be also generic?
    let MakeListPrintable (data : list<_>) =
        data
        |> List.map (fun item -> item.ToString())
        |> (fun entireList -> String.Join(Environment.NewLine, entireList))


module ListReplication =
    
    let ReplicateLists replications list = 
        list
        |> List.collect (fun item -> [for _ in 1 .. replications do yield item])




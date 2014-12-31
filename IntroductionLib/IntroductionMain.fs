namespace IntroductionLib

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

    let ParseParametersData =
        ParseParametersToIntListDefault

    let ParseParametersOpData text = 
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


module FilterArray =     
     let FilterList exclusiveMaximum list =
        [for item in list do if item < exclusiveMaximum then yield item]


module FilterPositionInList =
    let FilterPosition data = [for index in 1 .. (List.length data) do if index % 2 = 0 then yield data.[index-1]]

    let FilterPositionUsingStructuralInduction data = 
        let rec fp' list res = 
            match list with
                | _::even::rest -> fp' rest (even::res)
                | _::[] -> res
                | [] -> res
        in fp' data []

module ReverseList =
    let Reverse list =
        let rec Reverse' list result =
            match list with
                | [] -> result
                | x::xs -> Reverse' xs (x::result)
        in Reverse' list []
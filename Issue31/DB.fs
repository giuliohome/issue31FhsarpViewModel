module DB

[<AllowNullLiteral>]
type RecentFile(name, path) =  
    member x.Name: string = name
    member x.Path: string  = path

let getRecent () = 
    Seq.empty


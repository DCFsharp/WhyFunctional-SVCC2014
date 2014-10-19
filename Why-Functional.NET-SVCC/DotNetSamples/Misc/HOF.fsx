open System

type Developer = {FirstName:string; LastName:string; IsFunctional:bool; YearsOfExperience:int}
type GoodSeniorDeveloper = {FirstName:string; LastName:string}

let getGoodSeniorDeveloper developers = 
        // Developer -> GoodSeniorDeveloper
        let convertToGSD (d:Developer) = {FirstName = d.FirstName; LastName=d.LastName};
        // Developer -> bool
        let isGoodSeniorDeveloper d = d.IsFunctional 
                                        && d.YearsOfExperience >= 5

        developers
        |> List.filter isGoodSeniorDeveloper
        |> List.map convertToGSD

// string -> int -> string
let print name age =
    sprintf "name %s age %d" name age

let print' =
    (fun name -> fun age -> 
    sprintf "name %s age %d" name age) 


// int -> string
let printAge age = print "Ricky" age
let printAge'' = (fun age ->  print "Ricky" age)// age
let printAge' = print "Ricky"



// string
let result = printAge 39 


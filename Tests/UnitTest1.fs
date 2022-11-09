module Tests

open NUnit.Framework
open Newtonsoft.Json
open FSharpLibrary
open CSharpLibrary

[<Test>]
let ``serialize C# struct`` () =
    let range = CRange(1, 2, 2, 3)
    let json = JsonConvert.SerializeObject(range)
    ()

[<Test>]
let ``serialize F# struct`` () =
    let range = FRange(1, 2, 2, 3)
    let json = JsonConvert.SerializeObject(range)
    ()

open BenchmarkDotNet.Running
open Benchmarks

[<EntryPoint>]
let main argv = 
    BenchmarkRunner.Run<Bench>() |> ignore
    0
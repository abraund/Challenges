module hackerrank

open NUnit.Framework
open System

let inStrA s = s |> Seq.filter (fun x -> x = 'a') |> Seq.length |> int64

let infiniteA (s: string) (n: Int64) =
    let sLength = s.Length |> int64
    let fullCounts = (n / sLength) * inStrA(s);
    let partialCount = s |> Seq.take (n % sLength |> int32) |> inStrA
    fullCounts + partialCount;

[<Test>]
let Unit1 () =
    Assert.That(infiniteA "aba" 10, Is.EqualTo 7)
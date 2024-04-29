module TestProject1

open Microsoft.VisualStudio.TestTools.UnitTesting;
open System
open System.IO

let charToInt x = x - '0' |> int

let getNumber line = 
        let first = line |> Seq.find Char.IsDigit |> charToInt
        let last = line |> Seq.findBack Char.IsDigit |> charToInt
        (first * 10) + last

let sumInputList input = Array.fold (fun acc line -> acc + getNumber line) 0 input


[<TestMethod>]
let getNumberFromLine () =
    let answer = getNumber "1abc2"
    Assert.AreSame(answer, 12)

[<TestMethod>]
let sumLines () =
    let answer = sumInputList [|"1abc2"; "df4ab4c2fa"; "apiiuu791"|]
    Assert.AreSame(answer, 125)

[<TestMethod>]
[<DeploymentItem("001.txt")>]
let outChallenge () =
    let lines = File.ReadAllLines("001.txt")
    let answer = sumInputList lines
    System.Console.WriteLine answer

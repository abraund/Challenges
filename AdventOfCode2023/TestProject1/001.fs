module TestProject1

open NUnit.Framework
open System
open System.IO

let charToInt x = x - '0' |> int

let getNumber line = 
        let first = line |> Seq.find Char.IsDigit |> charToInt
        let last = line |> Seq.findBack Char.IsDigit |> charToInt
        (first * 10) + last

let sumInputList input = Array.fold (fun acc line -> acc + getNumber line) 0 input


[<Test>]
let getNumberFromLine () =
    let answer = getNumber "1abc2"
    Assert.That(answer, Is.EqualTo(12))

[<Test>]
let sumLines () =
    let answer = sumInputList [|"1abc2"; "df4ab4c2fa"; "apiiuu791"|]
    Assert.That(answer, Is.EqualTo(125))

[<Test>]
[<Microsoft.VisualStudio.TestTools.UnitTesting.DeploymentItem("Data/localdb.mdf")>]

let outChallenge () =
    let lines = File.ReadAllLines("001-input.txt")
    let answer = sumInputList lines
    System.Console.WriteLine answer

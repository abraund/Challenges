namespace TestProject2

open System
open System.IO
open Microsoft.VisualStudio.TestTools.UnitTesting;

module Program =
    let charToInt x = x - '0' |> int

    let getNumber line = 
        let first = line |> Seq.find Char.IsDigit |> charToInt
        let last = line |> Seq.findBack Char.IsDigit |> charToInt
        (first * 10) + last

    let sumInputList input = Array.fold (fun acc line -> acc + getNumber line) 0 input

[<TestClass>]
type TestClass () =
    [<TestMethod>]
    let getNumberFromLine () =
        let answer = Program.getNumber "1abc2"
        Assert.AreSame(answer, 12)

    [<TestMethod>]
    let sumLines () =
        let answer = Program.sumInputList [|"1abc2"; "df4ab4c2fa"; "apiiuu791"|]
        Assert.AreSame(answer, 125)

    [<TestMethod>]
    [<DeploymentItem("001-input.txt")>]
    let outChallenge () =
        let lines = File.ReadAllLines("001-input.txt")
        let answer = Program.sumInputList lines
        System.Console.WriteLine answer




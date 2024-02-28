module Aoc001

open System
open System.IO
open NUnit.Framework

let charToInt x = x - '0' |> int

let getNumber line = 
        let first = line |> Seq.find Char.IsDigit |> charToInt
        let last = line |> Seq.findBack Char.IsDigit |> charToInt
        (first * 10) + last

let sumInputList input = Array.fold (fun acc line -> acc + getNumber line) 0 input

[<TestCase>]
let getNumberFromLine () =
    let answer = getNumber "1abc2"
    Assert.AreEqual(answer, 12)

[<TestCase>]
let sumLines () =
    let answer = sumInputList [|"1abc2"; "df4ab4c2fa"; "apiiuu791"|]
    Assert.AreEqual(answer, 125)

[<TestCase>]
let outChallenge () =
    let lines = File.ReadAllLines("Aoc001.txt")
    let answer = sumInputList lines
    System.Console.WriteLine answer

let startsWithNumber (numberStr:string) (input:string) = input.StartsWith numberStr
let zero = startsWithNumber "zero"
let one = startsWithNumber "one"
let two = startsWithNumber "two"
let three = startsWithNumber "three"
let four = startsWithNumber "four"
let five = startsWithNumber "five"
let six = startsWithNumber "six"
let seven = startsWithNumber "seven"
let eight = startsWithNumber "eight"
let nine = startsWithNumber "nine"

let numberStartsWith (line: string) =
    match line with
    | line when Char.IsDigit line[0] -> Some(charToInt line[0])
    | line when zero line -> Some 0
    | line when one line -> Some 1
    | line when two line -> Some 2
    | line when three line -> Some 3
    | line when four line -> Some 4
    | line when five line -> Some 5
    | line when six line -> Some 6
    | line when seven line -> Some 7
    | line when eight line -> Some 8
    | line when nine line -> Some 9
    | _ -> None

let rec findFirst (line: string) = 
    match numberStartsWith line with
    | Some a -> a
    | None -> findFirst line.[1..]

let rec findLast' (line: string) (target: int) = 
    let fragment = line.[target..]
    match numberStartsWith fragment with
    | Some a -> a
    | None -> findLast' line (target - 1)
  
let findLast (line: string) = 
    findLast' line (line.Length - 1)

let getNumberWordy line = 
        let first = line |> findFirst
        let last = line |> findLast
        (first * 10) + last

let sumInputListWordy input = Array.fold (fun acc line -> acc + getNumberWordy line) 0 input
   
[<TestCase>]
let findFirstTest () =
    let answer = findFirst "aoneandhtsajl5"
    Assert.AreEqual(1, answer)

[<TestCase>]
let findLastTest () =
    let answer = findLast "dfsalkfjdsafivefsjld"
    Assert.AreEqual(5, answer)

[<TestCase>]
let getNumberWordyTest () =
    let answer = getNumberWordy "dfsalkfjdsafivefsjldeight"
    Assert.AreEqual(58, answer)

[<TestCase>]
let outChallengeWordy () =
    let lines = File.ReadAllLines("Aoc001.txt")
    let answer = sumInputListWordy lines
    System.Console.WriteLine answer
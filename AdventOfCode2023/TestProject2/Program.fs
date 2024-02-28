open System

module Program =
    let charToInt x = x - '0' |> int

    let getNumber line = 
        let first = line |> Seq.find Char.IsDigit |> charToInt
        let last = line |> Seq.findBack Char.IsDigit |> charToInt
        (first * 10) + last

    let sumInputList input = Array.fold (fun acc line -> acc + getNumber line) 0 input

module Aoc002

open System
open System.IO
open NUnit.Framework

type Colour = Red | Green | Blue

type Draw = 
    {
        Count: int;
        Colour: Colour
    }

type Game = 
    {
        Id : int;
        Draws : Draw list
    }

type CheckProductCodeExists =
    Game -> bool

let internal checkProductExists game : CheckProductCodeExists =
    fun game ->
        game.Id = 3


let draw count colour = {Count = count; Colour = colour}

let game1 = { Id = 1; Draws = [draw 3 Blue; draw 4 Red; draw 2 Green; draw 6 Blue; draw 2 Green] }
let game2 = { Id = 2; Draws = [draw 1 Blue; draw 2 Green; draw 3 Green; draw 4 Blue; draw 1 Red; draw 1 Blue] }
let game3 = { Id = 3; Draws = [draw 8 Green; draw 6 Blue; draw 20 Red; draw 5 Blue; draw 4 Red; draw 13 Green; draw 5 Green; draw 1 Red] }
let game4 = { Id = 4; Draws = [draw 1 Green; draw 3 Red; draw 6 Blue; draw 3 Green; draw 6 Red; draw 3 Green; draw 15 Blue; draw 14 Red] }
let game5 = { Id = 5; Draws = [draw 6 Red; draw 1 Blue; draw 3 Green; draw 2 Blue; draw 1 Red; draw 2 Green] }

let sumColour colour (game : Game) = 
    List.filter (fun draw -> draw.Colour = colour) game.Draws 
    |> List.fold (fun acc draw -> acc + draw.Count) 0

let checkGame (totalDraw: Draw list) game =
    List.forall (fun (drawByColour: Draw) -> (sumColour drawByColour.Colour game) > drawByColour.Count) totalDraw

[<TestCase>]
let sumColourTest () =
    let answer = sumColour Red game1
    Assert.AreEqual(answer, 4)

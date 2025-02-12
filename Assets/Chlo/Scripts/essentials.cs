using System;
using System.Collections.Generic;
using UnityEngine;
namespace essentials{
public class Puzzle_Piece{
   public aspect required_aspect;
   public int required_amount;
        public Puzzle_Piece(aspect required_aspect, int required_amount)
        {
            this.required_aspect = required_aspect;
            this.required_amount = required_amount;
        }
}

   public enum aspect
   {
    Blades,
    Goblets,
    Wands,
    Pentacles,
    Major
   }

public abstract class Character
{
    public string name { get;set;}
    public List<Puzzle_Piece> puzzle = new List<Puzzle_Piece>();
    public string backstory;
    public void roll_puzzle(){
        for (int i = 0; i < 3; i++){
        puzzle.Add(new Puzzle_Piece((aspect)UnityEngine.Random.Range(0, 3), UnityEngine.Random.Range(0,2)));
        }
    }
 }
}
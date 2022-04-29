using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Memory.Models.States
{


    public class BoardFinishedState : BoardStateBaseClass
    {
        public override BoardStates State { get => BoardStates.Finished; }
        public BoardFinishedState(MemoryBoard board) : base(board)
        {
            Board = board;
            Debug.Log("in boardFinishedState");
        }

        public override void AddPreview(Tile tile)
        {

        }

        public override void TileAnimationEnded(Tile tile)
        {
            
        }
    }

}
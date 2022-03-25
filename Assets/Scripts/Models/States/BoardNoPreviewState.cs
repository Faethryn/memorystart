using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Memory.Models.States
{


    public class BoardNoPreviewState : BoardStateBaseClass
    {
        public override BoardStates State { get => BoardStates.NoPreview; }
        public BoardNoPreviewState(MemoryBoard board) : base(board)
        {

        }

        public override void AddPreview(Tile tile)
        {
           
        }

        public override void TileAnimationEnded(Tile tile)
        {
            
        }
    }

}
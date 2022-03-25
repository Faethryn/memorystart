using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Memory.Models.States
{


    public class BoardTwoHidingState : BoardStateBaseClass
    {
        public override BoardStates State { get => BoardStates.TwoHiding; }
        public BoardTwoHidingState(MemoryBoard board) : base(board)
        {
            Board = board;
        }

        public override void AddPreview(Tile tile)
        {

        }

        public override void TileAnimationEnded(Tile tile)
        {
            Board.PreviewingTiles.Remove(tile);
            if (Board.PreviewingTiles.Count == 0)
            {
                Board.State = new BoardNoPreviewState(Board);
            }
        }
    }

}
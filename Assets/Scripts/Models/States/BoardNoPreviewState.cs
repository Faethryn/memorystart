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
            Board = board;
        }

        public override void AddPreview(Tile tile)
        {
            if (tile.State.State == TileStates.Hidden)
            {
                tile.State = new TilePreviewingState(tile);
                Board.PreviewingTiles.Add(tile);
                Board.State = new BoardOnePreviewState(Board);
            }
            else return;
        }

        public override void TileAnimationEnded(Tile tile)
        {
            
        }
    }

}
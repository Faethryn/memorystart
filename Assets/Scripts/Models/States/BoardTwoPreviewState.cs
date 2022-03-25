using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Memory.Models.States
{


    public class BoardTwoPreviewState : BoardStateBaseClass
    {
        public override BoardStates State { get => BoardStates.TwoPreview; }
        public BoardTwoPreviewState(MemoryBoard board) : base(board)
        {
            Board = board;
        }

        public override void AddPreview(Tile tile)
        {
           
        }

        public override void TileAnimationEnded(Tile tile)
        {
            if (tile == Board.PreviewingTiles[2])
            {
                foreach (Tile previewingTile in Board.PreviewingTiles)
                {
                    previewingTile.State = new TileHiddenState(previewingTile);

                }
                Board.State = new BoardTwoHidingState(Board);
            }
        }
    }

}
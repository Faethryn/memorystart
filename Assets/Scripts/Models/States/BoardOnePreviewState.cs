using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Memory.Models.States
{


    public class BoardOnePreviewState : BoardStateBaseClass
    {
        public BoardOnePreviewState(MemoryBoard board) : base(board)
        {
            Board = board;
        }

        public override BoardStates State { get => BoardStates.OnePreview; }
        public override void AddPreview(Tile tile)
        {
            if (tile.State.State == TileStates.Hidden)
            {
                tile.State = new TilePreviewingState(tile);
                Board.PreviewingTiles.Add(tile);
                Board.State = new BoardOnePreviewState(Board);
                if (Board.IsCombinationFound)
                {
                    Board.State = new BoardTwoFoundState(Board);
                    foreach (Tile validatedTile in Board.PreviewingTiles)
                    {
                        validatedTile.State = new TileFoundState(validatedTile);
                    }
                }
                else
                {
                    Board.State = new BoardTwoPreviewState(Board);
                    tile.State = new TilePreviewingState(tile);
                }
            }
            else return;

        }

        public override void TileAnimationEnded(Tile tile)
        {
            
        }
    }

}
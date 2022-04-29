using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Memory.Models.States
{


    public class BoardTwoFoundState : BoardStateBaseClass
    {
        public override BoardStates State { get => BoardStates.TwoFound; }
        public BoardTwoFoundState(MemoryBoard board) : base(board)
        {
            Board = board;
            Debug.Log("in TwoFoundState");
        }

        public override void AddPreview(Tile tile)
        {
          
        }

        public override void TileAnimationEnded(Tile tile)
        {
            Board.PreviewingTiles.Remove(tile);
            if (Board.PreviewingTiles.Count == 0)
            {
               
                if (Board.Tiles.Where( t => t.State.State == TileStates.Hidden).Count() <2  )
                {
                    Board.State = new BoardFinishedState(Board);
                }
                if (Board.PreviewingTiles.Count == 0)
                {
                    ToggleActivePlayer();
                    Board.State = new BoardNoPreviewState(Board);
                }
            }
        }
        private void ToggleActivePlayer()
        {
            if (Board.Player1.IsActive)
            {
                Board.Player1.Score += 1;
            }
            if (Board.Player2.IsActive)
            {
                Board.Player2.Score += 1;
            }

            bool tempBoolPlayer1 = Board.Player1.IsActive;
            bool tempBoolPlayer2 = Board.Player2.IsActive;
            Board.Player1.IsActive = tempBoolPlayer2;
            Board.Player2.IsActive = tempBoolPlayer1;
        }
    }

}
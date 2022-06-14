using Assets.Scripts.Data;
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
            
           
          
            if (Board.PreviewingTiles[1] == tile)
            {
             
                
                    TileCombinationRepository tileCombinationRepository = TileCombinationRepository.Instance;
                    tileCombinationRepository.UploadTileCombination(Board.PreviewingTiles[0].Column, Board.PreviewingTiles[0].Row, Board.PreviewingTiles[1].Column, Board.PreviewingTiles[1].Row);
                

                Board.PreviewingTiles.Clear();
                if (Board.PreviewingTiles.Count == 0)
                {

                    ToggleActivePlayer();
                    
                    
                    Board.State = new BoardNoPreviewState(Board);
                }
                if (Board.Tiles.Where( t => t.State.State == TileStates.Hidden).Count() <2  )
                {
                    Board.State = new BoardFinishedState(Board);
                }
            }
        }
        private void ToggleActivePlayer()
        {
            if (Board.Player1.IsActive && Board.Player1.HasTakenTwoTurns == true)
            {
                Board.Player1.Score += 1;
                Board.Player1.HasTakenTwoTurns = false;
                ChangeActivePlayer();
            }
            else
            if (Board.Player2.IsActive && Board.Player2.HasTakenTwoTurns == true)
            {
                Board.Player2.Score += 1;
                Board.Player2.HasTakenTwoTurns = false;
                ChangeActivePlayer();
            }
            else
            if (Board.Player1.IsActive && Board.Player1.HasTakenTwoTurns == false)
            {
                Board.Player1.Score += 1;
                Board.Player1.HasTakenTwoTurns = true;
            }
            else
            if (Board.Player2.IsActive && Board.Player2.HasTakenTwoTurns == false)
            {
                Board.Player2.Score += 1;
                Board.Player2.HasTakenTwoTurns = true;
            }

            
        }

        private void ChangeActivePlayer()
        {
            bool tempBoolPlayer1 = Board.Player1.IsActive;
            bool tempBoolPlayer2 = Board.Player2.IsActive;
            Board.Player1.IsActive = tempBoolPlayer2;
            Board.Player2.IsActive = tempBoolPlayer1;
            Board.Player1.HasTakenTwoTurns = false;
            Board.Player2.HasTakenTwoTurns = false;

        }
        
    }

}
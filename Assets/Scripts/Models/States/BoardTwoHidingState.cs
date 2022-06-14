using System;
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
            Debug.Log("in twoHidingState");
        }

        public override void AddPreview(Tile tile)
        {

        }

        public override void TileAnimationEnded(Tile tile)
        {
            Board.PreviewingTiles.Remove(tile);
            if (Board.PreviewingTiles.Count == 0)
            {
                ToggleActivePlayer();
                Board.State = new BoardNoPreviewState(Board);
            }
        }

        private void ToggleActivePlayer()
        {
            if (Board.Player1.IsActive && Board.Player1.HasTakenTwoTurns == true)
            {
                Board.Player1.HasTakenTwoTurns = false;

                ChangeActivePlayer();
            }
            else
            if (Board.Player2.IsActive && Board.Player2.HasTakenTwoTurns == true)
            {
                Board.Player2.HasTakenTwoTurns = false;
                ChangeActivePlayer();
            }
            else
            if (Board.Player1.IsActive && Board.Player1.HasTakenTwoTurns == false)
            {
                Board.Player1.HasTakenTwoTurns = true;
            }
            else
            if (Board.Player2.IsActive && Board.Player2.HasTakenTwoTurns == false)
            {
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
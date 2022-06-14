using Assets.Scripts.Data;
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
            Debug.Log("in TwoPreviewState");
        }

        public override void AddPreview(Tile tile)
        {
           
        }

        public override void TileAnimationEnded(Tile tile)
        {
            if (tile == Board.PreviewingTiles[1])
            {
                TileCombinationRepository tileCombinationRepository = TileCombinationRepository.Instance;

                tileCombinationRepository.UploadTileCombination(Board.PreviewingTiles[0].Column, Board.PreviewingTiles[0].Row, Board.PreviewingTiles[1].Column, Board.PreviewingTiles[1].Row);

                foreach (Tile previewingTile in Board.PreviewingTiles)
                {
                    previewingTile.State = new TileHiddenState(previewingTile);

                }
                Board.State = new BoardTwoHidingState(Board);
            }
        }



        

    }

}
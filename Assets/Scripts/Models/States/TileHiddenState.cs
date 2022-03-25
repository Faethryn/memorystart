using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Memory.Models.States
{


    public class TileHiddenState : TileStateBaseClass
    {
        public TileHiddenState(Tile tile) : base(tile)
        {
            Tile = tile;
        }

        public override TileStates State { get => TileStates.Hidden; } 
    }
}
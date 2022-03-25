using System.Collections;
using System.Collections.Generic;
using UnityEngine;



namespace Memory.Models.States
{
    public abstract class TileStateBaseClass : ITileState
    {
        public abstract TileStates State { get; }

        public Tile Tile { get ; set ; }

        public TileStateBaseClass(Tile tile)
        {
            Tile = tile;
        }
    }
}
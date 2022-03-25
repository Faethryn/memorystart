using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Memory.Models.States
{


    public interface IBoardState 
    {
        public BoardStates State { get; }
        public MemoryBoard Board { get; set; }

        public void AddPreview(Tile tile);
        public void TileAnimationEnded(Tile tile);
    }
}
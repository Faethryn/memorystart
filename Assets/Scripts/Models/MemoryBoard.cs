using Memory.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MemoryBoard : ModelBaseClass
{
    public int Rows { get { return Rows; } set { OnPropertyChanged(); Rows = value; } }

    public int Columns { get { return Columns; } set { OnPropertyChanged(); Columns = value; } }

    public List<Tile> Tiles { get { return Tiles; } set { OnPropertyChanged(); Tiles = value; } }

    public List<Tile> PreviewingTiles { get { return PreviewingTiles; } set { OnPropertyChanged(); PreviewingTiles = value; } }

    public bool IsCombinationFound { get { if (PreviewingTiles.Count == 2) { return true; } else return false; }  }

    public MemoryBoard(int rows, int columns)
    {
        Rows = rows;
        Columns = columns;
        Tiles = new List<Tile>(Rows * Columns);
        AssignMemoryCardIds();
    }

    private void AssignMemoryCardIds()
    {
       
    }

    public override string ToString()
    {
        return $"Memoryboard({Rows}, {Columns})";
    }

}

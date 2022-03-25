using Memory.Models;
using Memory.Models.States;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MemoryBoard : ModelBaseClass
{
    private int _rows;
    public int Rows { get { return _rows; } set { if(_rows == value) return; _rows = value; OnPropertyChanged();  } }

    private int _columns;
    public int Columns { get { return _columns; } set { if(_columns == value) return;  _columns = value; OnPropertyChanged(); } }

    private List<Tile> _tiles;
    public List<Tile> Tiles { get { return _tiles; } set { if(_tiles == value) return; _tiles = value; OnPropertyChanged(); } }

    private List<Tile> _previewingTiles;
    public List<Tile> PreviewingTiles { get { return _previewingTiles; } set { if (_previewingTiles == value) return;  _previewingTiles = value; OnPropertyChanged(); } }

    public bool IsCombinationFound { get { if (PreviewingTiles.Count == 2) { return true; } else return false; }  }

    public BoardStateBaseClass State { get; set; }

    public MemoryBoard(int rows, int columns)
    {
        Rows = rows;
        Columns = columns;
        Tiles = new List<Tile>(Rows * Columns);
        AssignMemoryCardIds();
    }

    private void AssignMemoryCardIds()
    {
       for(int i = 1 ; i <= Rows; i++)
        {
            for(int j = 1; j <= Columns; j++)
            {
                Tiles.Add(new Tile(i, j, this));

            }

        }
    }

    public override string ToString()
    {
        return $"Memoryboard({Rows}, {Columns})";
    }

}

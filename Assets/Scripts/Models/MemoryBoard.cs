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

    public bool IsCombinationFound { get { if (PreviewingTiles.Count == 2 && PreviewingTiles[0].MemoryCardId == PreviewingTiles[1].MemoryCardId) { return true; } else return false; }  }

    private BoardStateBaseClass _state;
    public BoardStateBaseClass State { get { return _state; } set { if (_state == value) return; _state = value; OnPropertyChanged(); } }

    private Player _player1;
    
    public Player Player1 {  get { return _player1; } set { if (_player1 == value) return; _player1 = value; OnPropertyChanged(); } }

    private Player _player2;

    public Player Player2 { get { return _player2; } set { if (_player2 == value) return; _player2 = value; OnPropertyChanged(); } }

    public MemoryBoard(int rows, int columns, Player player1, Player player2)
    {
        Rows = rows;
        Columns = columns;
        Tiles = new List<Tile>(Rows * Columns);
        AssignMemoryCardIds();
        State = new BoardNoPreviewState(this);
        _previewingTiles = new List<Tile>();

        Player1 = player1;
        Player2 = player2;


    }

    private void AssignMemoryCardIds()
    {
        int currentIndex = 0;
        for (int i = 1; i <= Rows; i++)
        {
            for (int j = 1; j <= Columns; j++)
            {

                Tile temptile = new Tile(i, j, this);
                int cardId = Mathf.FloorToInt(currentIndex / 2);
                temptile.MemoryCardId = cardId;
                Tiles.Add(temptile);
                currentIndex += 1;

            }

        }

       

    }

    public override string ToString()
    {
        return $"Memoryboard({Rows}, {Columns})";
    }

    public void TileAnimationEnded(Tile sourceTile)
    {
        State.TileAnimationEnded(sourceTile);
    }

}

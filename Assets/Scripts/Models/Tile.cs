using Memory.Models;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : ModelBaseClass
{

    private int _row;
    public int Row { get { return _row; } set { if (_row == value) return; _row = value; OnPropertyChanged(); } }

    private int _column;
    public int Column { get { return _column; } set { if (_column == value) return; _column = value; OnPropertyChanged(); } }

    private MemoryBoard _board;

    public MemoryBoard Board { get { return _board; } set { if (_board == value) return; _board = value; OnPropertyChanged(); } }

    private int _memoryCardId;
    public int MemoryCardId { get { return _memoryCardId; } set { if (_memoryCardId == value) return; _memoryCardId = value; OnPropertyChanged(); } }


    public Tile(int row, int column, MemoryBoard board)
    {
        Row = row;
        Column = column;
        Board = board;
    }

    public override string ToString()
    {
        string returnText = $"Tile({Row},{Column}";
        return returnText;
    }

}

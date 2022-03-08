using Memory.Models;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : ModelBaseClass
{
    public int Row { get { return Row; } set { OnPropertyChanged(); Row = value; } }

    public int Column { get { return Column; } set { OnPropertyChanged(); Column = value; } }

    public MemoryBoard Board { get { return Board; } set { OnPropertyChanged(); Board = value; } }

    public int MemoryCardId { get { return MemoryCardId; } set { OnPropertyChanged(); MemoryCardId = value; } }
}

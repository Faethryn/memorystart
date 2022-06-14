using Memory.Models;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : ModelBaseClass
{
    private string _name;
    public string Name { get { return _name; } set { if (_name == value) return; _name = value; OnPropertyChanged(); } }

    private int _score;
    public int Score { get { return _score; } set { if (_score == value) return; _score = value; OnPropertyChanged(); } }

    private bool _isActive;
    public bool IsActive { get { return _isActive; } set { if (_isActive == value) return; _isActive = value; OnPropertyChanged(); } }

    private bool _hasTakenTwoTurns;

    public bool HasTakenTwoTurns { get { return _hasTakenTwoTurns; } set { if (_hasTakenTwoTurns == value) return; _hasTakenTwoTurns = value; OnPropertyChanged(); } }

    private float _elapsed;
    public float Elapsed { get { return _elapsed; } set { if (_elapsed == value) return; _elapsed = value; OnPropertyChanged(); } }

    public Player(string name, int score, bool isActive, float elapsedTime)
    {
        Name = name;
        Score = score;
        IsActive = isActive;
        Elapsed = elapsedTime;
    }

}

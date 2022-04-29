using Memory.Views;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MemoryGame : MonoBehaviour
{
    [SerializeField]
    private GameObject _tilePrefab;
    [SerializeField]
    private GameObject _memoryBoard;

    [SerializeField]
    MemoryBoardView _memoryBoardView;

    [SerializeField]
    private PlayerView _player1View;

    [SerializeField]
    private PlayerView _player2View;

    [SerializeField]
    private List<Material> _materials;


    private void Start()
    {
        _player1View.Model = new Player("Player 1", 0, true, 0);
        _player2View.Model = new Player("Player 2", 0, false, 0);

        _player1View.Model.Elapsed = 0;
        _player2View.Model.Elapsed = 0;

        _player1View.Model.Name = "Player 1";
        _player2View.Model.Name = "Player 2";

        _player1View.Model.IsActive = true;
        _player2View.Model.IsActive = false;

        _player1View.Model.Score = 0;
        _player2View.Model.Score = 0;

        MemoryBoard tempBoard = new MemoryBoard(3, 3, _player1View.Model, _player2View.Model );
        //_memoryBoard.GetComponent<MemoryBoardView>().SetUpMemoryBoardView(tempBoard, _tilePrefab);
        _memoryBoardView.SetUpMemoryBoardView(tempBoard, _tilePrefab, _materials);


    }


}

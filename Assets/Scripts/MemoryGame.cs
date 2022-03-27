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


    private void Start()
    {

        MemoryBoard tempBoard = new MemoryBoard(3, 3);
        //_memoryBoard.GetComponent<MemoryBoardView>().SetUpMemoryBoardView(tempBoard, _tilePrefab);
        _memoryBoardView.SetUpMemoryBoardView(tempBoard, _tilePrefab);
    }


}

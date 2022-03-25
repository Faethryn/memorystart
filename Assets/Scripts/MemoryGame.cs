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

    private MemoryBoard _storedBoard;


    private void Start()
    {
        _storedBoard = new MemoryBoard(3, 3);
        _memoryBoard.GetComponent<MemoryBoardView>().SetUpMemoryBoardView(_storedBoard, _tilePrefab);
    }


}

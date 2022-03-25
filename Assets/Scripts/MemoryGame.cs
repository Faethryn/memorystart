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

   


    private void Start()
    {

      
        _memoryBoard.GetComponent<MemoryBoardView>().SetUpMemoryBoardView(new MemoryBoard(3, 3), _tilePrefab);
    }


}

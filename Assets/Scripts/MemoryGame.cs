using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MemoryGame : MonoBehaviour
{
    MemoryBoard _board;
    // Start is called before the first frame update
    void Start()
    {
        _board = new MemoryBoard(3, 3);
        Debug.Log(_board.Tiles.Count);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

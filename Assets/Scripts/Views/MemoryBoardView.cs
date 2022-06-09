using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

namespace Memory.Views
{

    public class MemoryBoardView : ViewBaseClass<MemoryBoard>
    {
      
        protected override void Model_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            
        }

        public void SetUpMemoryBoardView(MemoryBoard model, GameObject tilePrefab)
        {
            Model = model;
           
            TileInstantiation(tilePrefab);
        }

        private void TileInstantiation(GameObject tilePrefab)
        {
            foreach (Tile tile in Model.Tiles)
                {
               

                Vector3 spawnLocation = new Vector3(tile.Column, 0, tile.Row);
                GameObject tempTile = tilePrefab;
              
              GameObject tempObject =  Instantiate(tempTile, spawnLocation, new Quaternion(), this.gameObject.transform);
               //tempObject.GetComponentInChildren<TileView>()._front.GetComponent<MeshRenderer>().material = _materials[tile.MemoryCardId];
                tempObject.GetComponentInChildren<TileView>().Model = tile;
            }
        }
    }

}
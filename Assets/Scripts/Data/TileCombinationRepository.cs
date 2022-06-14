using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using Newtonsoft.Json;
using System.Linq;

namespace Assets.Scripts.Data
{
    public class TileCombinationRepository: Singleton<TileCombinationRepository>
    {
        private string tileCombinationString = "http://www.pd4imagewebservice.edu/api/TileCombination";
        public void UploadTileCombination(int cardColumn1, int cardColumn2, int cardRow1, int cardRow2)
        {
            StartCoroutine(PostTileCombinations(cardColumn1, cardColumn2, cardRow1, cardRow2));

        }

            public IEnumerator PostTileCombinations(int cardColumn1, int cardColumn2, int cardRow1, int cardRow2)
            {
                TileCombination tempCombination = new TileCombination()
                {
                    CardColumn1 = cardColumn1,
                    CardColumn2 = cardColumn2,
                    CardRow1 = cardRow1,
                    CardRow2 = cardColumn2

                };
                string json = JsonConvert.SerializeObject(tempCombination);
                UnityWebRequest uwr = UnityWebRequest.Put(tileCombinationString, json);
                uwr.SetRequestHeader("content-type", "application/json");
                uwr.method = "POST";

                yield return uwr.SendWebRequest();

                if (uwr.result != UnityWebRequest.Result.Success)
                {

                    Debug.Log("put did not succeed");
                }
                else
                {
                    string returnJson = uwr.downloadHandler.text;
                    TileCombination returnCombination = JsonConvert.DeserializeObject<TileCombination>(returnJson);
                }



            }






        
    }
}

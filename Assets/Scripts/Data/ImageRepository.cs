using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using Newtonsoft.Json;
using System.Linq;

public class ImageRepository : Singleton<ImageRepository>
{

    string urlMemoryImages = "https://localhost:44304/api/Image";

    public void ProcessImageIds(Action<List<int>> processIds)
    {
        StartCoroutine(GetImageIDs(processIds));
    }

    private IEnumerator GetImageIDs(Action<List<int>> processIds)
    {
        UnityWebRequest uwrids = UnityWebRequest.Get(urlMemoryImages);
        yield return uwrids.SendWebRequest();
        if (uwrids.result != UnityWebRequest.Result.Success)
        {
            Debug.Log("imagerepository.getimageIDs: " + uwrids.error);
        }
        else
        {
            string json = uwrids.downloadHandler.text;
            List<ImageObject> images = JsonConvert.DeserializeObject<List<ImageObject>>(json);
            List<int> imagedBids = images.Select(i => i.ImageID).ToList();
            processIds(imagedBids);
        }


    }


    public void GetProcessTexture(int imgdib, Action<Texture2D> processTexture)
    {
        StartCoroutine(GetTextures(imgdib, processTexture));
    }

    private IEnumerator GetTextures(int imgdib, Action<Texture2D> processTexture)
    {
        UnityWebRequest uwr = UnityWebRequestTexture.GetTexture(urlMemoryImages + "/" + imgdib);
        yield return uwr.SendWebRequest();
        if (uwr.result != UnityWebRequest.Result.Success)
        {
            Debug.Log("ImageRepository.GetProcessMaterials: " + uwr.error);
        }
        else
        {
            Texture2D texture = DownloadHandlerTexture.GetContent(uwr);
            processTexture(texture);
                 
        }
    }

}

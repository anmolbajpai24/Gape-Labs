using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

public class LoadAssetBundles : MonoBehaviour
{
    // Replace with your cloud storage Asset Bundle URL
    public string assetBundleURL;

    // Name of the asset you want to load from the Asset Bundle
    public string assetName;

    void Start()
    {
        StartCoroutine(DownloadAndLoadAssetBundle(assetBundleURL, assetName));
    }

    IEnumerator DownloadAndLoadAssetBundle(string url, string assetNameToLoad)
    {
        using (UnityWebRequest request = UnityWebRequest.Get(url))
        {
            request.downloadHandler = new DownloadHandlerAssetBundle(url, 0);
            yield return request.SendWebRequest();

            if (request.result == UnityWebRequest.Result.Success)
            {
                AssetBundle bundle = DownloadHandlerAssetBundle.GetContent(request);
                GameObject loadedAsset = bundle.LoadAsset<GameObject>(assetNameToLoad);
                Instantiate(loadedAsset);
                bundle.Unload(false);
            }
            else
            {
                Debug.LogError("Failed to download Asset Bundle: " + request.error);
            }
        }
    }
}

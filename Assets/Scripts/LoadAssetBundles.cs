using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

public class LoadAssetBundles : MonoBehaviour
{
    // Replace with your cloud storage Asset Bundle URL
    public string assetBundleURL;

    // The loaded prefabs
    public GameObject playerManagerPrefab;
    public GameObject bulletPrefab;
    public GameObject playerPrefab;

    public event Action OnAssetBundleLoaded;

    void Start()
    {
        StartCoroutine(DownloadAndLoadAssetBundle(assetBundleURL));
    }

    IEnumerator DownloadAndLoadAssetBundle(string url)
    {
        using (UnityWebRequest request = UnityWebRequest.Get(url))
        {
            request.downloadHandler = new DownloadHandlerAssetBundle(url, 0);
            yield return request.SendWebRequest();

            if (request.result == UnityWebRequest.Result.Success)
            {
                AssetBundle bundle = DownloadHandlerAssetBundle.GetContent(request);

                playerManagerPrefab = bundle.LoadAsset<GameObject>("PlayerManager");
                bulletPrefab = bundle.LoadAsset<GameObject>("Bullet");
                playerPrefab = bundle.LoadAsset<GameObject>("Player");

                // Add the loaded prefabs to the custom prefab pool
                CustomPrefabPool prefabPool = FindObjectOfType<CustomPrefabPool>();
                if (prefabPool != null)
                {
                    prefabPool.AddPrefab(playerManagerPrefab);
                    prefabPool.AddPrefab(bulletPrefab);
                    prefabPool.AddPrefab(playerPrefab);
                }
                else
                {
                    Debug.LogError("CustomPrefabPool not found in the scene.");
                }

                bundle.Unload(false);
            }
            else
            {
                Debug.LogError("Failed to download Asset Bundle: " + request.error);
            }
        }
    }
}

using Photon.Pun;
using UnityEngine;

public class PhotonPrefabSpawner : MonoBehaviour
{
    public LoadAssetBundles AssetBundleLoader;

    void Start()
    {
        // Subscribe to the OnAssetBundleLoaded event
        AssetBundleLoader.OnAssetBundleLoaded += SpawnPrefab;
        SpawnPrefab();
    }

    private void OnDestroy()
    {
        // Unsubscribe from the OnAssetBundleLoaded event to avoid memory leaks
        AssetBundleLoader.OnAssetBundleLoaded -= SpawnPrefab;
    }

    private void SpawnPrefab()
    {
        if (AssetBundleLoader.playerPrefab != null)
        {
            // Get the custom prefab pool
            CustomPrefabPool prefabPool = FindObjectOfType<CustomPrefabPool>();

            if (prefabPool != null)
            {
                // Instantiate the prefab using the custom prefab pool
                prefabPool.Instantiate(AssetBundleLoader.playerPrefab.name, transform.position, transform.rotation);
            }
            else
            {
                Debug.LogError("CustomPrefabPoolList not found in the scene.");
            }
        }
        else
        {
            Debug.LogError("playerManagerPrefab is null.");
        }
    }
}

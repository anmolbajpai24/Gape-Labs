using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;

public class CustomPrefabPool : MonoBehaviour, IPunPrefabPool
{
    private List<GameObject> prefabList;

    public CustomPrefabPool()
    {
        prefabList = new List<GameObject>();
    }

    public void AddPrefab(GameObject prefab)
    {
        if (!prefabList.Contains(prefab))
        {
            prefabList.Add(prefab);
        }
    }

    public GameObject Instantiate(string prefabId, Vector3 position, Quaternion rotation)
    {
        foreach (GameObject prefab in prefabList)
        {
            if (prefab.name == prefabId)
            {
                return Instantiate(prefab, position, rotation);
            }
        }

        Debug.LogError($"Prefab with ID {prefabId} not found in CustomPrefabPoolList.");
        return null;
    }

    public void Destroy(GameObject gameObject)
    {
        Destroy(gameObject);
    }
}

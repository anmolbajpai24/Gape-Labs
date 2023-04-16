using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using System.IO;


public class PlayerManager : MonoBehaviour
{
    PhotonView photonView;
    public LoadAssetBundles AssetBundleLoader;

    private void Awake()
    {
        photonView = GetComponent<PhotonView>();
    }
    // Start is called before the first frame update
    void Start()
    {
        // It returns true if photon view is by local player
        if (photonView.IsMine)
        {
            CreateController();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void CreateController()
    {
        Debug.Log("Controller");
        CustomPrefabPool prefabPool = FindObjectOfType<CustomPrefabPool>();

        PhotonNetwork.Instantiate(AssetBundleLoader.playerPrefab.name, transform.position, transform.rotation);

        //prefabPool.Instantiate(AssetBundleLoader.playerPrefab.name, transform.position, transform.rotation);
        PhotonNetwork.Instantiate(Path.Combine("PhotonPrefabs", "PlayerController"), Vector3.zero, Quaternion.identity);
    }
}

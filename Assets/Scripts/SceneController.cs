using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Photon.Pun;
using System.IO;

public class SceneController : MonoBehaviourPunCallbacks
{
    public string targetSceneName;
    //public GameObject objectToInstantiate;
    public Vector3 instantiatePosition;

    public override void OnEnable()
    {
        base.OnEnable();
        DontDestroyOnLoad(this.gameObject);
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    public override void OnDisable()
    {
        base.OnDisable();
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == targetSceneName)
        {
            PhotonNetwork.Instantiate(Path.Combine("PhotonPrefabs", "PlayerManager"), Vector3.zero, Quaternion.identity);
            Debug.Log("YOYO");

           // Instantiate(objectToInstantiate, instantiatePosition, Quaternion.identity);
        }
    }
}

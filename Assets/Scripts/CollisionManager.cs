using System.Collections;
using UnityEngine;
using Photon.Pun;

public class CollisionManager : MonoBehaviour
{
    public static CollisionManager instance;
    public int damage = 5;

    private void Awake()
    {
        if (instance)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
    }

    public void OnCollisionEnter(Collision collision)
    {
        GameObject hitObject = collision.gameObject;
        

        Health health = hitObject.GetComponent<Health>();

        
        if (health != null)
        {
            if (PhotonNetwork.IsConnected)
            {
                health.photonView.RPC("TakeDamage", RpcTarget.All, damage);
                Debug.Log(hitObject.GetPhotonView() + "IS THE HIT OBJECT" );
            }
            else
            {
               // health.TakeDamage(damage);
            }
        }

        
        Destroy(gameObject, 0.1f);
    }

   
}

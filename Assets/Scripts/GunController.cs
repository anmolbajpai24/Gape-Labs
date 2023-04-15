using System.Collections;
using UnityEngine;
using Photon.Pun;

public class GunController : MonoBehaviourPunCallbacks
{
    public GameObject bulletPrefab;
    public GameObject bulletSpawnPoint;

    public float bulletSpeed = 1f;
    public float bulletLifetime = 0.1f;

    

    void FixedUpdate()
    {
        if (Input.GetButton("Fire1") )
        {
            
            photonView.RPC("Shoot", RpcTarget.All);
        }
    }

    [PunRPC]
    public void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, bulletSpawnPoint.transform.position, bulletSpawnPoint.transform.rotation);

        Rigidbody bulletRb = bullet.GetComponent<Rigidbody>();
       
        
        bulletRb.velocity = bulletSpawnPoint.transform.forward * bulletSpeed;
        Destroy(bullet, bulletLifetime);
    }

}

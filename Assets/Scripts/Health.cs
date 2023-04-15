using UnityEngine;
using Photon.Pun;
using UnityEngine.UI;
using TMPro;
using Photon.Realtime;
using System.Collections;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviourPunCallbacks
{
    public int maxHealth = 100;

    public int currentHealth;
    public TextMeshProUGUI HealthText;
    public string gameOverScene = "GameOver";
    
    private string healthKey = "currentHealth";

    void Start()
    {
        if (photonView.IsMine)
        {
            currentHealth = maxHealth;
          
        }
    }

    [PunRPC]
    public void TakeDamage(int damage, PhotonMessageInfo info)
    {
        
        if (photonView.IsMine)
        {
            currentHealth -= damage;
            currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);

            if (currentHealth <= 0)
            {
                Die();
            }
        }
    }

    private void Die()
    {
      
        Debug.Log("Player died");
        

        if (photonView.IsMine)
        {
            if (CollisionManager.instance)
              

            PhotonNetwork.Destroy(gameObject);
            PhotonNetwork.LoadLevel(gameOverScene);


        }
                
    }


    public void Update()
    {
        Debug.Log(currentHealth);
    }
}

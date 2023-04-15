using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using TMPro;

public class DisplayHealth : MonoBehaviour
{

    public Health player1Health;
    public Health player2Health;
    public TextMeshProUGUI player1HealthText;
    public TextMeshProUGUI player2HealthText;

    private void Awake()
    {
        
    }

    void Update()
    {
        
        GameObject[] playerObjects = GameObject.FindGameObjectsWithTag("Player");

        foreach (GameObject playerObject in playerObjects)
        {
            PhotonView playerPhotonView = playerObject.GetComponent<PhotonView>();

            
            if (playerPhotonView != null)
            {
                if (playerPhotonView.Owner.ActorNumber == 1)
                {
                    player1Health = playerObject.GetComponent<Health>();
                }
                else if (playerPhotonView.Owner.ActorNumber == 2)
                {
                    player2Health = playerObject.GetComponent<Health>();
                }
            }
        }

        if (player1Health != null)
        {
            player1HealthText.text = "Player 1 Health: " + player1Health.currentHealth;
        }
        else
        {
            player1HealthText.text = "Player 1 not found";
        }

        if (player2Health != null)
        {
            player2HealthText.text = "Player 2 Health: " + player2Health.currentHealth;
        }
        else
        {
            player2HealthText.text = "Player 2 not found";
        }
    }
}

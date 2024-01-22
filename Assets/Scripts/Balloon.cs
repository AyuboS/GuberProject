using UnityEngine;
using UnityEngine.UI;

public class Balloon : MonoBehaviour
{

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerCollision player = other.GetComponent<playerCollision>();
            if (player != null)
            {
                player.CollectBalloon();
                gameObject.SetActive(false); 
            }
        }
    }
}

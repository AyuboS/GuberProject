using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerCollision : MonoBehaviour
{
    [SerializeField] Text T_GameOver;
    [SerializeField] Text T_BallonMessage;
    [SerializeField] playerMovement PlayerMovement;
    private bool hasGreenBalloon = false;
    private bool balloonUsed = false;

    private void OnCollisionEnter(Collision collision)
    {
        switch (collision.gameObject.tag)
        {
            case "Obstacle":
                T_GameOver.gameObject.SetActive(true);
                StopPlayerMovement();
                break;
        }

        if (collision.gameObject.CompareTag("GreenWall"))
        {
            if (!hasGreenBalloon || balloonUsed)
            {
                PlayerMovement.rb.velocity = new Vector3(PlayerMovement.rb.velocity.x, PlayerMovement.rb.velocity.y, 0);
            }
            else
            {
                collision.gameObject.SetActive(false);
                T_BallonMessage.gameObject.SetActive(false);
                balloonUsed = true;
            }
        }
    }

    private void StopPlayerMovement()
    {
        PlayerMovement.rb.velocity = Vector3.zero;
        PlayerMovement.rb.angularVelocity = Vector3.zero;
        PlayerMovement.enabled = false;
    }

    public void CollectBalloon()
    {
        hasGreenBalloon = true;
        balloonUsed = false;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("GreenBalloon"))
        {
            T_BallonMessage.gameObject.SetActive(true);
            CollectBalloon();
            other.gameObject.SetActive(false);
        }
    }
}

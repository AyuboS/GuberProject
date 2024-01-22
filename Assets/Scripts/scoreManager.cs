using UnityEngine;
using UnityEngine.UI; 

public class scoreManager : MonoBehaviour
{
    public Text scoreText; 
    public Text moneyText; 
    private float score = 0;
    private int moneyCount = 0;
    public Transform playerTransform;
    private Vector3 lastPosition;

    void Start()
    {
        lastPosition = playerTransform.position;
    }

    void Update()
    {

        float distance = Vector3.Distance(playerTransform.position, lastPosition);
        score += distance;
        scoreText.text = "Score: " + Mathf.FloorToInt(score).ToString();
        lastPosition = playerTransform.position;

        moneyText.text = "Money: " + moneyCount.ToString();
    }

    public void AddMoney(int amount)
    {
        moneyCount += amount;
    }
}

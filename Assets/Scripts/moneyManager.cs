using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class moneyManager : MonoBehaviour
{
    public int moneyValue = 1;

    private Vector3 rotationSpeed;
    private float randomRotSpeed;
    private void Start()
    {
        randomRotSpeed = Random.Range(15f, 30f);
        rotationSpeed = new Vector3(0, randomRotSpeed, 0);
    }
    void Update()
    {
        transform.Rotate(rotationSpeed * Time.deltaTime, Space.World);
    }



    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            scoreManager scoreManager = FindObjectOfType<scoreManager>();
            scoreManager.AddMoney(moneyValue);
            Destroy(gameObject);
        }
    }
}

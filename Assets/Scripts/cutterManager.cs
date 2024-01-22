using UnityEngine;

public class cutterManager : MonoBehaviour
{
    public Transform pointA;
    public Transform pointB;
    public float speed = 2.0f;

    private float timeCounter = 0;

    void Update()
    {

        timeCounter += Time.deltaTime * speed;
        transform.position = Vector3.Lerp(pointA.position, pointB.position, Mathf.PingPong(timeCounter, 1));
    }

}

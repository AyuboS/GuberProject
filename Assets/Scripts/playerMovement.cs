using UnityEngine;

public class playerMovement : MonoBehaviour
{
    public float rotationSpeed = 5.0f;
    public float forwardSpeed = 5.0f;
    public float jumpForce = 300.0f;
    private float[] lanes = { -3.5f, 0f, 3.5f };
    private int currentLane = 1;
    public Rigidbody rb;
    private bool isGrounded = true;
    private Vector3 targetPosition;
    public bool isMovingForward = false;


    void Start()
    {
        rb = GetComponent<Rigidbody>();
        targetPosition = new Vector3(lanes[currentLane], transform.position.y, transform.position.z);
    }

    void Update()
    {

        if (Input.GetKeyDown(KeyCode.A) && currentLane > 0)
        {
            currentLane--;
            UpdateTargetPosition();
        }
        else if (Input.GetKeyDown(KeyCode.D) && currentLane < lanes.Length - 1)
        {
            currentLane++;
            UpdateTargetPosition();
        }


        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(Vector3.up * jumpForce);
            isGrounded = false;
        }


        if (Input.GetKey(KeyCode.W))
        {
            isMovingForward = true;
        }
        else
        {
            isMovingForward = false;
        }
    }

    void FixedUpdate()
    {

        if (isMovingForward)
        {
            rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y, forwardSpeed);
        }


        transform.position = Vector3.MoveTowards(transform.position, targetPosition, rotationSpeed * Time.fixedDeltaTime);
    }

    private void UpdateTargetPosition()
    {
        targetPosition = new Vector3(lanes[currentLane], transform.position.y, transform.position.z);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Road")
        {
            isGrounded = true;
        }
    }


}

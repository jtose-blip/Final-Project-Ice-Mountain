using UnityEngine;
using TMPro;

public class PlayerController : MonoBehaviour
{
    public float movementSpeed = 2.5f;
    public float verticalInput;
    public float horizontalInput;
    public float jumpForce = 10;
    public bool onGround = true;
    private Rigidbody  playerRb;
    public float gravityModifier;
    public float fallYLimit = -10f; //If player falls below this value
    public GameManager gameManager;
  
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        Physics.gravity *= gravityModifier;
    }

    // Update is called once per frame
    void Update()
    {
        // vertical movement
        verticalInput = Input.GetAxis("Vertical");
        //transform.Translate(Vector3.forward * verticalInput * Time.deltaTime * movementSpeed);

        // horizontal movement
        horizontalInput = Input.GetAxis("Horizontal");
        //transform.Translate(Vector3.right * horizontalInput * Time.deltaTime * movementSpeed);

        if (Input.GetKeyDown(KeyCode.Space) && onGround) 
        {
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            onGround = false;
        }

        if (transform.position.y < -10)
        {
            Destroy(gameObject);
            gameManager.GameOver();
        }
    }
    
    private void FixedUpdate()
    {
        playerRb.AddForce(transform.forward * verticalInput * movementSpeed, ForceMode.Force);
        playerRb.AddForce(transform.right * horizontalInput * movementSpeed, ForceMode.Force);

    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            onGround = true;
        }

        if (collision.gameObject.CompareTag("Icicle"))
        {
           Destroy(gameObject);
        }
    }
}

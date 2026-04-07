using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    CharacterController cc;

    public float speed = 12f;

    public float gravity = -9.8f;

    Vector3 velocity;
    //JUMP
    public float jumpHeight = 1.0f;

    //BOOL per il JUMP
    bool groundedPlayer;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        cc = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        //JUMP unico che non si ripete all'infinito
        groundedPlayer = cc.isGrounded;

        if (groundedPlayer && velocity.y < 0)
        {
            velocity.y = -2f;
        }
        //MOVIMENTO
        float x = Input.GetAxis("Horizontal");
        float z= Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;
        

        //JUMP
        if (Input.GetButtonDown("Jump") && groundedPlayer)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -3.0f* gravity);
        }

        velocity.y += gravity * Time.deltaTime;
        cc.Move((move * speed + velocity) * Time.deltaTime);
    }
}

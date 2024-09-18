using UnityEngine;

public class Player_move : MonoBehaviour
{
    public CharacterController controller;
    public float speed = 12f;
    public float rotateSpeed = 10f;
    public float gravity = -9.81f;
    private Vector3 velocity;
    public Transform playerBody;

    void Start()
    {

    }

    void Update()
    {

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = playerBody.forward * z;
        controller.Move(move * speed * Time.deltaTime);
        transform.Rotate(Vector3.up * x * rotateSpeed * Time.deltaTime);

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMove : MonoBehaviour
{
    public float moveSpeed = 10.0f;
    public Transform cameraTransform;
    CharacterController characterController = null;

    float yVelocity = 0.0f;
    public float gravity = -2000.0f;

    public float jumpSpeed = 10.0f;

    public PlayerState playerState;
    // Start is called before the first frame update
    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerState.isDead)
            return;
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        Vector3 moveDirection = new Vector3(x, 0, z);
        moveDirection = cameraTransform.TransformDirection(moveDirection);
        moveDirection *= moveSpeed;
        characterController.Move(moveDirection * Time.deltaTime);

        if (Input.GetButtonDown("Jump"))
        {
            yVelocity = jumpSpeed;
        }
        yVelocity += gravity * Time.deltaTime;
        moveDirection.y = yVelocity;

        characterController.Move(moveDirection * Time.deltaTime);

        if (characterController.collisionFlags == CollisionFlags.Below)
        {
            yVelocity = 0.0f;
        }
        
    }
}

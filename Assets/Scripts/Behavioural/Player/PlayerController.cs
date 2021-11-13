using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float movementSpeed;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private Transform groundCheck;
    
    private InputReceiver inputReceiver;
    private CharacterController characterController;

    private Vector3 velocity;
    private bool isGrounded;

    private void Awake()
    {
        characterController = GetComponent<CharacterController>();
        inputReceiver = GetComponent<InputReceiver>();

        Time.timeScale = 1;
    }
    private void Update()
    {
        PlayerMovement();
    }

    private void PlayerMovement()
    {
        //ground check
        isGrounded = Physics.CheckSphere(groundCheck.position, 0.1f, groundLayer, QueryTriggerInteraction.Ignore);
        if (isGrounded && velocity.y < 0f)
        {
            velocity.y = 0;
        }
        else
        {
            velocity.y += -50f * Time.deltaTime;
        }

        //horizontal
        characterController.Move(new Vector3(inputReceiver.HorizontalInput * movementSpeed, 0, 1 * movementSpeed) * Time.deltaTime);

        //zýplama
        if (isGrounded && inputReceiver.IsJumping)
        {
            velocity.y += Mathf.Sqrt(10f * movementSpeed);
        }
        characterController.Move(velocity * Time.deltaTime);
    }
}

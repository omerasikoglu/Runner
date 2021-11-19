using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private D_Player data;
    [SerializeField] private Transform groundCheck;
    private void Awake()
    {
        Application.targetFrameRate =60;
        Time.timeScale = 1;
        data.rigidbody = GetComponent<Rigidbody>();
    }
    private void Update()
    {
        Move();
        FallCheck();
        GroundCheck();
    }

    private void GroundCheck()
    {
        data.isGrounded = Physics.Raycast(groundCheck.transform.position, Vector3.down, data.groundDistance, data.groundLayer);
    }

    private void Move()
    {
        if (Time.timeScale != 0)
        {
            transform.Translate(data.velocity.x * data.MovementSpeed, 0, data.MovementSpeed);
        }
    }

    private void FallCheck()
    {
        if (transform.position.y <= -1f) ScoreboardUI.Instance.UpdateScore();
    }

    //Unity Input System
    void OnMovement(InputValue movementInput)
    {
        Vector2 input = movementInput.Get<Vector2>();
        data.velocity.x = input.x;

    }
    void OnButton1Action()
    {
        //Jump
        if (data.isGrounded)
        {
            data.rigidbody.AddForce(Vector3.up * data.JumpForce, ForceMode.Impulse);
        }
    }
}

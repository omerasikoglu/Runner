using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Data/Player")]
public class D_Player : ScriptableObject
{
    [SerializeField] private float _jumpforce = 15;
    [SerializeField] private float _movementSpeed = 0.1f;

    //Ground Check
    public LayerMask groundLayer;
    public bool isGrounded;
    public float groundDistance = 0.5f;

    //Movement
    public float MovementSpeed { get { return _movementSpeed; } }
    public float JumpForce { get { return _jumpforce; } }
    public Rigidbody rigidbody;
    public Vector3 velocity;
}

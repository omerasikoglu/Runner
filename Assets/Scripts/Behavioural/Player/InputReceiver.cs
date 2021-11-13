using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputReceiver : MonoBehaviour
{
    //command pattern
    [SerializeField] private KeyCode jumpingButton;

    private const string HORIZONTAL = "Horizontal";

    public bool IsJumping { get; private set; }
    public float HorizontalInput { get; private set; }
    private void Update()
    {
        ReceiveAxisInput();
        ReceiveButtonsInput();
    }
    private void ReceiveAxisInput()
    {
        HorizontalInput = Input.GetAxis(HORIZONTAL);
    }
    private void ReceiveButtonsInput()
    {
        IsJumping = Input.GetKeyDown(jumpingButton);
    }


}

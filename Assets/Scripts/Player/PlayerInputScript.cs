using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputScript : MonoBehaviour
{   
    private PlayerInput playerInput;

    private PlayerMovement playerMovement;

    private InputAction pressAction, positionAction;

    private float deltaX;

    private void Awake()
    {
        playerInput = GetComponent<PlayerInput>();
        playerMovement = GetComponent<PlayerMovement>();

        pressAction = playerInput.actions.FindAction("Press");
        positionAction = playerInput.actions.FindAction("Position");
    }

    private void Update()
    {
        if (pressAction.WasPressedThisFrame())
            deltaX = positionAction.ReadValue<Vector2>().x;

        if (pressAction.WasReleasedThisFrame())
        {
            deltaX -= positionAction.ReadValue<Vector2>().x;

            if (deltaX > 200f)
                playerMovement.MoveLeft();

            if (deltaX < -200f)
                playerMovement.MoveRight();
        }
    }
}

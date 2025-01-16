using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputScript : MonoBehaviour
{
    private PlayerMovement playerMovement;

    private MobileInputActions mobileInputActions;

    private KeyboardInputAction keyboardInputAction;

    private InputAction pressAction, positionAction;

    private float deltaX;

    private void Awake()
    {
        playerMovement = GetComponent<PlayerMovement>();

        mobileInputActions = new MobileInputActions();
        keyboardInputAction = new KeyboardInputAction();
    }

    private void OnEnable()
    {
        mobileInputActions.Enable();
        keyboardInputAction.Enable();

        pressAction = mobileInputActions.Player.Press;
        positionAction = mobileInputActions.Player.Position;

        pressAction.started += SavePosition;
        pressAction.canceled += CalcPosition;

        keyboardInputAction.Player.Movement.started += Movement;
    }

    private void Movement(InputAction.CallbackContext context)
    {
        if (context.ReadValue<float>() == -1) playerMovement.MoveLeft();
        else playerMovement.MoveRight();
    }

    private void SavePosition(InputAction.CallbackContext context)
    {
        deltaX = positionAction.ReadValue<Vector2>().x;
    }

    private void CalcPosition(InputAction.CallbackContext context)
    {
        deltaX -= positionAction.ReadValue<Vector2>().x;

        if (deltaX > 200f) playerMovement.MoveLeft();
        if (deltaX < -200f) playerMovement.MoveRight();
    }

    private void OnDisable()
    {
        mobileInputActions.Disable();
        keyboardInputAction.Disable();
    }
}

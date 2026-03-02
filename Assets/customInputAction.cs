using UnityEngine;
using UnityEngine.InputSystem;


public class customInputAction : MonoBehaviour
{

    public InputActionProperty buttonAction;
    public MeshRenderer mesh;

    private void OnEnable()
    {
        buttonAction.action.Enable();

        buttonAction.action.started += OnButtonPressed;
        buttonAction.action.canceled += OnButtonReleased;
    }

    private void OnDisable()
    {
        buttonAction.action.started -= OnButtonPressed;
        buttonAction.action.canceled -= OnButtonReleased;

        buttonAction.action.Disable();
    }

    private void OnButtonPressed(InputAction.CallbackContext context)
    {
        ButtonWasPressed();
    }

    private void OnButtonReleased(InputAction.CallbackContext context)
    {
        ButtonWasReleased();
    }

    private void ButtonWasPressed()
    {
        Debug.Log("Button Was Pressed");

        mesh.enabled = false;
    }

    private void ButtonWasReleased()
    {
        Debug.Log("Button Was Released");

        mesh.enabled = true;
    }
}
 
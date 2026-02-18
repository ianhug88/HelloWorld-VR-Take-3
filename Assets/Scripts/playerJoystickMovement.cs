using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class PlayerJoystickMover : MonoBehaviour
{
    public Rigidbody body;              // Your PlayerBody Rigidbody
    public XRNode inputSource = XRNode.LeftHand;  // Use left joystick
    public float moveSpeed = 2f;

    private Vector2 inputAxis;

    void FixedUpdate()
    {
        // Read joystick input
        InputDevice device = InputDevices.GetDeviceAtXRNode(inputSource);
        if (device.TryGetFeatureValue(CommonUsages.primary2DAxis, out Vector2 axisValue))
        {
            inputAxis = axisValue;
        }
        else
        {
            inputAxis = Vector2.zero;
        }

        // Move relative to the camera's forward direction
        Transform cam = Camera.main.transform;

        Vector3 forward = cam.forward;
        forward.y = 0;           // flatten
        forward.Normalize();

        Vector3 right = cam.right;
        right.y = 0;
        right.Normalize();

        Vector3 move = forward * inputAxis.y + right * inputAxis.x;
        move *= moveSpeed;

        // Apply as velocity
        body.linearVelocity = new Vector3(move.x, body.linearVelocity.y, move.z);
    }
}

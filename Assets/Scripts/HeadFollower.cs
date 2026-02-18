using UnityEngine;
using UnityEngine.XR;

public class HeadFollower : MonoBehaviour
{
    public Rigidbody body;

    public float followStrength = 50f;
    public float maxSpeed = 3f;

    void FixedUpdate()
    {
        InputDevice headDevice = InputDevices.GetDeviceAtXRNode(XRNode.Head);
        PlayerJoystickMover rb = GetComponent<PlayerJoystickMover>();
        rb.enabled = false;

        if (headDevice.TryGetFeatureValue(CommonUsages.devicePosition, out Vector3 headPos))
        {
            headPos.y = 0f;

            Vector3 desiredVelocity = headPos * followStrength;
            desiredVelocity = Vector3.ClampMagnitude(desiredVelocity, maxSpeed);

            body.linearVelocity = new Vector3(
                desiredVelocity.x,
                body.linearVelocity.y,
                desiredVelocity.z
            );
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        //collision.rigidbody.gameObject.GetComponent<Ragdoller>()
    }
}
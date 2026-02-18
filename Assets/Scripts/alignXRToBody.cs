using UnityEngine;

public class AlignXRToBody : MonoBehaviour
{
    public Transform playerBody;
    public Transform head;

    void Start()
    {
        // Get horizontal offset between XR Origin and head
        Vector3 offset = head.position - transform.position;
        offset.y = 0f;

        // Move XR Origin so head aligns with player body center
        transform.position = playerBody.position - offset;
    }
}

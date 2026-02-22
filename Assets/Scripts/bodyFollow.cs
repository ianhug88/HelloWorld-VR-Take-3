using UnityEngine;

public class bodyFollow : MonoBehaviour
{
    Rigidbody rb;

    public Transform cameraTransform;

    private bool physicsEnabled = false;

    [SerializeField]
    private Vector3 cameraOffset;




    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();

        disableRbPhysics();

    }


    private void FixedUpdate()
    {
        if (!physicsEnabled)
        {
            //// sets the transform of the playerBody to the position of the main camera
            //rb.MovePosition(cameraTransform.position);

            Vector3 targetPosition = cameraTransform.position - cameraOffset;
            rb.MovePosition(targetPosition);
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Obstacle")
        {
            enableRbPhysics();
        }
    }

    public void enableRbPhysics()
    {
        physicsEnabled = true;
        rb.isKinematic = false;
        rb.useGravity = true;
        rb.constraints = RigidbodyConstraints.None;
    }

    public void disableRbPhysics()
    {
        physicsEnabled = false;
        rb.isKinematic = true;
        rb.useGravity = false;
        rb.constraints = 
            RigidbodyConstraints.FreezeRotationY |
            RigidbodyConstraints.FreezeRotationX |
            RigidbodyConstraints.FreezeRotationZ;
    }
}

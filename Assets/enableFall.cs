using UnityEngine;

public class enableFall : MonoBehaviour
{

    Rigidbody rb;

    private bool fallEnabled = false;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        rb = GetComponent<Rigidbody>();



    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Obstacle")
        {
            enableRbFall();
        }
    }

    public void enableRbFall()
    {
        fallEnabled = true;
        //rb.isKinematic = false;
        //rb.useGravity = true;
        rb.constraints = RigidbodyConstraints.None;
    }

    public void disableRbFall()
    {
        fallEnabled = false;
        //rb.isKinematic = true;
        //rb.useGravity = false;
        rb.constraints =
            RigidbodyConstraints.FreezeRotationY |
            RigidbodyConstraints.FreezeRotationX |
            RigidbodyConstraints.FreezeRotationZ;
    }


}

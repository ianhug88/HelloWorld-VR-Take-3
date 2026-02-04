using UnityEngine;

public class lookAt : MonoBehaviour
{
    public Transform targetTransform;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 relativePos = targetTransform.position - transform.position;

        Quaternion newRot = Quaternion.LookRotation(relativePos, Vector3.up);
        transform.rotation = newRot;
        
    }
}

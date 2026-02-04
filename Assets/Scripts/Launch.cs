using UnityEngine;

public class Launch : MonoBehaviour
{
    public Vector3 Velocity;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
   
        gameObject.transform.position = new Vector3(transform.position.x + (Time.deltaTime * Velocity.x), 
            transform.position.y + (Time.deltaTime * Velocity.y),
            transform.position.z + (Time.deltaTime * Velocity.z));
    }
}

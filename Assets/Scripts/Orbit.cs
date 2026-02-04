using UnityEngine;

public class Orbit : MonoBehaviour
{
    //public Vector3 Velocity;
    public float Speed;
    public float Radius;
    private float Angle;
    private float Origin;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Origin = gameObject.transform.position.x - Radius;
        Angle = 0;
    }

    // Update is called once per frame
    void Update()
    {
        Angle += Speed * Time.deltaTime;

        //gameObject.transform.position = new Vector3(transform.position.x + Radius * Mathf.Sin(Angle), 
        //    transform.position.y, transform.position.z + Radius * Mathf.Cos(Angle));

        float x = Radius * Mathf.Sin(Angle);
        float z = Radius * Mathf.Cos(Angle);

        gameObject.transform.position = new Vector3(x, 10, z);




    }
}

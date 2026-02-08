using UnityEngine;
//Anthony Varela, Ian Hughes, 2026
public class Spin : MonoBehaviour{
    public Vector3 axisRotating = Vector3.right; //we make the cylinder a vector for the x axis
    public float speed = 80f; //speed the vector (axis) is going to move
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(axisRotating * speed * Time.deltaTime); //rotate the x axis times the speed times the fps. 
    }
}

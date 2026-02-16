using UnityEngine;

public class SidetoSide : MonoBehaviour{

    public float speed = 2.0f; //the speed we want the object to move
    public float distance = 3f; //the distance we wnat it to travel from 
    private Vector3 startPos; //the starting position

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        startPos = transform.position; //the start position is the current position of the object
    }

    // Update is called once per frame
    void Update()
    {
        float movement = Mathf.PingPong(Time.time * speed, distance); //updates every second until it reaches distance and goes back, ping pong method. 
        transform.position = startPos + new Vector3 (0, 0, movement); //update the position of the transfrom by adding the current position and moving the z axis
    }
}

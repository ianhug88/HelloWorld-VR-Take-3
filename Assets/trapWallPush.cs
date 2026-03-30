using System.Collections;
using UnityEngine;

public class trapWallPush : MonoBehaviour
{
    public float moveDistance = 5f;
    public float moveSpeed = 10f;
    public float pauseTime = 0.2f;
    public Vector3 moveDirection = Vector3.forward;

    private Vector3 startPosition;
    private bool isMoving = false;

    private void Start()
    {
        startPosition = transform.position;
    }

    public void Activate()
    {
        if (!isMoving)
        {
            StartCoroutine(FireRoutine());
        }
    }

    private IEnumerator FireRoutine()
    {
        isMoving = true;

        Vector3 targetPosition = startPosition + moveDirection.normalized * moveDistance;

        // Move forward
        while (Vector3.Distance(transform.position, targetPosition) > 0.01f)
        {
            transform.position = Vector3.MoveTowards(
                transform.position,
                targetPosition,
                moveSpeed * Time.deltaTime
            );
            yield return null;
        }

        // Pause at full extension
        yield return new WaitForSeconds(pauseTime);

        // Move back
        while (Vector3.Distance(transform.position, startPosition) > 0.01f)
        {
            transform.position = Vector3.MoveTowards(
                transform.position,
                startPosition,
                moveSpeed * Time.deltaTime
            );
            yield return null;
        }

        isMoving = false;
    }
}





















////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

//using UnityEngine;
//public class trapWallPush : MonoBehaviour
//{

//    public GameObject triggerBox;

//    public float speed = 2.0f; //the speed we want the object to move
//    public float distance = 3f; //the distance we wnat it to travel from 
//    private Vector3 startPos; //the starting position

//    public bool trapActive = false;

//    // Start is called once before the first execution of Update after the MonoBehaviour is created
//    void Start()
//    {
//        startPos = transform.position; //the start position is the current position of the object
//    }
//    public void activate()
//    {
//        trapActive = true;
//    }

//    // Update is called once per frame
//    void Update()
//    {
//        if (trapActive == true)
//        {
//            TrapActivate(); 
//        }

//    }




//    private void TrapActivate()
//    {
//        float movement = Mathf.PingPong(Time.time * speed, distance); //updates every second until it reaches distance and goes back, ping pong method. 
//        transform.position = startPos + new Vector3(movement, 0, 0); //update the position of the transfrom by adding the current position and moving the z axis
//        trapActive = false;
//    }
//}

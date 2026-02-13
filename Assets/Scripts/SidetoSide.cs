using UnityEngine;

public class SidetoSide : MonoBehaviour{

    public float speed = 2.0f;
    public float distance = 3f;
    private Vector3 startPos;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        startPos = transform.position;

    }

    // Update is called once per frame
    void Update()
    {
        float movement = Mathf.PingPong(Time.time * speed, distance);
        transform.position = startPos + new Vector3 (0, 0, movement);
    }
}

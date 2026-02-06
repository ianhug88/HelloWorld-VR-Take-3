using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class wasdMove : MonoBehaviour
{
    public float moveSpeed;
    bool positiveX;
    bool positiveZ;
    bool negativeX;
    bool negativeZ;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (keypressed w == true)
        {
            positiveX = true;
        } else { positiveX = false; };

        if keypressed s  == true){
            negativeX = true;
        } else { }
            gameObject.transform
    }
}

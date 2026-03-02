using System;
using Unity.XR.CoreUtils;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Locomotion.Movement;
using UnityEngine.XR.Interaction.Toolkit.Locomotion.Teleportation;
using UnityEngine.XR.Interaction.Toolkit.Locomotion.Turning;
using UnityEngine.InputSystem.XR;
using UnityEngine.XR.Interaction.Toolkit.Locomotion.Jump;
//using UnityEngine.XR.Interaction.Toolkit.Locomotion.Movement;
//using UnityEngine.XR.Interaction.Toolkit.Locomotion.Turning;

public class enableFall : MonoBehaviour
{

    Rigidbody rb;

    private bool fallEnabled = false;



    ///////////////////// 
    //CHAT GPT CODE

    public TrackedPoseDriver trackedPoseDriver;

    public Transform cameraTransform;

    public ContinuousMoveProvider moveProvider;
    public SnapTurnProvider snapTurnProvider;
    public TeleportationProvider teleportationProvider;
    public JumpProvider jumpProvider;
    ///////////////////// 

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        rb = GetComponent<Rigidbody>();



    }

    //// Update is called once per frame
    //void LateUpdate()
    //{

    //    /////////////////// 
    //    //CHAT GPT CODE
    //    if (fallEnabled)
    //    {
    //        Vector3 localPos = cameraTransform.localPosition;
    //        cameraTransform.localPosition = new Vector3(0, localPos.y, 0);
    //    }
    //    /////////////////// 

    //}


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

        /////////////////// 
        //CHAT GPT CODE
        //if (trackedPoseDriver)
        //    trackedPoseDriver.enabled = false;

        trackedPoseDriver.trackingType =
    TrackedPoseDriver.TrackingType.RotationOnly;

        /////////////////// 
        //CHAT GPT CODE
        rb.interpolation = RigidbodyInterpolation.Interpolate;
        rb.collisionDetectionMode = CollisionDetectionMode.ContinuousDynamic;
        rb.maxAngularVelocity = 5f;

        rb.angularVelocity = Vector3.zero;
        rb.constraints = RigidbodyConstraints.None; // disable all constraints


        /////////////////// 
        //CHAT GPT CODE
        // disable movement providers to make the player inert
        if (moveProvider) moveProvider.enabled = false;
        if (snapTurnProvider) snapTurnProvider.enabled = false;
        if (teleportationProvider) teleportationProvider.enabled = false;
        if (jumpProvider) jumpProvider.enabled = false;
        /////////////////////


    }

    public void disableRbFall()
    {

        /////////////////// 
        //CHAT GPT CODE
        if (trackedPoseDriver)
            trackedPoseDriver.enabled = true;


        fallEnabled = false;
        //rb.isKinematic = true;
        //rb.useGravity = false;
        rb.constraints =
            RigidbodyConstraints.FreezeRotationY |
            RigidbodyConstraints.FreezeRotationX |
            RigidbodyConstraints.FreezeRotationZ;

        ///////////////////// 
        //CHAT GPT CODE
        // disable movement providers to make the player inert
        if (moveProvider) moveProvider.enabled = true;
        if (snapTurnProvider) snapTurnProvider.enabled = true;
        if (teleportationProvider) teleportationProvider.enabled = true;
        if (jumpProvider) jumpProvider.enabled = true;
        /////////////////////

    }


}

using System;
using Unity.XR.CoreUtils;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Locomotion.Movement;
using UnityEngine.XR.Interaction.Toolkit.Locomotion.Teleportation;
using UnityEngine.XR.Interaction.Toolkit.Locomotion.Turning;
using UnityEngine.InputSystem;
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

    public InputActionProperty buttonAction;
    public MeshRenderer mesh;

    public TrackedPoseDriver trackedPoseDriver;

    public Transform cameraTransform;

    public ContinuousMoveProvider moveProvider;
    public SnapTurnProvider snapTurnProvider;
    public TeleportationProvider teleportationProvider;
    public JumpProvider jumpProvider;
    ///////////////////// 





    private void OnEnable()
    {
        buttonAction.action.Enable();

        buttonAction.action.started += OnButtonPressed;
        buttonAction.action.canceled += OnButtonReleased;
    }

    private void OnDisable()
    {
        buttonAction.action.started -= OnButtonPressed;
        buttonAction.action.canceled -= OnButtonReleased;

        buttonAction.action.Disable();
    }
    private void OnButtonPressed(InputAction.CallbackContext context)
    {
        ButtonWasPressed();
    }

    private void OnButtonReleased(InputAction.CallbackContext context)
    {
        ButtonWasReleased();
    }
    private void ButtonWasPressed()
    {
        Debug.Log("Button Was Pressed");

        mesh.enabled = false;
        resetPlayer();
    }

    private void ButtonWasReleased()
    {
        Debug.Log("Button Was Released");

        mesh.enabled = true;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
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
    private void resetPlayer()
    {
        fallEnabled = false;

        // Stop all physics motion
        rb.linearVelocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;

        // Stand upright (preserve Y rotation so facing direction stays same)
        Vector3 currentEuler = transform.eulerAngles;
        transform.rotation = Quaternion.Euler(0f, currentEuler.y, 0f);

        // Re-enable constraints (lock rotation)
        rb.constraints =
            RigidbodyConstraints.FreezeRotationX |
            RigidbodyConstraints.FreezeRotationY |
            RigidbodyConstraints.FreezeRotationZ;

        // Restore full headset tracking
        if (trackedPoseDriver)
        {
            trackedPoseDriver.trackingType =
                TrackedPoseDriver.TrackingType.RotationAndPosition;
        }

        // Re-enable locomotion providers
        if (moveProvider) moveProvider.enabled = true;
        if (snapTurnProvider) snapTurnProvider.enabled = true;
        if (teleportationProvider) teleportationProvider.enabled = true;
        if (jumpProvider) jumpProvider.enabled = true;

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

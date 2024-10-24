using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.UI.Image;

public class CarMovement : MonoBehaviour
{
    //Rigidbody rb;
    //public float speed = 2f;
    //public float turnSpeed = 2f;

    [SerializeField] WheelCollider frontRight;
    [SerializeField] WheelCollider backRight;
    [SerializeField] WheelCollider frontLeft;
    [SerializeField] WheelCollider backLeft;
    public float acceleration = 500f;
    public float breakForce = 300f;
    public float maxTurnAngle = 15f;
    private float currentAcceleration = 0f;
    private float currentBreakForce = 0f;
    private float currentTurnAngle = 0f;


    void FixedUpdate()
    {
        currentAcceleration = acceleration * Input.GetAxis("Vertical");
        if (Input.GetKey(KeyCode.Space))
            currentBreakForce = breakForce;
        else currentBreakForce = 0f;
        frontRight.motorTorque = currentAcceleration;
        frontLeft.motorTorque = currentAcceleration;
        frontRight.brakeTorque = currentBreakForce;
        frontLeft.brakeTorque = currentBreakForce;
        backRight.brakeTorque = currentBreakForce;
        backLeft.brakeTorque = currentBreakForce;
        currentTurnAngle = maxTurnAngle * Input.GetAxis("Horizontal");
        frontLeft.steerAngle = currentTurnAngle;
        frontRight.steerAngle = currentTurnAngle;

      


        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out RaycastHit hitinfo, 5000f))
        Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hitinfo.distance, Color.red);
    }


    //void Start()
    //{
    //   rb = GetComponent<Rigidbody >(); 
    //}


    //void Update()
    //{
    //    float moveInput = Input.GetAxis("Vertical");
    //    float turnInput = Input.GetAxis("Horizontal");

    //    rb.AddForce(transform.forward * moveInput * speed , ForceMode.Acceleration);

    //    rb.AddTorque(Vector3.up * turnInput * turnSpeed, ForceMode.Force  );

    //    if (moveInput == 0)
    //    {
    //        rb.drag = 2;
    //    }
    //    else
    //    {

    //        rb.drag = 0;
    //    }
    //}
}

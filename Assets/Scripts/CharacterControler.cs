using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterControler : MonoBehaviour {

    public float inputDelay = 0.1f;
    public float forwardVel = 12;
    public float rotateVel = 100;
    public float distToGrounded = 0.25f;
    public float jumpVel = 8f;
    public LayerMask ground;

    //physic
    public float downAccel = 0.25f;
    Vector3 velocity = Vector3.zero;

    Quaternion targetRotation;
    Rigidbody rBody;
    float forwardInput, turnInput;
    bool jumpInput;

    public Quaternion TargetRotation
    {
        get { return targetRotation; }
    }
    bool Grounded()
    {
        return Physics.Raycast(transform.position, Vector3.down, distToGrounded, ground);
    }
    void Start()
    {
        targetRotation = transform.rotation;
        if (GetComponent<Rigidbody>())
            rBody = GetComponent<Rigidbody>();
        else
            Debug.LogError("Die Faule Sau brauch nen RBody");

                forwardInput = turnInput = 0;
    }
    void GetInput()
    {
        forwardInput = Input.GetAxis("Vertical");
        turnInput = Input.GetAxis("Horizontal");
        jumpInput = Input.GetButtonDown("Jump"); // non interpolated
    }
    void Update()
    {
        GetInput();
        Trun();
    }
    void FixedUpdate()
    {
        Run();
        Jump();

        rBody.velocity = transform.TransformDirection(velocity);
    }
    void Run()
    {
        if (Mathf.Abs(forwardInput) > inputDelay)
        {
            velocity.z = forwardVel * forwardInput;
        }
        else
            velocity = Vector3.zero;
    }
    void Trun()
    {
        targetRotation *= Quaternion.AngleAxis(rotateVel * turnInput * Time.deltaTime, Vector3.up);
        transform.rotation = targetRotation;
    }
    void Jump()
    {
        if (jumpInput && Grounded())
        {
            Debug.Log("jump!");
            //jump
            velocity.y = jumpVel;
        }
        else if (!jumpInput && Grounded())
        {
            // zero out our velocity.y
            velocity.y = 0;
        }
        else //not grounded = falling
        {
            //decrease velocity.y
            velocity.y -= downAccel;
        }
    }
}

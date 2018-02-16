using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterControler : MonoBehaviour {

    public float inputDelay = 0.1f;
    public float forwardVel = 12;
    public float rotateVel = 100;

    Quaternion targetRotation;
    Rigidbody rBody;
    float forwardInput, turnInput;

    public Quaternion TargetRotation
    {
        get { return targetRotation; }
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
    }
    void Update()
    {
        GetInput();
        Trun();
    }
    void FixedUpdate()
    {
        Run();  
    }
    void Run()
    {
        if (Mathf.Abs(forwardInput) > inputDelay)
        {
            rBody.velocity = transform.forward * forwardInput * forwardVel;
        }
        else
            rBody.velocity = Vector3.zero;
    }
    void Trun()
    {
        targetRotation *= Quaternion.AngleAxis(rotateVel * turnInput * Time.deltaTime, Vector3.up);
        transform.rotation = targetRotation;
    }
}

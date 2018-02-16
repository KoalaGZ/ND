using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotation : MonoBehaviour {
    public Camera cam;
    float rotation = 0;
    Vector3 origRelativePos;
    Quaternion origRotation;
    float rootRotation;
    float maxRotation = 90;
    float inputRotation;
    float rotationSpeed = 2.5f;
    float camDist = 24f;

    void GetInput()
    {
        inputRotation = Input.GetAxis("RightJoystickHorizontal");
    }
	// Use this for initialization
	void Start () {
        origRelativePos = cam.transform.localPosition;
        origRotation = cam.transform.localRotation;

    }
	
	// Update is called once per frame
	void Update () {
        inputRotation = 0;
        GetInput();
        inputRotation *= rotationSpeed;
        rotation += inputRotation;
        //rotation = Mathf.Clamp(rotation, -maxRotation, maxRotation);
        Debug.Log(rotation);
        if (inputRotation != 0)
        {
            if (Mathf.Abs(rotation) > 90)
                inputRotation = 0;
            cam.transform.RotateAround(transform.position, Vector3.up, inputRotation);

        }
        else
        {
            cam.transform.localPosition = origRelativePos;
            cam.transform.localRotation = origRotation;
         //   cam.transform.RotateAround(transform.position, Vector3.up, transform.rotation.y - rotation);// * rotateBackSpeed);
            rotation = 0;
        }


    }
}

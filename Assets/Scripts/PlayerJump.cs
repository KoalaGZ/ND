using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJump : MonoBehaviour {

    private bool onGround;
    private float jumpPressure;
    private float minjump;
    private float maxjumpPressure;
    private Rigidbody rbody;

	// Use this for initialization
	void Start ()
    {
        onGround = true;
        jumpPressure = 0f;
        minjump = 2f;
        maxjumpPressure = 10f;
        rbody = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update ()
    {
		if(onGround)
        {
            if(Input.GetButton("Jump"))
            {
                if(jumpPressure < maxjumpPressure)
                {
                    jumpPressure += Time.deltaTime * 10f;
                }
                else
                {
                    jumpPressure = maxjumpPressure;
                }
            }
            else
            {
                if(jumpPressure > 0f)
                {
                    jumpPressure = jumpPressure + minjump;
                    rbody.velocity = new Vector3(0f, jumpPressure, 0f);
                    jumpPressure = 0f;
                    onGround = false;
                }
            }
        }
	}
     void OnCollisionEnter(Collision other)
    { 
      if(other.gameObject.CompareTag("ground"))
        {
            onGround = true;
        }
        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookY : MonoBehaviour {
    [SerializeField]
    private float speed = 5.0f;

	void Start ()
    {
		
	}
	
	
	void Update ()
    {
        //Rotate the camera around the x axis based on mouse position and rotation speed
        Vector3 newRotation = transform.localEulerAngles;

        newRotation.x += Input.GetAxis("Mouse Y") * speed;

        //lock the rotation around the x axiss so it can't go more than 60 degrees
        newRotation.x = (newRotation.x > 180) ? newRotation.x - 360 : newRotation.x;
        
        newRotation.x = Mathf.Clamp(newRotation.x , -60, 60);

        transform.localEulerAngles = newRotation;
        
	}
}

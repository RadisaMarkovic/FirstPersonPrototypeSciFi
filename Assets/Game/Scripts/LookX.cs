using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookX : MonoBehaviour
{
    [SerializeField]
	private float _speed = 5.0f;

	void Start ()
	{
		
	}
	
	
	void Update ()
	{
		//Rotate the camera around the y axis based on mouse position and rotation speed
		Vector3 newRotation = transform.localEulerAngles;
		newRotation.y += Input.GetAxis("Mouse X") * _speed;
		transform.localEulerAngles = newRotation;

	}
}

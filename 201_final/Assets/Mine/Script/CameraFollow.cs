﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
	//Determines the limitations of vertical camera movement
	[SerializeField] private float Y_ANGLE_MIN = 15.0f;
	[SerializeField] private float Y_ANGLE_MAX = 25.0f;
	[HideInInspector]
	[System.Runtime.InteropServices.DllImport("user32.dll")]
	public static extern int SetCursorPos(int x, int y);
	public Transform character; //What the camera is looking at..the main character
	GameObject player;
	[SerializeField] private float distance = -5.0f; // Distance to stay from character, Make sure it is negative
	[SerializeField] private float currentPushDistance = 1.0f;
	[SerializeField] private float offsetY = 2.5f;
	[SerializeField] private float xRotationSpeed = 2.5f;
	[SerializeField] private float yRotationSpeed = 2.5f;
	private float currentX = 0.0f; // Holds value of X mouse movement
	private float currentY = 0.0f; // Holds value of Y mouse movement

	public bool isFrozen;

	void start()
	{
		character = GameObject.FindGameObjectWithTag("Player").transform;
		player = GameObject.FindGameObjectWithTag("Player");
		isFrozen = false;
		Cursor.visible = false;
	}

	void Update()
	{
		if (character == null)
		{
			if (GameObject.FindGameObjectWithTag("Player") != null)
			{
				player = GameObject.FindGameObjectWithTag("Player");
				character = GameObject.FindGameObjectWithTag("Player").transform;
			}
		}

		if (character != null && !isFrozen)
		{

			currentX += Input.GetAxis("Mouse X") * Time.deltaTime * xRotationSpeed;
			currentY += Input.GetAxis("Mouse Y") * Time.deltaTime * yRotationSpeed;


			currentY = Mathf.Clamp(currentY, Y_ANGLE_MIN, Y_ANGLE_MAX);
		}
	}

	void LateUpdate()
	{                                                        //Rotation around character............/...Keeps distance from character
		if (character != null && !isFrozen)
		{
			gameObject.transform.position = character.position + Quaternion.Euler(currentY + 10f, currentX, 0) * new Vector3(0, 0, distance);
			gameObject.transform.LookAt(character.position + new Vector3(0, offsetY, 0));//Points camera at character      
			RaycastHit hitInfo;
			if (Physics.SphereCast(gameObject.transform.position, 0.5f, gameObject.transform.forward, out hitInfo, -distance, LayerMask.GetMask("Wall")))
			{
				gameObject.transform.position = new Vector3(hitInfo.point.x + hitInfo.normal.x * currentPushDistance, hitInfo.point.y + hitInfo.normal.y * currentPushDistance, hitInfo.point.z + hitInfo.normal.z * currentPushDistance);
			}

		}
	}

}


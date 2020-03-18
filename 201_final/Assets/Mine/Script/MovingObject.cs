using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingObject : MonoBehaviour
{
	public bool isValid = true;
	public float speedRate = 0.9f;
	Animator thisAnimator;
	private BoxCollider thisTrigger;

	// Start is called before the first frame update
	void Start()
	{
		thisTrigger = gameObject.GetComponent<BoxCollider>();
		thisAnimator = gameObject.GetComponent<Animator>();
	}

	void Update()
	{
		if (TheWorld.isTheWorld && isValid)
		{
			thisAnimator.speed = 0.0f;
		}
		else if (!TheWorld.isTheWorld)
		{
			thisAnimator.speed = speedRate;
		}
	}

	// Update is called once per frame
	private void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Player")
		{
			other.transform.parent = transform;
		}
	}

	private void OnTriggerExit(Collider other)
	{
		if(other.tag == "Player")
		{
			other.transform.parent = null;
		}
	}

}

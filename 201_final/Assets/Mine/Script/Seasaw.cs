using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seasaw : MonoBehaviour
{
	Rigidbody thisRigidbody;
	public bool isRotated = false;
    // Start is called before the first frame update
    void Start()
    {
		thisRigidbody = gameObject.GetComponent<Rigidbody>();
		//rotationY = transform.localRotation.y;
    }

	// Update is called once per frame

	void Update()
	{

		if (TheWorld.isTheWorld)
		{
			thisRigidbody.constraints = RigidbodyConstraints.FreezePosition | RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationZ;
		}
		else if (!TheWorld.isTheWorld)
		{
			thisRigidbody.constraints = RigidbodyConstraints.FreezePosition | RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY;
		}
	}

	private void OnTriggerExit(Collider other)
	{
		if(other.tag == "Player")
		{
			if (isRotated)
			{
				transform.localRotation = Quaternion.Euler(0, 90, 0);
			}
			else
			{
				transform.localRotation = Quaternion.Euler(0, 0, 0);
			}
			thisRigidbody.velocity = Vector3.zero;
			thisRigidbody.angularVelocity = Vector3.zero;

		}
	}

}

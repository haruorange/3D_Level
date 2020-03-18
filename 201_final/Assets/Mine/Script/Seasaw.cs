using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seasaw : MonoBehaviour
{
	Rigidbody thisRigdbody;
    // Start is called before the first frame update
    void Start()
    {
		thisRigdbody = gameObject.GetComponent<Rigidbody>();
    }

	// Update is called once per frame

	void Update()
	{

		if (TheWorld.isTheWorld)
		{
			thisRigdbody.constraints = RigidbodyConstraints.FreezePosition | RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationZ;
		}
		else if (!TheWorld.isTheWorld)
		{
			thisRigdbody.constraints = RigidbodyConstraints.FreezePosition | RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY;
		}
	}

	private void OnTriggerExit(Collider other)
	{
		if(other.tag == "Player")
		{
			transform.localRotation = Quaternion.identity;
		}
	}

}

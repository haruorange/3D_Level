using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeRestore : MonoBehaviour
{
	[SerializeField] private GameObject timeAdd;
	[SerializeField] private Transform thisObject;
	bool isDestroyed;
	float respawnTimer;
	float respawnTime = 3.0f;

	// Start is called before the first frame update
	void Start()
    {
		isDestroyed = false;
    }

	// Update is called once per frame
	void Update()
	{
		if (isDestroyed)
		{
			respawnTimer -= Time.deltaTime;
		}
		else
		{
			respawnTimer = respawnTime;
		}
		if(respawnTimer <= 0.0f)
		{
			isDestroyed = false;
			spwanTimeAdd();
		}
	}

	private void OnTriggerEnter(Collider other)
	{
		if(other.tag == "Player")
		{
			TheWorld.TimeRemain += 5.0f;
			isDestroyed = true;
			Destroy(gameObject);
			
		}
	}
	private void spwanTimeAdd()
	{
		Instantiate(timeAdd, thisObject.position, thisObject.rotation);
	}
}

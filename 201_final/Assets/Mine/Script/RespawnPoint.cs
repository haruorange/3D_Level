using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnPoint : MonoBehaviour
{
	private TheWorld theWorld;
	private bool triggered;

    // Start is called before the first frame update
    void Start()
    {
		theWorld = GameObject.Find("LevelManager").GetComponent<TheWorld>();
		triggered = false;
    }

	// Update is called once per frame
	private void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Player")
		{
			if (!triggered)
			{
				theWorld.nextSpawnPoint();
				triggered = true;
			}
		}

	}
}

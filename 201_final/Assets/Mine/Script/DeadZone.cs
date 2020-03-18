using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadZone : MonoBehaviour
{
	private GameObject player;
	private TheWorld theWorld;
	public static bool isDead = false;
	// Start is called before the first frame update
	void Start()
    {
		theWorld = GameObject.Find("LevelManager").GetComponent<TheWorld>();
    }

	//void Update()
	//{
	//	Debug.Log(isDead);	
	//}

	// Update is called once per frame
	private void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Player") { 
			isDead = true;
			theWorld.respawnPlayer();
		}
	}
}

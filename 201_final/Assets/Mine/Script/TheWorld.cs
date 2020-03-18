using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class TheWorld : MonoBehaviour
{
	public static float TimeRemain;
	public static bool isTheWorld;
	public static int coins;
	public float StopDurance = 6.0f;

	[SerializeField] private Transform player;
	[SerializeField] private Transform[] spawnPoints;
	[SerializeField] private int spawnPointIndex;

	public Image TimeBar;



	// Start is called before the first frame update
	void Start()
    {
		isTheWorld = false;
		TimeRemain = StopDurance;
		coins = 0;

		spawnPointIndex = 0;
	}

    // Update is called once per frame
    void Update()
    {
		TimeBar.fillAmount = TimeRemain / StopDurance;

		if(TimeRemain <= 0.01f)
		{
			isTheWorld = false;
		}
		if(TimeRemain >= StopDurance)
		{
			TimeRemain = StopDurance;
		}
		if (!isTheWorld)
		{
			if (TimeRemain <= StopDurance)
			{
				TimeRemain += 2 * Time.deltaTime;
			}
			
			if (Input.GetMouseButtonUp(1)){
				isTheWorld = true;
				
			}
		}
		else if (isTheWorld)
		{
			if(TimeRemain >= 0.0f)
			{
				TimeRemain -= Time.deltaTime;
			}
			
			if (Input.GetMouseButtonUp(1))
			{
				isTheWorld = false;
				
			}
		}
	}

	public void nextSpawnPoint()
	{
		++spawnPointIndex;
	}


	public void respawnPlayer()
	{
		DeadZone.isDead = false;
		if (spawnPoints[spawnPointIndex] == null)
		{
			throw new Exception("SpawnPoint Overflow");
		}

		player.transform.position = spawnPoints[spawnPointIndex].position;

	}

}

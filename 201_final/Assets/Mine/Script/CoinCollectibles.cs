using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinCollectibles : MonoBehaviour
{
	float speed = 100.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
		transform.Rotate(0, 0, Time.deltaTime * speed);
    }

	private void OnTriggerEnter(Collider other)
	{
		if(other.tag == "Player")
		{
			TheWorld.coins++;
			Destroy(gameObject);
		}
	}

}

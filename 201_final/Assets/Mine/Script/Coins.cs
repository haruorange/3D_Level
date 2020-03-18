using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Coins : MonoBehaviour
{
	Text coins;
    // Start is called before the first frame update
    void Start()
    {
		coins = GetComponent <Text>();
    }

    // Update is called once per frame
    void Update()
    {
		coins.text = "COINS: " + TheWorld.coins;
    }
}

using UnityEngine;
using UnityEngine.UI ;
using System.Collections;

public class CountCoin : MonoBehaviour {
	
	void Update () {
		int amount = GameObject.FindWithTag("Player").GetComponent<PlayerState>().coins ;
		GetComponent<Text>().text = "X " + ( (amount>9) ? amount.ToString():("0"+amount) ) ;
	}
}

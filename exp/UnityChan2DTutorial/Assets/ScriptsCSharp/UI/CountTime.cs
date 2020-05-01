using UnityEngine;
using UnityEngine.UI ;
using System.Collections;

public class CountTime : MonoBehaviour {
	public int maxTime = 120 ;
	int currentTime = 0 ;

	void Start () {
		currentTime = maxTime ;
		InvokeRepeating("CountDown", 0, 1) ;
	}
	
	void CountDown () {
		currentTime -= 1 ;
		GetComponent<Text>().text = "TIME\n" + currentTime ;
	}
}

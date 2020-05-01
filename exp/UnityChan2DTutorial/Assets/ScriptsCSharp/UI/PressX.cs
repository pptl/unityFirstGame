using UnityEngine;
using UnityEngine.UI ;
using System.Collections;

public class PressX : MonoBehaviour {

	void Start () {
		InvokeRepeating("ShowText", 0, 0.5f) ;
	}
	
	void ShowText () {
		Text t = GetComponent<Text>() ;
		if(t.text == ""){
			t.text = "PRESS X" ;
		}else{
			t.text = "" ;
		}
	}
}

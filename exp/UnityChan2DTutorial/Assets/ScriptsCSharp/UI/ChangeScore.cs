using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ChangeScore : MonoBehaviour {

	void ScoreUpdate(){
		int amount = GameObject.FindWithTag("Player").GetComponent<PlayerState>().score ;
		string number = amount + "" ;
		string zero = "000000000" ;

		GetComponent<Text>().text =  zero.Substring(0,zero.Length - number.Length) + amount ;
	}
}

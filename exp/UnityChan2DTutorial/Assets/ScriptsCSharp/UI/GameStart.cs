using UnityEngine;
using System.Collections;

public class GameStart : MonoBehaviour {

	void Start () {
		GameState.Reset() ;
	}
	
	void Update () {
		if(Input.GetMouseButtonDown(0)){
			Application.LoadLevel(1) ;
		}
	}
}

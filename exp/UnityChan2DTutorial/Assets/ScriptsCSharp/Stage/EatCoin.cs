//============
// Eat coin
// 吃金幣
//============
using UnityEngine;
using System.Collections;

public class EatCoin : MonoBehaviour {
	bool eaten = false ; // 是否被吃了

	void OnTriggerEnter2D(Collider2D co){
		if(co.tag != "Player" || eaten){return;}
		Camera.main.SendMessage("PlaySound", 2) ;
		co.gameObject.SendMessage("CoinPlus", 1) ;
		co.gameObject.SendMessage("ScorePlus", 100) ;
		GetComponent<Animator>().Play("CoinDamp") ;
		eaten = true ;
	}

	void Die(){
		Destroy(gameObject) ;
	}
}

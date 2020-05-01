using UnityEngine;
using System.Collections;

public class HairballAction : MonoBehaviour {
	float force = 50f ;
	float speed = 2f ;
	bool attacked = false ;

	void Update(){
		if(GameState.gameOver){
			return ;
		}

		if(!attacked){
			transform.Translate(Vector3.left*speed*Time.deltaTime) ;
		}
	}
	//================
	// 碰撞 Collision
	//================
	void OnCollisionEnter2D(Collision2D co){
		// 如果遊戲結束就不做任何事
		if(GameState.gameOver){
			return ;
		}
		// 被踩死加分 If been killed, add score
		if(co.gameObject.tag == "Player" && co.contacts[0].normal == -Vector2.up){
			co.gameObject.SendMessage("ScorePlus", 200) ;
			Destroy(gameObject) ;
		}
		// 撞到玩家 Hit player
		if(co.gameObject.tag == "Player" && (co.contacts[0].normal==Vector2.right || co.contacts[0].normal==-Vector2.right) ){
			co.rigidbody.AddForce(-co.contacts[0].normal*force) ;
			attacked = true ;
			Invoke("ContinueMove", 0.8f) ;
			co.gameObject.SendMessage("OnDamage") ;
		}
	}

	//================
	// 等待完後繼續移動
	//================
	void ContinueMove(){
		attacked = false ;
	}
}

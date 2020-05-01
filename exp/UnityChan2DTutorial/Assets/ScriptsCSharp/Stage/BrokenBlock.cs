//===============
// Broken Block
// 可破壞方塊
//===============
using UnityEngine;
using System.Collections;

public class BrokenBlock : MonoBehaviour {

	void OnCollisionEnter2D(Collision2D co){
		//判斷碰撞方向跟玩家標籤, Check collision normal and player tag
		if(co.gameObject.tag == "Player" && co.contacts[0].normal == Vector2.up){
			//生成碎片 Spawn fragment
			GameObject broken = Instantiate(Resources.Load("Broken"), transform.position, transform.rotation) as GameObject;
			// 播放聲音 play sound
			Camera.main.SendMessage("PlaySound", 0f) ;
			// 隨機金幣出現 Random spawn coin
			if(Random.value > 0.5f){
				Instantiate(Resources.Load("Coin"), transform.position, transform.rotation);
			}
			Destroy(gameObject, Time.deltaTime) ;
		}
	}
}

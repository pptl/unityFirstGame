using UnityEngine;
using System.Collections;
//==============
// Player State
// 玩家狀態
//==============

public class PlayerState : MonoBehaviour {
	public GameObject scoreUI ;
	// 變量 variable
	public int coins =  0 ;
	public int score = 0 ;
	public int life = 5 ;
	public int hp = 3 ;
	// 方法 function

	void Start(){
		LoadAll() ;
	}
	// 增加金幣
	void CoinPlus(int amount){
		coins += amount ;
	}
	// 增加分數
	void ScorePlus(int amount){
		score += amount ;
		scoreUI.SendMessage("ScoreUpdate") ;
	}
	// 減少血量
	void DecreaseHP(int i){
		hp -= i ;
		print (hp);
		if(hp <= 0){
			SendMessage("GameOver") ;
		}
	}
	// 減少命
	void LostLife(){
		life -= 1 ;
	}
	// 存檔
	void SaveAll(){
		GameState.coins = coins ;
		GameState.score = score ;
		GameState.life = life ;
	}
	// 讀檔
	void LoadAll(){
		coins = GameState.coins;
		score = GameState.score;
		life = GameState.life;
	}

}

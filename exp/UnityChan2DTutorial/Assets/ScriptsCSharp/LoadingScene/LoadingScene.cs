using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LoadingScene : MonoBehaviour {

	public Text t_coin ;
	public Text t_score ;
	public Text t_life ;

	void Start () {
		LoadValue() ;
		Invoke("WaitAndGo", 3) ;
	}

	void WaitAndGo(){
		Application.LoadLevel(2) ;
	}

	void LoadValue(){
		t_coin.text = GameState.coins+"" ;
		t_score.text = GameState.score+"" ;
		t_life.text = GameState.life+"" ;
	}
}

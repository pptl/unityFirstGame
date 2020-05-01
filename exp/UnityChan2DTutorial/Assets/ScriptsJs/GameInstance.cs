using UnityEngine;
using System.Collections;

static class GameState {
	public static bool gameOver = false ;
	public static int coins = 0 ;
	public static int score = 0 ;
	public static int life = 5 ;

	public static void Reset(){
		gameOver  = false ;
		coins  = 0 ;
		score  = 0 ;
		life  = 5 ;
	}
}

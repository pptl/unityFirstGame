#pragma strict
//============
// Eat coin
// 吃金幣
//============
private var eaten : boolean = false ; // 是否被吃了 


function OnTriggerEnter2D(co:Collider2D){
  if(co.tag != "Player" || eaten){return;}
  Camera.main.SendMessage("PlaySound", 2) ;
  co.gameObject.SendMessage("CoinPlus", 1) ;
  co.gameObject.SendMessage("ScorePlus", 100) ;
  GetComponent.<Animator>().Play("CoinDamp") ;
  eaten = true ;
}

function Die(){
  Destroy(gameObject) ;
}
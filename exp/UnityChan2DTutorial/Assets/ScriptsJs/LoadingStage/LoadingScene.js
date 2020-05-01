#pragma strict
var t_coin : UI.Text ;
var t_score : UI.Text ;
var t_life : UI.Text ;

function Start () {
  LoadValue() ;
  Invoke("WaitAndGo", 3) ;
}

function WaitAndGo(){
  Application.LoadLevel(2) ;
}

function LoadValue(){
  t_coin.text = GameState.coins+"" ;
  t_score.text = GameState.score+"" ;
  t_life.text = GameState.life+"" ;
}
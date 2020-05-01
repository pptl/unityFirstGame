#pragma strict
//==============
// Player State
// 玩家狀態
//==============
var scoreUI : GameObject ;
// 變量 variable
var coins : int = 0 ;// 金幣
var score : int = 0 ;// 分數
var life : int = 5 ;// 總命數
var hp : int = 3 ; // 血量
// 方法 function

function Start(){
  LoadAll() ;
}
// 增加金幣
function CoinPlus(amount : int){
  coins += amount ;
}
// 增加分數
function ScorePlus(amount : int){
  score += amount ;
  scoreUI.SendMessage("ScoreUpdate") ;
}
// 減少血量
function DecreaseHP(i:int){
  hp -= i ;
  if(hp <= 0){
    SendMessage("GameOver") ;
  }
}
// 減少命
function LostLife(){
  life -= 1 ;
}
// 存檔
function SaveAll(){
  GameState.coins = coins ;
  GameState.score = score ;
  GameState.life = life ;
}
// 讀檔
function LoadAll(){
  coins = GameState.coins;
  score = GameState.score;
  life = GameState.life;
}








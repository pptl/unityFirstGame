#pragma strict

static class GameState{
  var gameOver : boolean = false ;
  var coins : int = 0 ;
  var score : int = 0 ;
  var life : int = 5 ;
  
  function Reset(){
    gameOver  = false ;
    coins  = 0 ;
    score  = 0 ;
    life  = 5 ;
  }
}
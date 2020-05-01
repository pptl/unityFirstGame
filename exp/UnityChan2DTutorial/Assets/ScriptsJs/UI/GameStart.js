#pragma strict
function Start(){
  GameState.Reset() ;
}

function Update(){
  if(Input.GetMouseButtonDown(0)){
    Application.LoadLevel(1) ;
  }
}
#pragma strict
var maxTime : int = 120 ;
private var currentTime : int = 0 ;

function Start(){
  currentTime = maxTime ;
  InvokeRepeating("CountDown", 0, 1) ;
}

function CountDown(){
  currentTime -= 1 ;
  GetComponent.<UI.Text>().text = "TIME\n" + currentTime ;
}
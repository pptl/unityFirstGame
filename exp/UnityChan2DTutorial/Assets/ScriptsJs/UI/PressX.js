#pragma strict

function Start () {
  InvokeRepeating("ShowText", 0, 0.5) ;
}

function ShowText(){
  var t:UI.Text = GetComponent.<UI.Text>() ;
  if(t.text == ""){
    t.text = "PRESS X" ;
  }else{
    t.text = "" ;
  }
}
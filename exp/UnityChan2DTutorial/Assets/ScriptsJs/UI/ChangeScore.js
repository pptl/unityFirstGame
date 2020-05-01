#pragma strict

function ScoreUpdate () {
  var amount : int = gameObject.FindWithTag("Player").GetComponent.<PlayerState>().score ;
  var number : String = amount+"" ; 
  var zero : String = "000000000" ;
  
  GetComponent.<UI.Text>().text =  zero.Substring(0,zero.length-number.length) + amount ;
}
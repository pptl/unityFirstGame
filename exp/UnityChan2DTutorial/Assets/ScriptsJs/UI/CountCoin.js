#pragma strict


function Update () {
  var amount : int = gameObject.FindWithTag("Player").GetComponent.<PlayerState>().coins ;
  GetComponent.<UI.Text>().text = "X " + ( (amount>9) ? amount:("0"+amount) ) ;
}
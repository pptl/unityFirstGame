#pragma strict
private var force : float = 50 ;
private var speed : float = 2 ;
private var attacked : boolean = false ;

function Update(){
  if(GameState.gameOver){
    return ;
  }
  
  if(!attacked){
    transform.Translate(Vector3.left*speed*Time.deltaTime) ;
  }
}
//================
// 碰撞 Collision
//================
function OnCollisionEnter2D(co:Collision2D){
  // 如果遊戲結束就不做任何事
  if(GameState.gameOver){
    return ;
  }
  // 被踩死加分 If been killed, add score
  if(co.gameObject.tag == "Player" && co.contacts[0].normal == -Vector3.up){
    co.gameObject.SendMessage("ScorePlus", 200) ;
    Destroy(gameObject) ;
  }
  // 撞到玩家 Hit player
  if(co.gameObject.tag == "Player" && (co.contacts[0].normal==Vector3.right || co.contacts[0].normal==-Vector3.right) ){
    co.rigidbody.AddForce(-co.contacts[0].normal*force) ;
    attacked = true ;
    Invoke("ContinueMove", 0.8) ;
    co.gameObject.SendMessage("OnDamage") ;
  }
}

//================
// 等待完後繼續移動
//================
function ContinueMove(){
  attacked = false ;
}
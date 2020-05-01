#pragma strict
//===============
// Broken Block
// 可破壞方塊
//===============
function OnCollisionEnter2D(co:Collision2D){
  //判斷碰撞方向跟玩家標籤, Check collision normal and player tag
  if(co.gameObject.tag == "Player" && co.contacts[0].normal == Vector3.up){
    //生成碎片 Spawn fragment
    var broken : GameObject = Instantiate(Resources.Load("Broken"), transform.position, transform.rotation);
    // 播放聲音 play sound
    Camera.main.SendMessage("PlaySound", 0) ;
    // 隨機金幣出現 Random spawn coin
    if(Random.value > 0.5){
      Instantiate(Resources.Load("Coin"), transform.position, transform.rotation);
    }
    Destroy(gameObject) ;
  }
}
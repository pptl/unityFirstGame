#pragma strict
//===========================
// Movement Controller
// 動作控制
//===========================
var sprite : GameObject ;

private var runSpeed : float = 10 ;     // 跑速
private var jumpHeight : float = 1020 ; // 跳躍高度
private var body : Rigidbody2D ;        // 角色剛體
private var animator : Animator ;       // 動畫控制器
private var jumping : boolean = false ; // 跳躍上升中
private var isGround : boolean = false ;// 是否在地上
private var damage : boolean = false ;  // 傷害中
private var doubleJump : boolean = true ; // 可不可以二段跳

function Awake () {
  GameState.gameOver = false ;
  animator = GetComponent.<Animator>() ;
  body = GetComponent.<Rigidbody2D>() ;
}

function Update(){
  Jump() ;
}

function FixedUpdate () { 
  if(GameState.gameOver){
    body.velocity = Vector3.zero ;
    return ;
  }
  // 傷害中無法行動 If being damage, lock movement
  if(!damage){
    Move() ;
  }
  SetJumpState() ;
  StateMachine() ;
}
//====================
// 移動 Move
//====================
function Move(){
  var speed : float = Input.GetAxis("Move")*runSpeed ;
  
  body.velocity.x = speed ;
  
  if(speed != 0){
    sprite.transform.localScale.x = Mathf.Sign(body.velocity.x)==1 ? 1:-1 ;
  }
  
}
//====================
// 跳躍 Jump
//====================
function Jump(){
  if(Input.GetButtonDown("Jump")){
    if(isGround){
      // 一段跳
    	body.AddForce(Vector3.up*jumpHeight) ;
    }else if(doubleJump){
      // 二段跳
      body.AddForce(Vector3.up*jumpHeight) ;
      doubleJump = false ;
    }else{
    	return ;
    }
    
    if(Random.value > 0.5){
      Camera.main.SendMessage("VocalPlay", 0) ;
    }else{
      Camera.main.SendMessage("VocalPlay", 1) ;
    }
  }
}
//====================
// 跳躍狀態 Jump State
//====================
function SetJumpState(){
  if(body.velocity.y > 0.01){
    jumping = true ;
    isGround = false ;
  }else if(jumping){
    jumping = false ;
  }
}

//====================
// 傷害 Damage
//====================
function OnDamage(){
  Camera.main.SendMessage("VocalPlay", 4) ;
  SendMessage("DecreaseHP", 1) ;
  damage = true ;
  animator.SetTrigger("Damage") ;
}

function EndDamage(){
  damage = false ;
  Camera.main.SendMessage("VocalPlay", 3) ;
}
//遊戲結束
function GameOver(){
  GameState.gameOver = true ;
  SendMessage("LostLife") ;
  SendMessage("SaveAll") ;
  animator.SetTrigger("Over") ;
  // 等待 wait
  yield WaitForSeconds(3.5) ;
  if(GameState.life <= 0){
    Application.LoadLevel(0) ;
  }else{
    Application.LoadLevel(1) ;
  }
}

//===========================
// 狀態機(動畫) State machine
//===========================
function StateMachine(){
  animator.SetFloat("Speed", Mathf.Abs(body.velocity.x)) ;
  animator.SetBool("Jumping", jumping) ;
  animator.SetBool("Ground", isGround) ;
}

//====================
// 碰撞 Collision
//====================
function OnCollisionStay2D(co:Collision2D){
  if(co.gameObject.tag == "Ground" && co.contacts[0].normal == Vector3.up){
    isGround = true ;
    doubleJump = true ;
  }
}
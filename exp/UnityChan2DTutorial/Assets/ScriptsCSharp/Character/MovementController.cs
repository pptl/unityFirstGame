//===========================
// Movement Controller
// 動作控制
//===========================
using UnityEngine;
using System.Collections;

public class MovementController : MonoBehaviour {

	public GameObject sprite ;

	float runSpeed = 10 ;
	float jumpHeight = 1020 ;
	Rigidbody2D body ;
	Animator animator ;
	bool jumping = false ;
	bool isGround = false ;
	bool damage = false ;
	bool doubleJump = true ;

	void Awake () {
		GameState.gameOver = false ;
		animator = GetComponent<Animator>() ;
		body = GetComponent<Rigidbody2D>() ;
	}
	
	void Update(){
		Jump() ;  
	}

	void FixedUpdate () { 
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
	void Move(){
		float speed = Input.GetAxis("Move")*runSpeed ;

		body.velocity = new Vector2(speed, body.velocity.y) ;

		if(speed != 0f){
			Vector3 scale = sprite.transform.localScale ;
			scale.x = Mathf.Sign(body.velocity.x) == 1f ? 1f : -1f ;
			sprite.transform.localScale =  scale ;
		}

	}
	//====================
	// 跳躍 Jump
	//====================
	void Jump(){
		if(Input.GetButtonDown("Jump")){
			if(isGround){
				body.AddForce(Vector3.up*jumpHeight) ;
			}else if(doubleJump){
				body.AddForce(Vector3.up*jumpHeight) ;
				doubleJump = false ;
			}else{
				return ;
			}

			if(Random.value > 0.5f){
				Camera.main.SendMessage("VocalPlay", 0f) ;
			}else{
				Camera.main.SendMessage("VocalPlay", 1) ;
			}
		}
	}
	//====================
	// 跳躍狀態 Jump State
	//====================
	void SetJumpState(){
		if(body.velocity.y > 0.01f){
			jumping = true ;
			isGround = false ;
		}else if(jumping){
			jumping = false ;
		}
	}

	//====================
	// 傷害 Damage
	//====================
	void OnDamage(){
		if (damage) {return;}
		Camera.main.SendMessage("VocalPlay", 4) ;
		SendMessage("DecreaseHP", 1) ;
		damage = true ;
		animator.SetTrigger("Damage") ;
	}

	public void EndDamage(){
		damage = false ;
		Camera.main.SendMessage("VocalPlay", 3) ;
	}
	//遊戲結束
	IEnumerator GameOver(){
		GameState.gameOver = true ;
		SendMessage("LostLife") ;
		SendMessage("SaveAll") ;
		animator.SetTrigger("Over") ;
		// 等待 wait
		yield return new WaitForSeconds(3.5f) ;
		if(GameState.life <= 0){
			Application.LoadLevel(0) ;
		}else{
			Application.LoadLevel(1) ;
		}
	}

	//===========================
	// 狀態機(動畫) State machine
	//===========================
	void StateMachine(){
		animator.SetFloat("Speed", Mathf.Abs(body.velocity.x)) ;
		animator.SetBool("Jumping", jumping) ;
		animator.SetBool("Ground", isGround) ;
	}

	//====================
	// 碰撞 Collision
	//====================
	void OnCollisionStay2D(Collision2D co){
		if(co.gameObject.tag == "Ground" && co.contacts[0].normal == Vector2.up){
			isGround = true ;
			doubleJump = true ;
		}
	}
}

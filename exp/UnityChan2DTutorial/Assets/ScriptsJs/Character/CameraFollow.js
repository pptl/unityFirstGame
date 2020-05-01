#pragma strict
//===========================
// Camera Follows the Player
// 攝影機跟隨玩家
//===========================
var au : AudioClip[] ;// 音效 sound 
var vocal : AudioClip[] ;// 語音 voice
private var range : Vector2 = Vector2(-3,174) ; // 最小/最大  min / max
var target : Transform ;

function Update(){
  transform.position.x = target.position.x ;
  transform.position.x = Mathf.Clamp(transform.position.x, range.x, range.y) ;
}
//====================
// 播放音效 Play sound
//====================
function PlaySound(id:int){
  if(GetComponent.<AudioSource>().isPlaying){return;}

  GetComponent.<AudioSource>().clip = au[id] ;
  GetComponent.<AudioSource>().Play() ;
}
//====================
// 播放語音 Play voice
//====================
function VocalPlay(id:int){
  if(GetComponent.<AudioSource>().isPlaying){return;}
  
  GetComponent.<AudioSource>().clip = vocal[id] ;
  GetComponent.<AudioSource>().Play() ;
}

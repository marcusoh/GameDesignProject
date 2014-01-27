using UnityEngine;
using System.Collections;
public class Move2 : MonoBehaviour {
	public static GameObject platform2;
	public static float counter;
	public Transform prefab;
	public float speed=10f;
	public float acceleration=1f;
	public float gravity = -9.8f;
	public float jumpHeight = 1f;
	Vector2 newPos = new Vector2 (0f,0f);
	public float TerminalVelocity=-20f;
	private CharacterController controller;
	public float pos = 0f;
	public bool isRight;
	void Start () {
		controller = GetComponent<CharacterController>();
		GUIManager.setRedLives (6);
		counter=0;
		platform2 = GameObject.Find("startPlatform1");
	}
	void Update () {
		counter++;
		if(counter==30f){
			platform2.gameObject.SetActive(false);
		}
		pos = Input.GetAxis("Horizontal2");
		if(pos > 0){
			isRight = true;
		}
		else if(pos <0){
			isRight = false;
		}
		newPos.x = pos*(Time.deltaTime+.2f)*3f;
		if(Input.GetButton("Jump2")){
			if(controller.isGrounded){
				newPos.y=jumpHeight;
				print ("Jumping");
			}
		}
		if(newPos.y>TerminalVelocity){
			newPos.y += gravity*Time.deltaTime;
			
		}
		if(Input.GetButtonDown("Player2Fire")){
			Transform c=(Transform)Instantiate (prefab, transform.localPosition,transform.localRotation);
			Bullet2 bscript=c.GetComponent<Bullet2>();
			bscript.direction = isRight;
		}
		if(Input.GetButtonDown("Reset")){
			Application.LoadLevel(0);
		}
		int lives=GUIManager.getRedLives();
		if(lives==0){
			Application.LoadLevel(3);
		}
	}
	void FixedUpdate(){
		controller.Move (newPos);
	}
}

using UnityEngine;
using System.Collections;

public class Move2 : MonoBehaviour {
	public Transform prefab;
	public float speed=10f;
	public float acceleration=1f;
	public float gravity = -9.8f;
	public float jumpHeight = 1f;
	Vector2 newPos = new Vector2 (0f,0f);
	public float TerminalVelocity=-20f;
	private CharacterController controller;
	public float pos = 0f;
	void Start () {
		controller = GetComponent<CharacterController>();
		//		GameManager.gameStarter+=gameStart;
		//		GameManager.gameEnder+=gameEnd;
		//		enabled=false;
	}
	
	// Update is called once per frame
	void Update () {
		newPos.x = Input.GetAxis("Horizontal2")*(Time.deltaTime+.2f)*3f;
		if(Input.GetButton("Jump2")){
			if(controller.isGrounded){
				newPos.y=jumpHeight;
				print ("Jumping");
			}
		}
		if(newPos.y>TerminalVelocity){
			newPos.y += gravity*Time.deltaTime;
			
		}
		controller.Move (newPos);
		if(Input.GetButtonDown("Player2Fire")){
			Transform c=(Transform)Instantiate (prefab, transform.localPosition,transform.localRotation);
			Bullet2 bscript=c.GetComponent<Bullet2>();
		}
	}
}

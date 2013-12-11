using UnityEngine;
using System.Collections;

public class move : MonoBehaviour {
	public float speed=10f;
	public float acceleration=1f;
	public float gravity = -9.8f;
	public float jumpHeight = 1f;
	Vector2 newPos = new Vector2 (0f,0f);
	public float TerminalVelocity=-20f;
	private CharacterController controller;
	void Start () {
		controller = GetComponent<CharacterController>();
//		GameManager.gameStarter+=gameStart;
//		GameManager.gameEnder+=gameEnd;
//		enabled=false;
	}
	
	// Update is called once per frame
	void Update () {
		newPos.x = Input.GetAxis("Horizontal1")*(Time.deltaTime+.1f)*5f;
		if(Input.GetButton("Jump1")){
			if(controller.isGrounded){
				newPos.y=jumpHeight;
				print ("Jumping");
			}
		}
		if(newPos.y>TerminalVelocity){
			newPos.y += gravity*Time.deltaTime;
			
		}
		controller.Move (newPos);
	}
}

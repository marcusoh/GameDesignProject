using UnityEngine;
using System.Collections;
public class move : MonoBehaviour {
	public static GameObject platform1;
	public Transform prefab;
	public static float counter;
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
		GUIManager.setGreenLives (6);
		counter=0;
		platform1 = GameObject.Find("startPlatform2");
	}
	void Update () {
		counter++;
		if(counter==30f){
			platform1.gameObject.SetActive(false);
		}
		pos = Input.GetAxis("Horizontal1");
		newPos.x = pos*(Time.deltaTime+.2f)*3f;
		if(Input.GetButton("Jump1")){
			if(controller.isGrounded){
				newPos.y=jumpHeight;
				print ("Jumping");
			}
		}
		if(newPos.y>TerminalVelocity){
			newPos.y += gravity*Time.deltaTime;
		}
		if(Input.GetButtonDown("Player1Fire")){
			Transform b=(Transform)Instantiate (prefab, transform.localPosition,transform.localRotation);
			Bullet bscript=b.GetComponent<Bullet>();
		}
		if(Input.GetButtonDown("Reset")){
			Application.LoadLevel(0);
		}
		int lives=GUIManager.getGreenLives();
		if(lives==0){
			Application.LoadLevel(2);
		}

	}
	void FixedUpdate(){
		controller.Move (newPos);
	}
}
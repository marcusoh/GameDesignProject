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
	public bool isRight;



	float moveDir;
	bool faceL=false;
	Vector3 scale = new Vector3(1,1,1);
	Animator animator;


	void Start () {
		controller = GetComponent<CharacterController>();
		GUIManager.setGreenLives (6);
		counter=0;
		platform1 = GameObject.Find("startPlatform2");

		animator = this.gameObject.GetComponentInChildren<Animator> ();
	}
	void Update () {
	
		/*if(moveDir<0&& !faceL){
			faceL=true;
			scale.x*=1.0f;
			transform.localScale=scale;
		}
		else if(moveDir>0){
			faceL=false;
			scale.x=-1.0f;
			transform.localScale = scale;
		}

*/
		/*if (Input.GetAxis("Horizontal")!=0){
			animator.SetBool("isWalking",true);
		}
		if (Input.GetButtonUp("Horizontal")){
			animator.SetBool("isWalking", false);
		}
		if (Input.GetButtonDown("Vertical")){
			animator.SetTrigger ("jump");
			animator.SetBool("isWalking",false);
		}
		*/


		//
		//
		counter++;
		if((counter==30f) && (platform1 != null)){
			platform1.gameObject.SetActive(false);
		}
		pos = Input.GetAxis("Horizontal1");
		print (pos);
		if(pos > 0){
			isRight = true;
			animator.SetBool("isWalking",true);
			if(faceL){
				faceL=false;
				scale.x=-1.0f;
				transform.localScale = scale;
			}
		}
		else if(pos <0){
			isRight = false;
			animator.SetBool("isWalking",true);
			if(!faceL){
				faceL=true;
				scale.x*=-1.0f;
				transform.localScale=scale;
			}
		}
		else if(pos == 0){
			animator.SetBool("isWalking",false);
		}
		newPos.x = pos*(Time.deltaTime+.2f)*3f;
		if(Input.GetButton("Jump1")){
			if(controller.isGrounded){
				animator.SetTrigger ("StartJump");
				animator.SetBool("isWalking",false);
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
			bscript.direction = isRight;
		}
		if(Input.GetButtonDown("Reset")){
			Application.LoadLevel(0);
		}
		int lives=GUIManager.getGreenLives();
		if(lives==0){
			Application.LoadLevel(3);
		}

	}
	void FixedUpdate(){
		controller.Move (newPos);
	}
}
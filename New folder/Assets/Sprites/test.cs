using UnityEngine;
using System.Collections;

public class moveScript : MonoBehaviour {
	int health = 100;
	int maxHealth=110;
	float moveDir;
	bool faceL=false;
	Vector3 scale = new Vector3(1,1,1);
	Animator animator;
	void Start () {
		animator = this.gameObject.GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		moveDir=Input.GetAxis ("Horizontal");
		if(moveDir<0&& !faceL){
			faceL=true;
			scale.x*=-1.0f;
			transform.localScale=scale;
		}
		else if(moveDir>0){
			faceL=false;
			scale.x=1.0f;
			transform.localScale = scale;
		}
		if (Input.GetAxis("Horizontal")!=0){
			animator.SetBool("isWalking",true);
		}
		if (Input.GetButtonUp("Horizontal")){
			animator.SetBool("isWalking", false);
		}
		if (Input.GetButtonDown("Vertical")){
			animator.SetTrigger ("jump");
			animator.SetBool("isWalking",false);
		}
		if(Input.GetKeyUp ("return")){
			manageHealth(-50);
		}
	}
	void manageHealth(int h){
		health+=h;
		if(health>=maxHealth){
			health=maxHealth;
		}
		if(health<=0){
			health=0;
			animator.SetTrigger ("setDie");
			print ("dead");
		}
	}
}

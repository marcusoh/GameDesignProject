using UnityEngine;
using System.Collections;

public class Bullet2 : MonoBehaviour {
	public float speed=10f;
	public float acceleration=1f;
	public float value2=0f;
	Vector2 flightPos = new Vector2 (0f,0f);
	void Start () {
		flightPos = transform.localPosition;
		value2=Input.GetAxis ("Horizontal2");
	}
	void Update () {
		
		if(value2<0f){
			flightPos.x-=speed*Time.deltaTime+1f;
			transform.localPosition = flightPos;
		}
		if(value2>0f){
			flightPos.x+=speed*Time.deltaTime+1f;
			transform.localPosition = flightPos;
		}
		if(value2==0f){
			flightPos.x+=speed*Time.deltaTime+1f;
			transform.localPosition = flightPos;
		}
		
	}
	void OnTriggerEnter(Collider other) {
		if(other.gameObject.name==("Player")){
			Destroy(this.gameObject);
			GUIManager.setGreenLives ();
		}
	}
}

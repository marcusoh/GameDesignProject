using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {
	public float speed=10f;
	public float acceleration=1f;
	public float value=0f;
	Vector2 flightPos = new Vector2 (0f,0f);
	void Start () {
		flightPos = transform.localPosition;
		value=Input.GetAxis("Horizontal1");
	}
	void Update () {

		if(value<0f){
			flightPos.x-=speed*Time.deltaTime+1f;
			transform.localPosition = flightPos;
		}
		if(value>0f){
			flightPos.x+=speed*Time.deltaTime+1f;
			transform.localPosition = flightPos;
		}
		if(value==0f){
			flightPos.x-=speed*Time.deltaTime+1f;
			transform.localPosition = flightPos;
		}

	}
	//void bulletmove(Vector2 Currentpos){
	//	flightPos.x=speed*Time.deltaTime+.5f;
	//	transform.localPosition.x=flightPos;
}

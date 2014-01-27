using UnityEngine;
using System.Collections;
public class Bullet2 : MonoBehaviour {
	public float speed=10f;
	public float acceleration=1f;
	public float value2=0f;
	Vector2 flightPos = new Vector2 (0f,0f);
	public bool direction;
	void Start () {
		flightPos = transform.localPosition;

	}
	void Update () {
		
		if(direction){
	
			flightPos.x+=speed*Time.deltaTime+1f;
			transform.localPosition = flightPos;
		}
		if(!direction){

			flightPos.x-=speed*Time.deltaTime+1f;
			transform.localPosition = flightPos;
		}
	}
	void OnTriggerEnter(Collider other) {
		if(other.gameObject.name==("Player")){
			int number = (GUIManager.getGreenLives ()) - 1;
			GUIManager.setGreenLives (number);
			Destroy(this.gameObject);
		}
	}
}

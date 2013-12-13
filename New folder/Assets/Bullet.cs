using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {
	public float speed=10f;
	public float acceleration=1f;
	Vector2 flightPos = new Vector2 (0f,0f);
	void Start () {
	
	}
	void Update () {
		flightPos.x=speed*Time.deltaTime+.5f;	
	}
}

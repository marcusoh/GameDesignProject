using UnityEngine;
using System.Collections;

public class GUIManager : MonoBehaviour {
	public static GUIText RedHealth;
	public static GUIText GreenHealth;
	public static int RedLives = 6;
	public static int GreenLives = 6;
	// Use this for initialization
	void Start () {
		RedHealth = GameObject.Find ("RedHealth").GetComponent<GUIText>();
		GreenHealth=GameObject.Find ("GreenHealth").GetComponent<GUIText>();
		RedHealth.text = "Health: "+ RedLives;
		GreenHealth.text ="Health: " + GreenLives;
		RedHealth.enabled = true;
		GreenHealth.enabled = true;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public static void setRedLives(){
		RedLives--;
		RedHealth.text = "Health: "+ RedLives;
	}
	public static void setGreenLives(){
		GreenLives--;
		GreenHealth.text = "Health: "+ GreenLives;
	}
	public static int getRedLives(){
		return RedLives;

	}
	public static int getGreenLives(){
		return GreenLives;
	}
}
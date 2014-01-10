using UnityEngine;
using System.Collections;
public class GUIManager : MonoBehaviour {
	public static GUIText RedHealth;
	public static GUIText GreenHealth;
	public static int RedLives = 6;
	public static int GreenLives = 6;
	void Start () {
		RedHealth = GameObject.Find ("RedHealth").GetComponent<GUIText>();
		GreenHealth=GameObject.Find ("GreenHealth").GetComponent<GUIText>();
		RedHealth.text = "Health: "+ RedLives;
		GreenHealth.text ="Health: " + GreenLives;
		RedHealth.enabled = true;
		GreenHealth.enabled = true;
	}
	void Update () {
		
	}
	public static void setRedLives(int number){
		RedLives=number;
		RedHealth.text = "Health: "+ RedLives;

	}
	public static void setGreenLives(int number){
		GreenLives=number;
		GreenHealth.text = "Health: "+ GreenLives;
	}
	public static int getRedLives(){
		return RedLives;
	}
	public static int getGreenLives(){
		return GreenLives;
	}
}
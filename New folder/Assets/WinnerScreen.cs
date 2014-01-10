using UnityEngine;
using System.Collections;
public class WinnerScreen : MonoBehaviour {
	public static GUIText WinnerText;
	public static float timer;
	void Start () {
		timer = 0;
		WinnerText=GameObject.Find ("WinnerText").GetComponent<GUIText>();
		WinnerText.enabled = true;
		WinnerText.text="   ";
		if(GUIManager.getRedLives()==0){
			WinnerText.text="Player 1";
		}
		if(GUIManager.getGreenLives()==0){
			WinnerText.text="Player 2";
		}
		GUIManager.setGreenLives (6);
		GUIManager.setRedLives (6);
	}
		void Update () {
		timer++;
		if(timer==300f){
			Application.LoadLevel(0);
		}
	}
}

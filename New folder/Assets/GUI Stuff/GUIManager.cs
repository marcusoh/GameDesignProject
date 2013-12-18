using UnityEngine;
using System.Collections;

public class GUIManager : MonoBehaviour {
	public GUIText RedHealth;
	public GUIText GreenHealth;
	public int RedLives = 6;
	public int GreenLives = 6;
	// Use this for initialization
	void Start () {
		RedHealth.text = "Health: " + RedLives;
		GreenHealth.text ="Health: " + GreenLives;
		RedHealth.enabled = true;
		GreenHealth.enabled = true;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}

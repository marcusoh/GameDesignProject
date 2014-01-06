using UnityEngine;
using System.Collections;

public class LevelTrigger : MonoBehaviour {
void Update(){
	if(Input.GetButtonDown("Fire2")){
		Application.LoadLevel(1);
		}
	}
}

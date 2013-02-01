using UnityEngine;
using System.Collections;

public class GlobalControls : MonoBehaviour {

	void Update () {
		if(Input.GetKeyDown("r")){
			//reset the level
			
			GameObject[] gameObjects = FindObjectsOfType(typeof(GameObject)) as GameObject[];
	        foreach (GameObject gameObject in gameObjects) {
	            gameObject.SendMessage("Reset", SendMessageOptions.DontRequireReceiver);
	        }
		}
	}
}

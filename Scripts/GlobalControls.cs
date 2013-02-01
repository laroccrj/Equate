using UnityEngine;
using System.Collections;

public class GlobalControls : MonoBehaviour {
	
	Goal playerGoal;
	Goal shadowGoal;
	
	void Awake () {
		playerGoal = (Goal)GameObject.Find("PGoal").GetComponent(typeof(Goal));
		shadowGoal = (Goal)GameObject.Find("SGoal").GetComponent(typeof(Goal));
	}
	
	void Update () {
		if(Input.GetKeyDown("r")){
			//reset the level
			
			GameObject[] gameObjects = FindObjectsOfType(typeof(GameObject)) as GameObject[];
	        foreach (GameObject gameObject in gameObjects) {
	            gameObject.SendMessage("Reset", SendMessageOptions.DontRequireReceiver);
	        }
		}
		
		if(playerGoal.hitting && shadowGoal.hitting) {
			Win();
		}
	}
	
	void Win(){
		Application.LoadLevel(Application.loadedLevelName);	
	}
}

using UnityEngine;
using System.Collections;

public class GlobalControls : MonoBehaviour {
	
	Goal playerGoal;
	Goal shadowGoal;
	Spawner spawner;
	public GUIStyle pauseStyle;
	public bool paused;
	public bool solving = false;
	
	void Awake () {
		playerGoal = (Goal)GameObject.Find("PGoal").GetComponent(typeof(Goal));
		shadowGoal = (Goal)GameObject.Find("SGoal").GetComponent(typeof(Goal));
		spawner = (Spawner)gameObject.GetComponent(typeof(Spawner));
	}
	
	void Update () {
		if(Input.GetKeyDown("r")){
			//reset the level
			
			GameObject[] gameObjects = FindObjectsOfType(typeof(GameObject)) as GameObject[];
	        foreach (GameObject gameObject in gameObjects) {
	            gameObject.SendMessage("Reset", SendMessageOptions.DontRequireReceiver);
	        }
		}
		
		//Player wins
		if(playerGoal.hitting && shadowGoal.hitting) {
			Win();
		}
		
		//Pause the game
		if(Input.GetKeyDown("p")) {
			if(paused) 
				paused = false;
			else
				paused = true;
		}
	}
	
	void OnGUI() {
		if(paused) {
			float midX = (Screen.width / 2) - 50;
			float midY = (Screen.height / 2);
			
			GUI.Box(new Rect(midX - 25,midY - 100, 150, 200), "", pauseStyle);
			
	        if (GUI.Button(new Rect(midX, midY - 70, 100, 30), "Main Menu"))
	            Application.LoadLevel(0);
	        
	        if (GUI.Button(new Rect(midX, midY - 35, 100, 30), "New Level"))
	            Application.LoadLevel(Application.loadedLevelName);	
			
			if (GUI.Button(new Rect(midX, midY, 100, 30), "Solve"))
	            Solve();
		}
        
    }
	
	void Win(){
		Application.LoadLevel(Application.loadedLevelName);	
	}
	
	void Solve() {
		Debug.Log(spawner.PlayerMoves[0]);
	}
}

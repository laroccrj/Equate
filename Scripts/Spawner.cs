using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour {
	
	public GameObject floor;
	public GameObject wall;
	public GameObject Player;
	public GameObject Shadow;
	public GameObject PlayerGoal;
	public GameObject ShadowGoal;
	public int wallChance;
	public int distance;
	
	private bool[,] spaces;
	private GameObject playerSpawned;
	private GameObject shadowSpawned;
	
	// Use this for initialization
	void Awake () {
		
		spaces = new bool[(int)floor.transform.localScale.x, (int)floor.transform.localScale.z];
		
		//Lets spawn some walls
		for (int i = 0; i < (int)floor.transform.localScale.x; i++) {
			
			for (int j = 0; j < (int)floor.transform.localScale.z; j++) {
				int randomNumber = Random.Range(0, 100);
				
				if (randomNumber < wallChance) {
					Instantiate(wall, new Vector3(i, 1, j), floor.transform.rotation);
					spaces[i, j] = true;
				} else {
					spaces[i, j] = false;	
				}
			}
			
		}
		
		//Lets spawn the player
		bool spawned = false;
		
		while (!spawned) {
			int randomX = Random.Range(0, (int)floor.transform.localScale.x);
			int randomZ = Random.Range(0, (int)floor.transform.localScale.z);
			
			if (!spaces[randomX, randomZ]) {
				playerSpawned = (GameObject)Instantiate(Player, new Vector3(randomX, 1, randomZ), floor.transform.rotation);
				playerSpawned.name = "Player";
				spaces[randomX, randomZ] = true;
				spawned = true;
			}
		}
		
		//Lets spawn the shadow
		spawned = false;
		
		while (!spawned) {
			int randomX = Random.Range(0, (int)floor.transform.localScale.x);
			int randomZ = Random.Range(0, (int)floor.transform.localScale.z);
			
			if (!spaces[randomX, randomZ]) {
				shadowSpawned = (GameObject)Instantiate(Shadow, new Vector3(randomX, 1, randomZ), floor.transform.rotation);
				shadowSpawned.name = "Shadow";
				spaces[randomX, randomZ] = true;
				spawned = true;
			}
		}
		
		//Now to path to the goals
		Vector3 playerSpot = playerSpawned.transform.position;
		Vector3 shadowSpot = shadowSpawned.transform.position;
		int moves = 0;
		
		while(moves < distance) {
			
			int direction = Random.Range(0, 4);
			
			switch(direction) {
				
				case 0:
					if(!Physics.Raycast(playerSpawned.transform.position, Vector3.forward, 1) && playerSpawned.transform.position.z < (int)floor.transform.localScale.z - 1) {
						playerSpawned.transform.position += Vector3.forward;
					}
				
					if(!Physics.Raycast(shadowSpawned.transform.position, Vector3.back, 1) && shadowSpawned.transform.position.z > 0) {
						shadowSpawned.transform.position += Vector3.back;
					}
				break;
				
				case 1:
					if(!Physics.Raycast(playerSpawned.transform.position, Vector3.back, 1) && playerSpawned.transform.position.z > 0) {
						playerSpawned.transform.position += Vector3.back;
					}
				
					if(!Physics.Raycast(shadowSpawned.transform.position, Vector3.forward, 1) && shadowSpawned.transform.position.z < (int)floor.transform.localScale.z - 1) {
						shadowSpawned.transform.position += Vector3.forward;
					}
				break;
				
				case 2:
					if(!Physics.Raycast(playerSpawned.transform.position, Vector3.right, 1) && playerSpawned.transform.position.x < (int)floor.transform.localScale.x - 1) {
						playerSpawned.transform.position += Vector3.right;
					}
				
					if(!Physics.Raycast(shadowSpawned.transform.position, Vector3.left, 1) && shadowSpawned.transform.position.x > 0) {
						shadowSpawned.transform.position += Vector3.left;
					}
				break;
				
				case 3:
					if(!Physics.Raycast(playerSpawned.transform.position, Vector3.left, 1) && playerSpawned.transform.position.x > 0) {
						playerSpawned.transform.position += Vector3.left;
					}
				
					if(!Physics.Raycast(shadowSpawned.transform.position, Vector3.right, 1) && shadowSpawned.transform.position.x < (int)floor.transform.localScale.x - 1) {
						shadowSpawned.transform.position += Vector3.right;
					}
				break;
				
			}
			
			moves++;
			
		}
		
		GameObject playerGoal = (GameObject)Instantiate(PlayerGoal, playerSpawned.transform.position, floor.transform.rotation);
		GameObject shadowGoal = (GameObject)Instantiate(ShadowGoal, shadowSpawned.transform.position, floor.transform.rotation);
		playerGoal.name = "PGoal";
		shadowGoal.name = "SGoal";
		
		playerSpawned.transform.position = playerSpot;
		shadowSpawned.transform.position = shadowSpot;
	}
}

using UnityEngine;
using System.Collections;

public class Controller : MonoBehaviour {

	public bool player;
	public GameObject floor;
	
	void Awake () {
		floor = GameObject.Find("Floor");	
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.UpArrow)) {
			if(player && !Physics.Raycast(transform.position, Vector3.forward, 1) && transform.position.z < (int)floor.transform.localScale.z - 1) {
				transform.position += Vector3.forward;
			} else if(!player && !Physics.Raycast(transform.position, Vector3.back, 1) && transform.position.z > 0) {
				transform.position += Vector3.back;	
			}
		} else if(Input.GetKeyDown(KeyCode.DownArrow)) {
			if(player && !Physics.Raycast(transform.position, Vector3.back, 1) && transform.position.z > 0) {
				transform.position += Vector3.back;
			} else if(!player && !Physics.Raycast(transform.position, Vector3.forward, 1) && transform.position.z < (int)floor.transform.localScale.z - 1) {
				transform.position += Vector3.forward;	
			}
		} else if(Input.GetKeyDown(KeyCode.RightArrow)) {
			if(player && !Physics.Raycast(transform.position, Vector3.right, 1) && transform.position.x < (int)floor.transform.localScale.x - 1) {
				transform.position += Vector3.right;
			} else if(!player && !Physics.Raycast(transform.position, Vector3.left, 1) && transform.position.x > 0) {
				transform.position += Vector3.left;	
			}
		} else if(Input.GetKeyDown(KeyCode.LeftArrow)) {
			if(player && !Physics.Raycast(transform.position, Vector3.left, 1) && transform.position.x > 0) {
				transform.position += Vector3.left;
			} else if(!player && !Physics.Raycast(transform.position, Vector3.right, 1) && transform.position.x < (int)floor.transform.localScale.x - 1) {
				transform.position += Vector3.right;	
			}	
		} 
	}
}

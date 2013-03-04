using UnityEngine;
using System.Collections;

public class Goal : MonoBehaviour {
	
	public GameObject target;
	public bool hitting = false;
	
	void Start() {
		if(gameObject.name == "PGoal") {
			target = GameObject.Find("Player");
		} else {
			target = GameObject.Find("Shadow");	
		}
	}
	
	void Update () {		
		if(transform.position == target.transform.position && !hitting)
			hitting = true;
		else if(transform.position != target.transform.position && hitting)
			hitting = false;
	}
}

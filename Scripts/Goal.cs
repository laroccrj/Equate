using UnityEngine;
using System.Collections;

public class Goal : MonoBehaviour {
	
	public GameObject target;
	public bool hitting = false;
	
	void Update () {
		if(target == null) {
			if(gameObject.name == "PGoal") {
				target = GameObject.Find("Player");
			} else {
				target = GameObject.Find("Shadow");	
			}
		}
		
		if(transform.position == target.transform.position && !hitting) {
			hitting = true;
		} else if(transform.position != target.transform.position && hitting){
			hitting = false;
		}
	}
}

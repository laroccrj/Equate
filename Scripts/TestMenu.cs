using UnityEngine;
using System.Collections;

public class TestMenu : MonoBehaviour {

	 void OnGUI() {
		
		float midX = (Screen.width / 2) - 50;
		float midY = (Screen.height / 2);
		
        if (GUI.Button(new Rect(midX, midY - 70, 100, 30), "Easy"))
            Application.LoadLevel(1);
        
        if (GUI.Button(new Rect(midX, midY - 35, 100, 30), "Medium"))
            Application.LoadLevel(2);
		
		if (GUI.Button(new Rect(midX, midY, 100, 30), "Hard"))
            Application.LoadLevel(3);
        
        if (GUI.Button(new Rect(midX, midY + 35, 100, 30), "Extreme"))
            Application.LoadLevel(4);
        
    }
}

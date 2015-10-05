using UnityEngine;
using System.Collections;

public class SceneLoader : MonoBehaviour {
    public string levelSelect;
    public string nextLevel;
    public string mainMenu;
	public Camera mainCamera;
	private bool win = true;
    /*void OnTriggerEnter2D(Collider2D other)
    {
        Application.LoadLevel(nextLevel);
    }
    */

	void OnTriggerEnter2D(Collider2D other)
	{
		win = true;
	}
	
	void OnGUI()
	{
		print ("Render");
		/*if (win) {	
			// Make a background box
			GUI.Box (new Rect (420, 100, 125, 120), "Loader Menu");
			
			// Make the first button. If it is pressed, Application.Loadlevel (1) will be executed
			if (GUI.Button (new Rect (430, 130, 100, 20), "Next Level")) {
				Application.LoadLevel (nextLevel);
			}
			
			// Make the second button.
			if (GUI.Button (new Rect (430, 155, 100, 20), "Level Select")) {
				Application.LoadLevel (levelSelect);
			}
			
			// Make the third button.
			if (GUI.Button (new Rect (430, 180, 100, 20), "Exit")) {
				Application.LoadLevel (mainMenu);
			}
		}
		*/

		if (win) {
			if (GUI.Button (new Rect ((mainCamera.pixelWidth - 100)/2, (mainCamera.pixelHeight - 120)/2, 100, 20), "Next Level")){
				Application.LoadLevel(nextLevel);
			}
			if (GUI.Button (new Rect((mainCamera.pixelWidth - 100)/2, (mainCamera.pixelHeight - 60)/2, 100, 20), "Level Select")){
				Application.LoadLevel(levelSelect);
			}
			if (GUI.Button (new Rect ((mainCamera.pixelWidth - 100)/2, (mainCamera.pixelHeight - 0)/2, 100, 20), "Main Menu")){
				Application.LoadLevel(mainMenu);
			}
			
		}
	}
}
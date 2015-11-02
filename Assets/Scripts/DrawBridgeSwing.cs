using UnityEngine;
using System.Collections;

public class DrawBridgeSwing : MonoBehaviour {
	public float DbRotation;
	public bool swingUp = true;
	
	void Update(){
		DbRotation = Mathf.Clamp (DbRotation, 1, 45);
		if (Input.GetKeyDown (KeyCode.U)) {
			swingUp = true;
			if (swingUp){
				DbRotation += .5f;
				transform.rotation = Quaternion.Euler(transform.localEulerAngles.x, transform.localEulerAngles.y, DbRotation);
				if(DbRotation >= 45)
					swingUp = false;
			} 
		}
		else if (Input.GetKeyDown(KeyCode.J)){
			swingUp = true;
			if (swingUp){
				DbRotation += .5f;
				transform.rotation = Quaternion.Euler(transform.localEulerAngles.x, transform.localEulerAngles.y, DbRotation);
				if(DbRotation >= 45)
					swingUp = true;
			} 
		}
	}
}

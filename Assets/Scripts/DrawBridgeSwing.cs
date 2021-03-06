﻿using UnityEngine;
using System.Collections;

public class DrawBridgeSwing : MonoBehaviour {
	public float DbRotation = 85.5f;
    public bool swingDown = false;

	void Start(){
		DbRotation -= 89.5f;
		transform.rotation = Quaternion.Euler(transform.localEulerAngles.x, transform.localEulerAngles.y, DbRotation);
	}
	
	void Update(){
		DbRotation = Mathf.Clamp (DbRotation, 1, 89.5f);

		if (swingDown){
			DbRotation += .5f;
			transform.rotation = Quaternion.Euler(transform.localEulerAngles.x, transform.localEulerAngles.y, DbRotation);
			if(DbRotation >= 89.5 && Input.GetKey(KeyCode.U))
				swingDown = false;
		} 

		else if(!swingDown){
			DbRotation -= .5f;
			transform.rotation = Quaternion.Euler(transform.localEulerAngles.x, transform.localEulerAngles.y, DbRotation);
			if(DbRotation <= 1 && Input.GetKey(KeyCode.J))
				swingDown = true;
		} 
	}


}

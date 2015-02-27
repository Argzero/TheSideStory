using UnityEngine;
using System.Collections;

// Keeps the Camera over the main Character (Dan / Villager D)
public class CameraManager : MonoBehaviour {
	
	//public :: editable in Unity
	public Transform target;
	public float distance = 10.0f;

	//private :: editable ONLY in this file
	//--NONE--//

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame and updates the position
	void FixedUpdate () {
		gameObject.transform.position = new Vector3(target.position.x, target.position.y+1.25f, -10f);
	}
}

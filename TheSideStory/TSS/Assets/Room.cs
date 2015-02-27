using UnityEngine;
using System.Collections.Generic;

public class Room : MonoBehaviour {

	//public variables :: editable in Unity
	public bool Active = false;
	public GM gm;
	public List<RoomObject> Objects;

	//private :: editable ONLY in this file


	// Use this for initialization
	void Start () {
		gm = GameObject.FindGameObjectsWithTag("Manager")[0].GetComponent<GM>();
	}
	
	// Update is called once per frame
	void Update () {
		foreach(RoomObject ro in Objects){
			ModifyRoomObject(ro);
		}
	}

	void ModifyRoomObject(RoomObject ro){
		if(ro.IsActive()){
			BoxCollider2D collider = ro.gameObject.GetComponent<BoxCollider2D>();
			if(collider!=null)
				collider.isTrigger = false;
		}
		else{
			BoxCollider2D collider = ro.gameObject.GetComponent<BoxCollider2D>();
			if(collider!=null)
				collider.isTrigger = true;
		}
	}
}

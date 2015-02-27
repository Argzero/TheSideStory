using UnityEngine;
using System.Collections.Generic;

public class GM : MonoBehaviour {

	//public variables :: editable in Unity
	public List<Room> Rooms;
	public Room ActiveRoom;
	public GameObject Key;
	public GameObject Player;
	public List<Vector3> KeyPoints = new List<Vector3>();

	// Use this for initialization
	void Awake () {
		PlaceKey();
		Vector3 PlayerPoint = new Vector3(85.60999f, -1.398627f, -0.2827729f);
		Player.transform.position = PlayerPoint;
		Player.GetComponent<VillagerDControl>().Key = false;
	}
	
	// FixedUpdate is called such that the DeltaTime remains the same
	void FixedUpdate () {
		foreach(Room r in Rooms){
			if(r == ActiveRoom){
				r.Active = true;
			}
		}

		if(ActiveRoom == Rooms[4]){
			Application.LoadLevel("Title");
		}
	}

	void PlaceKey(){
		Vector3 KeyLocation = KeyPoints[(int)(Random.value*5)];
		Key.transform.position = KeyLocation;
	}

	public void SetActiveArea(Room roomToSet){
		ActiveRoom = roomToSet;
	}
}

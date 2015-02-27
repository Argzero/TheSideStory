using UnityEngine;
using System.Collections;

[RequireComponent (typeof (RoomObject))]
public class Door : MonoBehaviour {

	//public variables :: editable in Unity
	public Room Container;
	public RoomObject GeneralInfo;
	public Door Target;
	public Vector3 Offset;
	public int timer;
	public Light LightUp;
	public GM gm;
	public bool locked;
	public Animator DoorAnimator;

	//private :: editable ONLY in this file	
	//--NONE--//
	private GameObject PlayerObject;

	// Use this for initialization
	void Start () {
		LightUp = GetComponent<Light>();
		LightUp.enabled = false;
		PlayerObject = GameObject.FindGameObjectsWithTag("Player")[0];
		gm = GameObject.FindGameObjectsWithTag("Manager")[0].GetComponent<GM>();
	}
	
	// Update is called once per frame and checks to see if player tries to or is able to open a door and responds as would be expected.
	void FixedUpdate () {
		timer--;
		float distFromPlayer = (PlayerObject.transform.position - gameObject.transform.position).magnitude;
		if(distFromPlayer < 0.7 && gm.ActiveRoom == Container && timer<0){
			LightUp.enabled = true;
			if(Input.GetButtonDown("Interact")&&gm.ActiveRoom==Container){
				if(!locked||(PlayerObject.GetComponent<VillagerDControl>()).HasKey()){
					PlayerObject.transform.position = Target.gameObject.transform.position + Offset;
					gm.SetActiveArea(Target.Container);
					locked = false;
					(PlayerObject.GetComponent<LightSpawner>()).timer = 0;
				}
				else{
					DoorAnimator.Play("CantOpenDoor");
				}
					
				Target.timer = 20;
				// Debug.Log(Target.Container.gameObject.name);
			}
		}
		else
			LightUp.enabled = false;
	}
}

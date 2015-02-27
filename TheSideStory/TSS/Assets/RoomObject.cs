using UnityEngine;
using System.Collections;

public class RoomObject : MonoBehaviour {

	//public variables :: editable in Unity
	public Room Container;
	public bool glow = false;
	public float R = 1f,G = 1f,B = 1f;
	public enum RoomActive{
		Active,
		Inactive,
		ItoA,
		AtoI
	}
	public RoomActive Active;
	public float fade;

	//private :: editable ONLY in this file
	private SpriteRenderer spriteRenderer;

	// Use this for initialization
	void Start () {
		Active = RoomActive.Active;
	}

	void Awake() {
		spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
		spriteRenderer.color = new Color(1f,1f,1f,1f);
	}

	// Update is called once per frame
	void FixedUpdate () {
		if(Active==RoomActive.Active){ 
			fade = 1f; 
		} 
		else if(Active==RoomActive.Inactive){ 
			fade = 0f; 
		} 

		if(Active==RoomActive.Inactive && Container.Active){
			Active = RoomActive.ItoA;
			fade = 0f;
		}
		else if(Active==RoomActive.Active && !Container.Active){
			Active = RoomActive.AtoI;
			fade = 1f;
		}

		if(Active==RoomActive.ItoA){
			if(fade >= 1f)
				Active = RoomActive.Active;
			else
				fade += 0.2f;
		}
		else if(Active==RoomActive.AtoI){
			if(fade <= 0f)
				Active = RoomActive.Inactive;
			else
				fade -= 0.2f;
		}

		R = (glow)? 1.0f : 0.5f;
		G = (glow)? 1.0f : 0.5f;
		B = (glow)? 1.0f : 0.5f;
		spriteRenderer.color = new Color(R,G,B,fade);
	}

	public bool IsActive(){
		return Active==RoomActive.Active;
	}
}

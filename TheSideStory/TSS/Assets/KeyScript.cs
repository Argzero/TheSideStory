using UnityEngine;
using System.Collections;

public class KeyScript : MonoBehaviour {

	public VillagerDControl Player;
	public Vector3 Hidden = new Vector3(350,350,0);
	// Use this for initialization
	void Start () {
	
	}

	// When the player collides with the key, it sets the player to be able to complete the level
	void OnCollisionEnter2D (Collision2D collider) {
		if(collider.gameObject.tag=="Player"){
			Player.Key = true;
			this.gameObject.transform.position = Hidden;
		}
	}
}
using UnityEngine;
using System.Collections;

// An orb that Villager D can fire forward consisting of Aura which the ghosts are attracted to
public class LightBall : MonoBehaviour {

	int frame;
	int frameLimit = 0;
	Vector3 V = new Vector3(0,0,0);
	Vector3 A = new Vector3(0,0,0);
	float intensity;
	float scale;
	bool flyStarted = false;
	public bool Queued;
	public enum State{
		Spawning,
		Flying,
		Hovering
	}
	public State state;
	public GameObject Player;

	// Use this for initialization
	void Start () {
		scale = 0;
		frame = 0;
		frameLimit = 10;
		state = State.Spawning;
		Queued = false;
		Player = GameObject.FindGameObjectsWithTag("Player")[0];
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if(state == State.Spawning){
			scale+=0.025f;

			A = V = Vector3.zero;

			if(frame>frameLimit||Queued){
				V = Player.transform.position - gameObject.transform.position;
				state = State.Hovering;
			}
		}
		else if(state == State.Hovering){
			if(Queued){
				if(Player.GetComponent<VillagerDControl>().facingRight){
					V = new Vector3(.075f,0,0);
				}
				else{
					V = new Vector3(-.075f,0,0);
				}
				frame = 0;
				frameLimit = 300;
				gameObject.transform.parent = null;
				state = State.Flying;
			}
		}
		else if(state == State.Flying){
			gameObject.transform.position+=V;
			if(frame>frameLimit){
				Destroy(gameObject);
			}
		}
		gameObject.transform.localScale = new Vector3(scale, scale, 0);

		if(Queued && state == State.Hovering)
			state = State.Flying;

		frame++;
	}
}

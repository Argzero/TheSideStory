using UnityEngine;
using System.Collections.Generic;

public class LightSpawner : MonoBehaviour {
	public int MAX_LIGHTS;
	public int timer;
	public GameObject LightOrbPrefab;
	public List<GameObject> Orbs;
	public VillagerDControl CharacterController;

	// Use this for initialization
	void Start () {
		timer = 100;
	}
	
	// Update is called once per frame
	void Update () {
		if(timer < 0){
			timer = 200;
			Vector3 point = gameObject.transform.position;
			point.z = -.2f;
			GameObject NewOrb;
			if(Orbs.Count < MAX_LIGHTS){
				NewOrb = GameObject.Instantiate(LightOrbPrefab, point, Quaternion.identity) as GameObject;
				Orbs.Add(NewOrb);
				NewOrb.transform.parent = gameObject.transform;
			}
		}

		foreach(GameObject g in Orbs){
			Vector3 point = gameObject.transform.position;
			point.z = -.2f;
			g.transform.position = point;
		}

		if(Input.GetKeyDown(KeyCode.X) && Orbs.Count>0){
			Orbs[0].GetComponent<LightBall>().Queued = true;
			timer = 500;
			Orbs.Remove(Orbs[0]);
		}

		timer--;
	}
}

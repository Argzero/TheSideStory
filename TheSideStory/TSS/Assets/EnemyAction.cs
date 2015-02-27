using UnityEngine;
using System.Collections;

// Enemy AI Class
public class EnemyAction : MonoBehaviour {

	bool Active;
	bool Attacking; 
	float speed = 20f;
	protected Animator EnemyAnimator;
	protected bool faceRight;
	bool inRange;
	public float chaseDistance;
	public float AttackDistance;
	public GameObject Target; // Current approach target; Ghost will advance toward this object
	public GameObject PTarget;

	// Use this for initialization
	void Start () {
		faceRight = false;
		EnemyAnimator = gameObject.GetComponent <Animator>();
		if(Target == null){
			Target = GameObject.FindWithTag("Player");
		}
		inRange = false;
		Active = false;
		Attacking = false;
		gameObject.AddComponent<Light>();
		gameObject.light.color = Color.red;
	}
	
	// Update is called once per frame; approaches target
	void Update () {
		if(Target!=null)
		{
			float Distance = Vector2.Distance(Target.transform.position,transform.position);
			//Debug.Log(Distance);
			if(Target.transform.position.x < transform.position.x)
			{
				if(!faceRight)
				{
					Vector2 enemyScale = transform.localScale;
					enemyScale.x *= -1;
					transform.localScale = enemyScale;
					faceRight = true;
				} 
			}
			else
			{ 
				if(faceRight)
				{
					Vector2 markScale = transform.localScale;
					markScale.x *= -1;
					transform.localScale = markScale;
					faceRight = false;
				}
			}


			if(Distance <= chaseDistance)
			{
				EnemyAnimator.SetBool("Active", true);
				Active = true;
				Chase();
			}
			else
			{
				EnemyAnimator.SetBool("Active", false);
				Active = false;
			}

			if(Active && Distance <= AttackDistance)
			{
				EnemyAnimator.SetBool("Attacking", true);
				Attacking = true;
			}
			else{
				EnemyAnimator.SetBool("Attacking", false);
				Attacking = false;
			}
		}	
		if(Target == null){
			Vector2 D = Vector2.zero;
			Vector2 nearestD = Vector2.zero;
			foreach(GameObject g in GameObject.FindGameObjectsWithTag("LIGHT")){
				D = g.transform.position - transform.position;
				if(D.magnitude<nearestD.magnitude){
					nearestD = D;
					Target = g;
				}
			}
		}
	}

	// Can detect being hit by light orb shots but only detects it; nothing more
	void OnCollisionEnter2D(Collision2D coll){
		//Debug.Log("Hit Confirmed");
		if(Attacking){
			if(coll.gameObject.tag == "LIGHT"){
				Debug.Log("Hit Confirmed");
			}
		}
	}

	// Approach implementation
	void Chase()
	{
		Vector2 NearestPosition = Vector2.zero;
		Vector2 D = Vector2.zero;
		Vector2 nearestD = Vector2.zero;
		foreach(GameObject g in GameObject.FindGameObjectsWithTag("LIGHT")){
			D = g.transform.position - transform.position;
			if(D.magnitude<nearestD.magnitude){
				nearestD = D;
				NearestPosition = new Vector2(g.transform.position.x,g.transform.position.y);
				Target = g;
			}
		}
		if(PTarget != Target){
			speed = 0;
			PTarget = Target;
		}
		Vector2 Directon = Vector3.Normalize(D);
		Directon = new Vector2(Directon.x,Directon.y);
		Directon*=4;

		transform.Translate(Directon*Time.deltaTime);
	}
}

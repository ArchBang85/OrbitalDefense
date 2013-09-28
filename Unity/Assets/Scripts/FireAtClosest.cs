using UnityEngine;
using System.Collections;

public class FireAtClosest : MonoBehaviour {
	
	public GameObject explosionPreFab;
	public GameObject explosionCollider;
	
	  GameObject FindClosestEnemy() {
        GameObject[] gos;
        gos = GameObject.FindGameObjectsWithTag("Enemy");
        GameObject closest = null;
        float distance = Mathf.Infinity;
        Vector3 position = transform.position;
        foreach (GameObject go in gos) {
            Vector3 diff = go.transform.position - position;
            float curDistance = diff.sqrMagnitude;
            if (curDistance < distance) {
                closest = go;
                distance = curDistance;
            }
        }
        return closest;
    }

	public float speed = 10f;
	private GameObject victim;
	GameObject enemy;
	
	public float acceleration = 9f;
	private float turnWait; 
	public float turnWaitReset = 1f;
	
	// Use this for initialization
	void Start () {
		
	turnWait = turnWaitReset;
	victim = FindClosestEnemy();
	Destroy(this.gameObject, 4f);
		transform.position = Vector3.MoveTowards(transform.position, new Vector3 (0,0,1), -Time.deltaTime * speed);
	}
	// Update is called once per frame
	void Update () {
		speed = speed  + (acceleration * 0.05f);
		if (turnWait > 0) { turnWait -= Time.deltaTime; }
		else {
			if ((victim.transform.position - transform.position).sqrMagnitude > 50) { victim = FindClosestEnemy();}
			if (victim == null) { victim = FindClosestEnemy();}
			turnWait = turnWaitReset;
		}
	transform.position = Vector3.MoveTowards(transform.position, victim.transform.position, Time.deltaTime * speed);
		
		
	}
	
	void OnTriggerEnter (Collider collDetect) {
	
		if (collDetect.gameObject.tag == "Enemy") {
		
			Debug.Log("BAWOOM!");
			Instantiate (explosionPreFab, transform.position, Quaternion.identity);
			Instantiate (explosionCollider, transform.position, Quaternion.identity);
			Destroy(this.gameObject);

			// damage dealing here
		
		}

		else { Debug.Log("Dinnae work!"); }
	}
}

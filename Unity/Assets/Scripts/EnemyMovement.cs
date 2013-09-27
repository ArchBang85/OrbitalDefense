using UnityEngine;
using System.Collections;

public class EnemyMovement : MonoBehaviour {
	
	public GameObject explosionPreFab;
	
	public float speed = 1f;
	// Use this for initialization
	void Start () {
		
		
	
	}
	
	// Update is called once per frame
	void Update () {
		
		transform.position = Vector3.MoveTowards(transform.position, new Vector3 (0,0,0), Time.deltaTime * speed);
		
	}
	
	void OnTriggerEnter (Collider collDetect) {
	
		if (collDetect.gameObject.tag == "Player") {
		
			Debug.Log("BOOM!");
			Instantiate (explosionPreFab, transform.position, Quaternion.identity);
			Destroy(this.gameObject);

			// damage dealing here
		
		}

		else { Debug.Log("Dinnae work!"); }
	}
}

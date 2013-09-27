using UnityEngine;
using System.Collections;

public class FireAtClosest : MonoBehaviour {
	
	public float speed = 3f;
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
		transform.position = Vector3.MoveTowards(transform.position, new Vector3 (10,0,0), Time.deltaTime * speed);
		
	}
	
	void OnTriggerEnter (Collider collDetect) {
	
		if (collDetect.gameObject.tag == "Player") {
		
			Debug.Log("BOOM!");
			Destroy(this.gameObject);

			// damage dealing here
		
		}

		else { Debug.Log("Dinnae work!"); }
	}
}

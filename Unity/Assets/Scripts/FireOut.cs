using UnityEngine;
using System.Collections;

public class FireOut : MonoBehaviour {
	
	public float speed = 3f;
	
	// Use this for initialization
	void Start () {
		Destroy(this.gameObject, 8f);
	
	}
	
	// Update is called once per frame
	void Update () {
		
		transform.position = Vector3.MoveTowards(transform.position, new Vector3 (0,0,1), -Time.deltaTime * speed);
		
	}
	
	void OnTriggerEnter (Collider collDetect) {
	
		if (collDetect.gameObject.tag == "Enemy") {
		
			Debug.Log("BOOM!");
			Destroy(this.gameObject);

			// damage dealing here
		
		}

		else { Debug.Log("Dinnae work!"); }
	}
}

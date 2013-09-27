using UnityEngine;
using System.Collections;

public class ExplosionCleanup : MonoBehaviour {
	
	public float deathtime = 2f;
	
	// Use this for initialization
	void Start () {
		
		Destroy(this.gameObject, deathtime);
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}

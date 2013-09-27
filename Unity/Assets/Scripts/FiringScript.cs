using UnityEngine;
using System.Collections;

public class FiringScript : MonoBehaviour {
	
	public GameObject[] ammoType;
	
	private float coolDown; 
	public float coolDownReset = 0.5f;
	
	public bool canFire = true;
	
	// Use this for initialization
	void Start () {
		coolDown = coolDownReset;
	
	}
	
	// Update is called once per frame
	void Update () {
		
		if (canFire)
		{
		
			if (coolDown > 0) {coolDown -= Time.deltaTime;}
			else {
				Instantiate (ammoType[0], transform.position, Quaternion.identity);
				coolDown = coolDownReset;
			}
			
		}
	
	}
}

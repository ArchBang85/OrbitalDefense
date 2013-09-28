using UnityEngine;
using System.Collections;

public class ExplosionBlastwave : MonoBehaviour {
	
	public float tiem = 0.5f;
	
	
	// Use this for initialization
	void Start () {
		
	
	
	}
	
	// Update is called once per frame
	void Update () {
		
		if (tiem > 0) {transform.localScale *= 1.1f; tiem -= Time.deltaTime;}
			Color color = renderer.material.color;
			color.a -= 0.04f;
			renderer.material.color = color;

			
	}
}

using UnityEngine;
using System.Collections;

public class ExplosionBlastwave : MonoBehaviour {
	
	public float tiem = 0.5f;
	public float totalsize = 1f;
	
	
	// Use this for initialization
	void Start () {
		
	
	
	}
	
	// Update is called once per frame
	void Update () {
		
		if (tiem > 0 && totalsize < 5f) {transform.localScale *= 1.1f; tiem -= Time.deltaTime; totalsize *= 1.1f;}
		
			Color color = renderer.material.color;
			color.a -= 0.04f;
			renderer.material.color = color;

			
	}
}

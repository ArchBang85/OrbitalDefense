using UnityEngine;
using System.Collections;

public class ExplosionLightFade : MonoBehaviour {
	
	public static float speedFadeMin = 2f;
	public static float speedFadeMax = 6f;
	public static float speedFade = Random.Range (speedFadeMin, speedFadeMax);
	// Use this for initialization
	void Start () {

		
	}
	
	// Update is called once per frame
	void Update () {
		
		light.intensity -= speedFade * Time.deltaTime;
		
	}
}

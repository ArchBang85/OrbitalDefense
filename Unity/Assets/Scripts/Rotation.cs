﻿using UnityEngine;
using System.Collections;

public class Rotation : MonoBehaviour {
	
	public float rotateX, rotateY, rotateZ;
	
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
		transform.Rotate(rotateX *  Time.deltaTime, rotateY *  Time.deltaTime, rotateZ *  Time.deltaTime);
		
	}
}

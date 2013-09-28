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
	public float rotSpeed = 360f;
	private bool checkFlag = false;
	private bool runOnce = true;
	
	public float acceleration = 9f;
	private float turnWait, initialCheck; 
	public float turnWaitReset = 0.5f;
	private Vector3 endzone;
	
	// Use this for initialization
	void Start () {
		
	turnWait = turnWaitReset;
	initialCheck = turnWaitReset;
	victim = FindClosestEnemy();
	Destroy(this.gameObject, 2f);
		transform.position = Vector3.MoveTowards(transform.position, new Vector3 (0,0,1), -Time.deltaTime * speed);
		endzone = new Vector3 (0,0,1);

	}
	// Update is called once per frame
	void Update () {
		speed = speed  + (acceleration * 0.05f);
		turnWait -= Time.deltaTime;
		
		if (victim != null) {endzone = victim.transform.position;}
		if (initialCheck < 0) {checkFlag = true;}
		else initialCheck -= Time.deltaTime;
		{ transform.position = Vector3.MoveTowards(transform.position, new Vector3 (0,0,1), -Time.deltaTime * speed);}
		if (checkFlag && runOnce) {runOnce = false; endzone *= 10;}
		if (checkFlag) //make it so that the thing does the thing (missiles know their speed for dynamic acceleration).
		{ 
		
		 	if (turnWait < 0) {
			Vector3 D = victim.transform.position - transform.position;
			Quaternion rot = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(D), rotSpeed * Time.deltaTime);
			transform.rotation = rot;
			transform.eulerAngles = new Vector3(transform.eulerAngles.x+90, transform.eulerAngles.y, 0);
			
							
			turnWait = turnWaitReset;
			}
			transform.position = Vector3.MoveTowards(transform.position, endzone, Time.deltaTime * speed);
		}
		else {victim = FindClosestEnemy();}

		

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

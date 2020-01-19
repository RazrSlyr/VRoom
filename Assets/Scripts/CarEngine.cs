using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CarEngine : MonoBehaviour {

	public Transform path;
	public float maxSteerAngle = 45f;

	private List<Transform> nodes;
	private int currentNode = 0;
	public WheelCollider wheelFL;
	public WheelCollider wheelFR;
	public float torque;
	float slope;

	public static int score;

	// Use this for initialization
	void Start () {
		score = 0;
		Transform[] pathTransforms = path.GetComponentsInChildren<Transform> ();
		nodes = new List<Transform> ();

		for (int i = 0; i < pathTransforms.Length; i++) {
			if (pathTransforms [i] != path.transform) {
				nodes.Add (pathTransforms [i]);
			}
		}
		transform.LookAt (nodes [1].position);
	}
	
	// Update is called once per frame

	void FixedUpdate () {		
		ApplySteer ();
		Drive ();
		CheckWaypointDistance ();
	}

	void ApplySteer(){
		Vector3 relativeVector = transform.InverseTransformPoint (nodes [currentNode].position);
		float newSteer = (relativeVector.x / relativeVector.magnitude) * maxSteerAngle;
		wheelFL.steerAngle = newSteer;
		wheelFR.steerAngle = newSteer;
	}


	void Drive(){

		Vector2 transformPosition;
		transformPosition.x = transform.position.x;
		transformPosition.y = transform.position.z;

		Vector2 currentNodePosition;
		currentNodePosition.x = nodes[currentNode].position.x;
		currentNodePosition.y = nodes[currentNode].position.z;

		slope = (nodes [currentNode].position.y - transform.position.y) / Vector2.Distance (transformPosition, currentNodePosition);
		print (slope);

		wheelFL.motorTorque = torque;
		wheelFR.motorTorque = torque;

	}

	void CheckWaypointDistance(){
		int testNum = 1000;
		//print (Vector3.Distance (transform.position, nodes [currentNode].position));
		if (Vector3.Distance (transform.position, nodes [currentNode].position) < 5.0f) {
			if (currentNode >= nodes.Count - 1) {
				print("DONE");
				SceneManager.LoadScene("EndScreen");
				wheelFL.brakeTorque = torque + 1000;
				wheelFR.brakeTorque = torque + 1000;
			} else {
				currentNode++;
			}
		}
	}

}

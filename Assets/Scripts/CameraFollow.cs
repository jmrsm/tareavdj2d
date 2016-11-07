using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {
	public Transform target;

	private Vector3 targetPosition;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		this.targetPosition = this.target.position;
		this.targetPosition.z = -10;
		this.transform.position = Vector3.Lerp (this.transform.position, this.targetPosition, Time.deltaTime * 2);
	}
}

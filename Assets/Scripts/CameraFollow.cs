using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {
	public Transform target;

	private Vector3 targetPosition;
	private int targetPositionY;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		/*Camera camera = GetComponent<Camera> ();
		//Vector3 p = camera.ScreenToWorldPoint (this.target.position);
		//Gizmos.color = Color.yellow;*/
		//Gizmos.DrawSphere (p, 0.1F);
		this.targetPosition = this.target.position;
		this.targetPosition.z = -10;
		//Seteamos la camara para que quede fija
		this.targetPosition.y = -1.0f;
		this.transform.position = Vector3.Lerp (this.transform.position, this.targetPosition, Time.deltaTime * 2);

	}
}

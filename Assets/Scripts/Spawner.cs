using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour {
	public GameObject enemigPrfb0;
	public GameObject enemigPrfb1;
	public GameObject enemigPrfb2;
	public GameObject enemigPrfb3;
	public GameObject enemigPrfb4;
	public GameObject enemigPrfb5;
	private float time;
	private float timeToSpawn;
	// Use this for initialization
	void Start () {
		this.timeToSpawn = 10;
	}
	
	// Update is called once per frame
	void Update () {
		this.time += Time.deltaTime;
		if(this.time > this.timeToSpawn){
			this.time = 0;
			Instantiate (this.enemigPrfb0, this.transform.position, Quaternion.identity);
			Instantiate (this.enemigPrfb1, this.transform.position, Quaternion.identity);
			Instantiate (this.enemigPrfb2, this.transform.position, Quaternion.identity);
			Instantiate (this.enemigPrfb3, this.transform.position, Quaternion.identity);
			Instantiate (this.enemigPrfb4, this.transform.position, Quaternion.identity);
			Instantiate (this.enemigPrfb5, this.transform.position, Quaternion.identity);
		}
	}
}

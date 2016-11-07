using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour {
	public float hp;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	 
	}
	public void Hurt(float damage){
		this.hp -= damage;
		if (this.hp <= 0) {
			this.hp = 0;
			this.gameObject.SendMessage ("OneGetKill");
			Destroy (this.gameObject,0.01f);

		}
	}
	/*void OnCollisionEnter2D(Collision2D other)
	{
		//Debug.Log("entro a la colision");
		if (other.collider.CompareTag("Player"))
		{
			if(this.hp==0)
				other.collider.gameObject.SendMessage ("Dead", true);
		}
	}*/
}

using UnityEngine;
using System.Collections;

public class Parallax : MonoBehaviour {
	private Material mate;
	private float banner;
	private Renderer rend;
	// Use this for initialization
	void Start () {
		rend = GetComponent<Renderer>();
		mate = rend.material;
	}
	
	// Update is called once per frame
	void Update (){
		banner = banner + 0.000005f;
		mate.SetTextureOffset ("_MainTex", new Vector2 (banner, 0));
	}
}

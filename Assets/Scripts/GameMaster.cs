using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameMaster : MonoBehaviour {
	public static GameMaster current;
	public GameObject player;
	public Text puntuationText;
	public GameObject deathPanel;
	public Text scoreDeathText;
	private Vector3 startPosition;
	private int puntuation;

	// Use this for initialization
	void Start () {
		GameMaster.current = this;
		this.puntuation = 0;
		this.startPosition = GameObject.FindGameObjectWithTag ("Player").transform.position;
		UpdateScoreText ();
	}
	
	// Update is called once per frame
	void UpdateScoreText () {
		this.puntuationText.text = "Score: " + this.puntuation;
	}
	public void AddScore(int mount){
		this.puntuation += mount;
		UpdateScoreText ();
	}
	public void GameOver(){
		this.deathPanel.SetActive (true);
		this.scoreDeathText.text = "Score: " + this.puntuation;
	}
	public void Reload(){
		Application.LoadLevel(1);
	}
}

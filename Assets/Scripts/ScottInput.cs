using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScottInput : MonoBehaviour {
	public float walkSpeed;
	public float jumpImpulse;
	public Transform groundCheckPoint;
	public LayerMask whatIsGround;
	public LayerMask whatToHit;
    public Image HealthBar;
    public float Health=100;//entre 0 y 100

	private Rigidbody2D body;
	private Vector2 movement;

	private float horInput;
	private float verIput;
	private bool jumpImput;
	private bool weAreInTheGround;
	private bool facingRight;
	private bool pauInput=false;//pau
	private bool yInput;//fight
	private int valor=0;
	private Animator anim;
	private bool enimgdead=false;
	// Use this for initialization
	void Start () {
		this.body = this.GetComponent<Rigidbody2D> ();
		this.movement = new Vector2 ();
		this.weAreInTheGround = false;
		this.anim = this.GetComponent<Animator> ();

	}

	// Update is called once per frame
	void Update () {
        
		this.horInput = Input.GetAxis ("Horizontal");
		this.verIput = Input.GetAxis ("Vertical");
		this.jumpImput = Input.GetKey (KeyCode.Space);
		this.pauInput = Input.GetKey (KeyCode.LeftShift);

		this.anim.SetFloat ("HorzSpeed", Mathf.Abs(horInput));
		//this.anim.SetFloat ("VerticalSpeed", Mathf.Abs(this.body.velocity.y));
		//Pau
		if (pauInput == true) {
			
			valor = 5;
			this.anim.SetInteger("Pau",valor);
			this.anim.SetInteger("Salida",valor);
		}
		//Fight
		if(jumpImput==true){
			valor = 3;
			this.anim.SetInteger ("Fight", valor);
			this.anim.SetInteger("Salida",valor);
		}
		if (valor==5){
			
			//this.anim.SetInteger("Pau",20);


		}
		if(valor==3){
			
			//this.anim.SetInteger ("Fight", 20);
			//this.anim.SetInteger("Salida",20);
		}
		if (valor == 15) {
			this.anim.SetInteger ("Dead", valor);
			this.anim.SetInteger("Salida",valor);
		}
		if (jumpImput || pauInput) {
			
			RaycastHit2D hit = Physics2D.Raycast (this.transform.position,this.transform.right,0.3f,whatToHit);
			RaycastHit2D hitpau = Physics2D.Raycast (this.transform.position,this.transform.right,10,whatToHit);


			//Verificamos si el colliderde hit toco algo
			if (hit.collider) {
				//Verificamos si toco algun enemigo
				if(hit.collider.gameObject.CompareTag("Enemig")){
					if (jumpImput) {
						hit.collider.gameObject.SendMessage ("Hurt", 10);
					}

				}
			} else {
				//Verificamos si no toco algun enemigo
			}
			//Verificamos si el collider de hitpau toco algo
			if (hitpau.collider) {
				//Verificamos si toco algun enemigo
				if(hitpau.collider.gameObject.CompareTag("Enemig")){
					if (pauInput) {
						hitpau.collider.gameObject.SendMessage ("Hurt", 10);
					}

				}
			}
				
		}

		if (Physics2D.OverlapCircle (this.groundCheckPoint.position, 0.02f, this.whatIsGround)) {
			this.weAreInTheGround = true;
		} else {
			this.weAreInTheGround = false;
		}
		if (this.horInput > 0 || this.horInput < 0) {
			this.anim.SetInteger ("Fight", 20);
			this.anim.SetInteger ("Pau", 20);
			this.anim.SetInteger("Salida",20);
		}
		if((this.horInput>0)&&(facingRight)){
			this.Flip ();
			this.facingRight = false;

		}else if((this.horInput<0)&&(!facingRight)){
			this.Flip();
			this.facingRight =true;

		}
        CheckHealth();

    }
	void FixedUpdate(){
		this.movement = this.body.velocity;

		this.movement.x = horInput * walkSpeed;
		this.movement.y = verIput * walkSpeed;
		/*Salto
		 * if(this.jumpImput==true && this.weAreInTheGround==true){

			this.movement.y = jumpImpulse;	

		}*/
		this.body.velocity = this.movement;
	}
	void Flip(){
		//Vector3 scale = this.transform.localScale;
		//scale.x *= (-1);
		//this.transform.localScale = scale;
		this.transform.Rotate (Vector3.up, 180);
	}

    void CheckHealth()
    {
		if(this.Health>=0.0f){
			HealthBar.rectTransform.localScale = new Vector3(Health / 100, HealthBar.rectTransform.localScale.y, HealthBar.rectTransform.localScale.z);	
		}
        

    }

    void OnCollisionEnter2D(Collision2D other)
    {
        //Debug.Log("entro a la colision");
        if (other.collider.CompareTag("Enemig"))
        {
            this.Health -= 10.0f;
            //Debug.Log("le resto vida");
			if (this.Health == 0) {
				valor = 15;
				//El pPlayer esta muerto
				GameMaster.current.GameOver();
			}
        }
    }
}

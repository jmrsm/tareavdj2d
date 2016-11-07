using UnityEngine;
using System.Collections;

public class FanPeniaInput : MonoBehaviour {
		public float walkSpeed;
		public float jumpImpulse;

		public Transform groundCheckPoint;
		public LayerMask whatIsGround;
		private Transform Target;
		private Rigidbody2D body;
		private Vector2 movement;

		private float horInput;
		private float verIput;
		private bool jumpImput;
		private bool weAreInTheGround;
		private bool facingRight;
		private Animator anim;
		private bool dead=false;
		// Use this for initialization
		void Start () {
			this.body = this.GetComponent<Rigidbody2D> ();
			this.movement = new Vector2 ();
			this.weAreInTheGround = false;
			this.anim = this.GetComponent<Animator> ();
			//this.facingRight = true;
			this.Target= GameObject.FindGameObjectWithTag("Player").transform;
		}

		// Update is called once per frame
		void Update () {
			this.horInput = Input.GetAxis ("Horizontal");
			this.verIput = Input.GetAxis ("Vertical");
			if(this.transform.position.x < this.Target.position.x){
				this.horInput = 1;	
				
			}else if(this.transform.position.x > this.Target.position.x){
			 	this.horInput = -1;	
				
			}
			if (this.transform.position.y < this.Target.position.y) {
				this.verIput = 1;	
			}else if (this.transform.position.y > this.Target.position.y) {
				this.verIput = -1;	
			}
			if((this.horInput>0)&&(facingRight)){
				this.Flip ();
				this.facingRight = false;

			}else if((this.horInput<0)&&(!facingRight)){
				this.Flip();
				this.facingRight =true;

			}
			//this.anim.SetFloat ("HorzSpeed", Mathf.Abs(horInput));
			//this.anim.SetFloat ("VerticalSpeed", Mathf.Abs(this.body.velocity.y));
			if (Physics2D.OverlapCircle (this.groundCheckPoint.position, 0.02f, this.whatIsGround)) {
				this.weAreInTheGround = true;
			} else {
				this.weAreInTheGround = false;
			}
			
			if (this.dead == true) {
			this.anim.SetInteger("Dead",15);
			}
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
			Vector3 scale = this.transform.localScale;
			scale.x *= (-1);
			this.transform.localScale = scale;
		}
		public void Dead(bool dead){
			this.dead = dead;
		}
		void OneGetKill(){
			GameMaster.current.AddScore (100);
		}
	}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemigoJefe : Enemigo {

	public GameObject bala;
	public float temporizador = 4;
	public GameObject arma;
	public Animation anim;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		temporizador -= Time.deltaTime;
		if (temporizador <= 0) {
			Disparar ();
		}
	}

	public void Disparar()
	{
		
			anim.CrossFade ("attack02",0);
			GameObject balala;
			balala = Instantiate(bala, arma.transform.position, Quaternion.Euler(0, 0, 0));
			balala.GetComponent<BalaJefe>().poder = ATK;
			balala.GetComponent<BalaJefe> ().objetivo = GameObject.FindGameObjectWithTag ("Player");
			temporizador = Random.Range (7, 13);
		}

	public void Daño(){
		anim.CrossFade ("damage",0);
	
	}

	}








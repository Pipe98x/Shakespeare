using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemigoJefe : Enemigo {

	public GameObject bala;
	public float temporizador = 4;
	public GameObject arma;
	public Animation anim;
    private Vector3 heading;
    private float distanciajugador;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		temporizador -= Time.deltaTime;
        heading = GameObject.FindGameObjectWithTag("Player").gameObject.transform.position - transform.position;
        distanciajugador = heading.magnitude;
        vidita.GetComponent<TextMesh>().text = vida.ToString();

        if(vida <=0)
        {
            Morir();
        }

        if (temporizador <= 0 && distanciajugador <= 30) {
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

	public void Daño(float tiempo){
		anim.CrossFade ("damage",tiempo);
	
	}

    public override void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Espada")
        {
            vida -= GameObject.FindGameObjectWithTag("Player").gameObject.GetComponent<Jugador>().ATK;
            Daño(0.8f);
        }
    }

}








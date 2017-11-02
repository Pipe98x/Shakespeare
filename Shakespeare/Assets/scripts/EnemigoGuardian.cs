using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemigoGuardian : Enemigo {

    private Vector3 direccion;
    private Vector3 heading;
    private float distancia;
    public Vector3 apuntar;
    public GameObject objetivo;
    public GameObject bala;
    private bool disparando = false;
    public float temporizador = 4;
    public GameObject arma;

	// Use this for initialization
	void Start () {

        direccion = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
        direccion += new Vector3(0, 1, 0);
        Moverse();

        heading = objetivo.transform.position - transform.position;
        distancia = heading.magnitude;
        apuntar = heading / distancia;
        vidita.GetComponent<TextMesh>().text = vida.ToString();

        if (vida <= 0) {
            DarLoot();
            Morir ();
		}

        if (distancia <= 10)
        {
            Disparar();
            
        }

        if (disparando)
        {
            temporizador -= Time.deltaTime;
        }

        if (temporizador <= 0)
        {
            disparando = false;
            temporizador = 4;
        }
    }

    public override void Moverse()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * velocidad);
        transform.Rotate(new Vector3(0, 20, 0) * Time.deltaTime);
    }

    public void Disparar()
    {
        if (!disparando)
        {
            GameObject balala;
            balala = Instantiate(bala, arma.transform.position, Quaternion.Euler(0, 0, 0));
            balala.GetComponent<BalaPersigue>().direc = apuntar;
            balala.GetComponent<BalaPersigue>().poder = ATK;
            disparando = true;
        }

    }

	public void OnTriggerEnter(Collider trigger){

   
        if (trigger.gameObject.name == "Jefe"){

			AumentoVida ();
	}
        if (trigger.gameObject.tag == "Espada")
        {
            vida -= GameObject.FindGameObjectWithTag("Player").gameObject.GetComponent<Jugador>().ATK;
        }
    }
	public void AumentoVida(){
		vida += 3;
		Invoke ("AumentoVida", 10);
	}
}


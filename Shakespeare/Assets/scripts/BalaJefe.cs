using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalaJefe : Bala {

	public GameObject objetivo;
	private Vector3 heading;
	private Vector3 direccion;
	private float distancias;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		heading = objetivo.gameObject.transform.position - transform.position;
		distancias = heading.magnitude;
		direccion = heading / distancia;
		Moverse ();
        if (distancia <= 0)
        {
            Destroy(gameObject);
        }
		
	}

	public override void Moverse ()
	{
		transform.Translate (direccion * Time.deltaTime * velocidad);
			
	}

    public void Atraer()
    {
        objetivo.GetComponent<Jugador>().Atraccion();
        Debug.Log("atrajo");
    }

	public override void OnCollisionEnter (Collision collision)
	{
		if (collision.gameObject.tag == "Player") {
            particulas.GetComponent<Fireball>().Explosion();
			Invoke ("Atraer", 0.4f);
			collision.gameObject.GetComponent<Jugador> ().vida -= poder;
            Invoke("Destruir", 0.4f);
		
		}
		if (!(collision.gameObject.tag == "Enemigo")) {
			

		}
	}
}

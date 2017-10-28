using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemigoPersigue : Enemigo {

    private Vector3 heading;
    private float distancia;
    private Vector3 direccion;
    public GameObject objetivo;
    private int lado = 1;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        heading = objetivo.transform.position - transform.position;
        distancia = heading.magnitude;
        direccion = heading / distancia;

        if (distancia <= 6)
        {
            Moverse();
        } else
        {
            transform.Translate(Vector3.left * velocidad * lado * Time.deltaTime);
        }

        if (vida <= 0)
        {
            Destroy(gameObject);
        }

	}

    public override void Moverse()
    {
        transform.Translate(direccion * Time.deltaTime * velocidad);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Pared")
        {
            lado *= -1;
        }

       
    }
}

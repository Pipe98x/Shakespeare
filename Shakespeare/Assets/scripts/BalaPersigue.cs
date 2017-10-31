using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalaPersigue : Bala {
    public Vector3 direc;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Moverse();
		distancia -= Time.deltaTime;
		Moverse();

		if (distancia <= 0) {
			Destruir ();
		}

	}
    public override void OnCollisionEnter(Collision collision)
    {
        
        if (collision.gameObject.tag == "Player")
        {
			collision.gameObject.GetComponent<Jugador>().RecibirDano(poder);
            Destroy(gameObject);
        }
    }

    public override void Moverse()
    {
        transform.Translate(direc * Time.deltaTime * velocidad);
    }
}

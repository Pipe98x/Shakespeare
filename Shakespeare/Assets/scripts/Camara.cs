using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camara : MonoBehaviour {

    public GameObject jugador;
    private Vector3 posicion;
    private Vector3 nuevaposicion;
    private float posicionX;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        posicionX = jugador.transform.position.x;

        if (posicionX < -2)
        {
            posicionX = -2;
        }

        if (posicionX > 2)
        {
            posicionX = 2;
        }
        posicion = transform.position;

        nuevaposicion = new Vector3(posicionX, transform.position.y, (jugador.transform.position.z - 5.3f));
        transform.position = nuevaposicion;
	}
}

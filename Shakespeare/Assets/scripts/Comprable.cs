using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Comprable : MonoBehaviour {

	public int precio;
	public int index;
	public GameObject jugador;


	// Use this for initialization
 void Start () {
		
	}
	
	// Update is called once per frame
 void Update () {

		jugador = GameObject.FindGameObjectWithTag ("Player").gameObject;
	}

    public void compraItem()
    {

        if (jugador)
        {

            jugador.gameObject.GetComponent<Jugador>().comprar(precio, index);
        }
        else
        {
            Debug.Log("no hay");
        }
    }
		
}

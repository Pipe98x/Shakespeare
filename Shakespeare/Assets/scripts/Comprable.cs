using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Comprable : MonoBehaviour {

	public int precio;		//todos los comprables tienen un precio
	public int index;		// todos los comprables tienen un index
	public GameObject jugador;
	public Text estadis_ataque;	//tienen un valor de ataque
	public Text estadis_defensa;	//un valor de defensa
	public Text estadis_velocidad;	// un valor de velocidad

	// Use this for initialization
 void Start () {
		
	}
	
	// Update is called once per frame
 void Update () {

	}

    public void compraItem()	//esta funcion se llama desde el boton comprar de cada item, esta a su vez llama a la funcion comprar del jugador y le indica el precio y el index del item comprado
    {

        if (jugador)
        {

            jugador.gameObject.GetComponent<Jugador>().comprar(precio, index);	
        }
    }
		
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Equipable : Comprable {

	public int Ataque;	
	public int Defensa;
	public int Velocidad;
    private bool equipado = false;
    private int posicionequipado;



	// Use this for initialization
	void Start () {


	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void MostrarEstadisticas() {	// muestra las variables Ataque, Defensa y Velocidad en los Text definidos
	
		estadis_ataque.text = Ataque.ToString ();
		estadis_defensa.text = Defensa.ToString ();
		estadis_velocidad.text = Velocidad.ToString ();
		
	}

    public void Equipar()
    {
        if (!equipado)
        {
            for (int i = 0; i < 3; i++)
            {
                if (!jugador.GetComponent<Jugador>().ItemsActivos[i])
                {
                    jugador.GetComponent<Jugador>().ATK += Ataque;
                    jugador.GetComponent<Jugador>().defensa += Defensa;
					jugador.GetComponent<Jugador>().velocidad -= (Velocidad/4);
                    equipado = true;
                    jugador.GetComponent<Jugador>().ItemsActivos[i] = this;
                    posicionequipado = i;
                    break;
                }
            }
            
        } else
        {
            jugador.GetComponent<Jugador>().ATK -= Ataque;
            jugador.GetComponent<Jugador>().defensa -= Defensa;
			jugador.GetComponent<Jugador>().velocidad += (Velocidad/10);
            equipado = false;
            
            
        }
    }
}

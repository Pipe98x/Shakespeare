using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Equipable : Comprable {

	public int Ataque;	
	public int Defensa;
	public int Velocidad;



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
}

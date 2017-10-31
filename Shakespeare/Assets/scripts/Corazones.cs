using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Corazones : MonoBehaviour {

	public List<GameObject> corazones = new List<GameObject>();
	private GameObject jugador;
	private int vidas;

	// Use this for initialization
	void Start () {

		jugador = GameObject.FindGameObjectWithTag ("Player");


	}
	
	// Update is called once per frame
	void Update () {

		vidas = jugador.GetComponent<Jugador> ().vida;

		for (int i = 0; i < vidas; i++) {

			corazones [i].gameObject.SetActive(true);
		}

		for (int i = vidas; i < corazones.Count; i++) {
			if (vidas >= 0) {
				corazones [i].gameObject.SetActive (false);
			}
            
		}

			
	}

}

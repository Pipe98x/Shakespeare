using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Generador : MonoBehaviour {
	public GameObject tiendita;
	public GameObject Inventario;
	public GameObject ItemPadre;
	public Comprable[] Objetos;
	private List<Comprable> Activos = new List<Comprable> ();
	private bool consuactivos = false;
	private bool equipactivos = false;
	private bool todoactivos = false;
	private bool tiendactiva = false;
	private bool inventarioactivo = false;
	private Vector3 vectors = new Vector3 (0, 0, 0);
	private List<Comprable> Consumiblesactivos = new List<Comprable>(); 
	private int verificadorConsu = 0;
	private List<Comprable> Equipablesactivos = new List<Comprable>();
	private int verificadorEqui = 0;
	private int verificadorTodos = 0;

	// Use this for initialization
	void Start () {

		GenerarTodos ();
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetKeyDown (KeyCode.I)) {

			if (tiendactiva == false) {
				tiendita.SetActive (true);
				tiendactiva = true;
			} else {
				tiendita.SetActive (false);
				tiendactiva = false;
			}
		
		}

		if (Input.GetKeyDown (KeyCode.E)) {

			if (inventarioactivo == false) {
				Inventario.SetActive (true);
				inventarioactivo = true;
			} else {
				Inventario.SetActive (false);
				inventarioactivo = false;
			}

		}
			
    }

	public void GenerarConsumibles() {
		BorrarTodos ();
		BorrarConsumibles ();
		BorrarEquipalbes ();
		equipactivos = false;
		todoactivos = false;
		if (consuactivos == false) {

			consuactivos = true;
		
			if (verificadorConsu == 0) {
				vectors = new Vector3 (0, 0, 0);

				for (int i = 0; i < Objetos.Length; i++) {
					if (Objetos [i] is Consumible) {

						Comprable consu;
						consu = Instantiate (Objetos [i], ItemPadre.transform.position + vectors, ItemPadre.transform.rotation) as Comprable;
						consu.transform.SetParent (ItemPadre.transform);
						vectors += new Vector3 (100, 0, 0);
						Consumiblesactivos.Add (consu);
						verificadorConsu = 1;
						consu.jugador = GameObject.FindGameObjectWithTag ("Player").gameObject;
					}
				}
	
			} else {
			
				for (int i = 0; i < Consumiblesactivos.Count; i++) {
					Consumiblesactivos [i].gameObject.SetActive(true);
				}
			}
		}
	}

	public void BorrarConsumibles() {

		for (int i = 0; i < Consumiblesactivos.Count; i++) {
			Consumiblesactivos [i].gameObject.SetActive(false);
		}

	
}

	public void BorrarEquipalbes() {

		for (int i = 0; i < Equipablesactivos.Count; i++) {
			Equipablesactivos [i].gameObject.SetActive(false);
		}


	}

	public void BorrarTodos() {

		for (int i = 0; i < Activos.Count; i++) {
			Activos [i].gameObject.SetActive(false);
		}


	}

	public void GenerarEquipables() {
		BorrarTodos ();
		BorrarEquipalbes ();
		BorrarConsumibles ();
		todoactivos = false;
		consuactivos = false;
		if (equipactivos == false) {
			
		equipactivos = true;
		
			if (verificadorEqui == 0) {
				vectors = new Vector3 (0, 0, 0);

				for (int i = 0; i < Objetos.Length; i++) {
					if (Objetos [i] is Equipable) {
						Comprable equi;
						equi = Instantiate (Objetos [i], ItemPadre.transform.position + vectors, transform.rotation) as Comprable;
						equi.transform.SetParent (ItemPadre.transform);
						equi.jugador = GameObject.FindGameObjectWithTag ("Player").gameObject;
				
						if (vectors.x == 300) {	
							vectors = new Vector3 (0, -120, 0);
						} else {
							vectors += new Vector3 (100, 0, 0);

						}
						Equipablesactivos.Add (equi);
						verificadorEqui = 1;
				
				
					}
				}
			} else {
			
				for (int i = 0; i < Equipablesactivos.Count; i++) {
					Equipablesactivos [i].gameObject.SetActive(true);
				}
			}
	}
}
	public void GenerarTodos() {
		
		BorrarEquipalbes ();
		BorrarConsumibles ();
		consuactivos = false;
		equipactivos = false;

		if (todoactivos == false) {

			todoactivos = true;

			if (verificadorTodos == 0) {

				vectors = new Vector3 (0, 0, 0);

				for (int i = 0; i < Objetos.Length; i++) {

					Comprable todo;
					todo = Instantiate (Objetos [i], ItemPadre.transform.position + vectors, transform.rotation) as Comprable;
					todo.transform.SetParent (ItemPadre.transform);
					Activos.Add (todo);
					todo.jugador = GameObject.FindGameObjectWithTag ("Player").gameObject;

					if (vectors.x == 300) {	
						vectors = new Vector3 (0, vectors.y -120, 0);
					} else {
						vectors += new Vector3 (100, 0, 0);

					}
				}
			} else {

				for (int i = 0; i < Activos.Count; i++) {
					Activos [i].gameObject.SetActive(true);
				}

			}
		}

	}

	public void señal(){
	
		Debug.Log ("sobre");
	}
	}



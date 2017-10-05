using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Generador : MonoBehaviour {
	public GameObject tiendita;			// para tener referencia de la tienda y poder prenderla y apagarla
	public GameObject Inventario;		// para tener referencia del inventario y poder prenderlo y apagarlo
	public GameObject ItemPadre;		// este gameobject va a contener los items de la tienda
	public Comprable[] Objetos;			// arreglo con todos los objetos que se pueden comprar
	private List<Comprable> Activos = new List<Comprable> ();		// Lista con los items instanciados en la tienda en la pestaña "todos"
	private bool consuactivos = false;  // Para saber cual lista se está mostrando y evitar que se muestre dos veces
	private bool equipactivos = false;  // Para saber cual lista se está mostrando y evitar que se muestre dos veces
	private bool todoactivos = false;	// Para saber cual lista se está mostrando y evitar que se muestre dos veces
	private bool tiendactiva = false;	// Para saber si la tienda se está mostrando
	private bool inventarioactivo = false; // Para saber si el inventario se está mostrando
	private Vector3 vectors = new Vector3 (0, 0, 0); // para ir modificando la posicion en que se instancia el item
	private List<Comprable> Consumiblesactivos = new List<Comprable>();  // aqui se almecenan los items instanciados por el boton Consumibles
	private int verificadorConsu = 0;	//verifica si ya fueron instanciados
	private List<Comprable> Equipablesactivos = new List<Comprable>();  // aqui se almecenan los items instanciados por el boton equipables
	private int verificadorEqui = 0;
	private int verificadorTodos = 0;

	// Use this for initialization
	void Start () {


	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetKeyDown (KeyCode.I)) {			// si se presiona la tecla I activar o desactivar la tienda

			if (tiendactiva == false) {
				tiendita.SetActive (true);
				tiendactiva = true;
			} else {
				tiendita.SetActive (false);
				tiendactiva = false;
			}
		
		}

		if (Input.GetKeyDown (KeyCode.E)) {			// si se presiona la tecla E activar o desactivar el inventario

			if (inventarioactivo == false) {
				Inventario.SetActive (true);
				inventarioactivo = true;
			} else {
				Inventario.SetActive (false);
				inventarioactivo = false;
			}

		}
			
    }

	public void GenerarConsumibles() {			// instanciará o mostrará los comsumibles en la tienda
		BorrarTodos ();							// oculta los items de la lista "activos"
		BorrarEquipalbes ();					// Oculta los items de la lista "equipables"
		equipactivos = false;					
		todoactivos = false;
		if (consuactivos == false) {			// si consuactivos es falso los muestra, si es verdadero no, para evitar que se puedan generar multiples veces

			consuactivos = true;				// esta activo
		
			if (verificadorConsu == 0) {		// si esta en 0 significa que los consumibles no han sido instanciados nunca
				vectors = new Vector3 (0, 0, 0);

				for (int i = 0; i < Objetos.Length; i++) { //recorre el arreglo de objetos en busca de los consumibles
					if (Objetos [i] is Consumible) {

						Comprable consu;
						consu = Instantiate (Objetos [i], ItemPadre.transform.position + vectors, ItemPadre.transform.rotation) as Comprable; // isntancia el consumible en la poscion del Itempadre 
						consu.transform.SetParent (ItemPadre.transform); //se hace hijo del Itempadre
						vectors += new Vector3 (100, 0, 0);	// se aumenta el vector para que el siguiente instanciado salga a la derecha del anterior
						Consumiblesactivos.Add (consu);		// se agrega el objeto a la lista de consumibles activos	
						verificadorConsu = 1;				// se hace 1 el verificador, o sea que este proceso no se volverá a repetir
						consu.jugador = GameObject.FindGameObjectWithTag ("Player").gameObject; // se define la variable jugador del consumible instanciado
					}
				}
	
			} else {
			
				for (int i = 0; i < Consumiblesactivos.Count; i++) {		// se activan los objetos almacenados en la lista Consumiblesasctivos
					Consumiblesactivos [i].gameObject.SetActive(true);
				}
			}
		}
	}

	public void BorrarConsumibles() {

		for (int i = 0; i < Consumiblesactivos.Count; i++) {
			Consumiblesactivos [i].gameObject.SetActive(false);				// Se desactivan los objetos almacenados en la lista Consumiblesactivos
		}

	
}

	public void BorrarEquipalbes() {

		for (int i = 0; i < Equipablesactivos.Count; i++) {
			Equipablesactivos [i].gameObject.SetActive(false);			// se desactivan los objetos almacenados en la lista equipables activos
		}


	}

	public void BorrarTodos() {

		for (int i = 0; i < Activos.Count; i++) {
			Activos [i].gameObject.SetActive(false);					// se desactivan los objetos almacenados en la lista activos
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
						equi.estadis_ataque = GameObject.Find ("Ataque").GetComponent<Text>();	//se da un valor a la variable de Texto
						equi.estadis_defensa = GameObject.Find ("Defensa").GetComponent<Text>();
						equi.estadis_velocidad = GameObject.Find ("Velocidad").GetComponent<Text>();
				
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

					if (todo is Equipable) {

						todo.estadis_ataque = GameObject.Find ("Ataque").GetComponent<Text>();
						todo.estadis_defensa = GameObject.Find ("Defensa").GetComponent<Text>();
						todo.estadis_velocidad = GameObject.Find ("Velocidad").GetComponent<Text>();
					}
				}
			} else {

				for (int i = 0; i < Activos.Count; i++) {
					Activos [i].gameObject.SetActive(true);
				}

			}
		}

	}
	}



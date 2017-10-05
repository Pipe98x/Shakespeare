using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Jugador : MonoBehaviour {

	public int vida = 40;
	public int monedas;
	public Text monedastienda;          // Para mostrar las monedas en la tienda
	public Equipable[] equipables;		// Arreglo de equipables para sacar uno y meterlo al inventario cuando este sea comprado
	public GameObject inventario;		// objeto inventario, sirve como referencia 
	private List<Equipable> inventarioItems = new List<Equipable> (); // lista de equipables, aqui se guardaran los objetos que estén en el inventario del jugador
	private int pocionesvida;		// cantidad de pociones de vida
	private int pocionesfuerza;		// cantidad de pociones de fuerza
	private int pocionesvelocidad;	// cantidad de pociones de velocidad
    public Text PocionesVida;			//texto que muestra la cantidad de las pociones en el UI
	public Text PocionesFuerza;			//texto que muestra la cantidad de las pociones en el UI
	public Text PocionesVelocidad;		//texto que muestra la cantidad de las pociones en el UI
	private Vector3 vectors = new Vector3 (0, 0, 0);	// vector usado para organizar los objetos dentro del inventario

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {


		if (vida > 40) {
			vida = 40;			// para que la vida maxima sea 40
		}

		monedastienda.text = monedas.ToString();   // que se muestren las monedas en la tienda
		PocionesVida.text = pocionesvida.ToString();	// que se muestren la cantidad de pociones (int)
        PocionesVelocidad.text = pocionesvelocidad.ToString();
        PocionesFuerza.text = pocionesfuerza.ToString();

		if (Input.GetKeyDown (KeyCode.Alpha1)) {
			
			if (pocionesvida > 0) {
			
				vida += 8;
				pocionesvida -= 1;		// al presionar la tecla "1" si hay pociones de vida aumenta esta en 8 unidades

			}
		}
	}

	public void comprar (int precio, int index) {		//funcion para comprar, recibe el precio del item y un index que definirá cual objeto compró
		if (monedas >= precio) {	// se comprueba que el jugador tenga el dinero suficiente para comprar el item

			monedas -= precio;			// se resta el precio del item de las monedas del jugador


			if (index < 6) {			// toma el index e instacia el item correspondiente como un equipable dentro del inventario
				Equipable equip;
				equip = Instantiate (equipables [index], (inventario.transform.position + vectors), transform.rotation) as Equipable;
				equip.transform.SetParent (inventario.transform);
				inventarioItems.Add (equip);
				if (vectors.x >= 210) {	
					vectors = new Vector3 (0, vectors.y-70, 0);
				} else {
					vectors += new Vector3 (70, 0, 0);

				}
			}



			if (index == 6) {
				pocionesvida += 1;		//6 es el index para las pociones de vida, las pociones no se instancian en el inventario, aparecen en la UI
			}

			if (index == 7) {
				pocionesfuerza += 1;	// agregar una pocion de fueza
			}

			if (index == 8) {
				pocionesvelocidad += 1;	// agregar una pocion de velocidad
			}


		} else
        {
            Debug.Log("No alcanza");	// debug temporal si no tiene monedas suficientes
        }
	}
		
}

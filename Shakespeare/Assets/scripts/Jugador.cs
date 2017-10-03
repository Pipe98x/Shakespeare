using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Jugador : MonoBehaviour {

	public int vida = 40;
	public int monedas;
	public Text monedastienda;
	public Equipable[] equipables;
	public GameObject inventario;
	private List<Equipable> inventarioItems = new List<Equipable> ();
	private int pocionesvida;
	private int pocionesfuerza;
	private int pocionesvelocidad;
    public Text PocionesVida;
    public Text PocionesFuerza;
    public Text PocionesVelocidad;
	private Vector3 vectors = new Vector3 (0, 0, 0);

    // Use this for initialization
    void Start () {
		monedas = 250;
	}
	
	// Update is called once per frame
	void Update () {

		if (vida > 40) {
			vida = 40;
		}
		monedastienda.text = monedas.ToString();
        PocionesVida.text = pocionesvida.ToString();
        PocionesVelocidad.text = pocionesvelocidad.ToString();
        PocionesFuerza.text = pocionesfuerza.ToString();

		if (Input.GetKeyDown (KeyCode.Alpha1)) {
			
			if (pocionesvida > 0) {
			
				vida += 8;
				pocionesvida -= 1;

			}
		}
	}

	public void comprar (int precio, int index) {
		if (monedas >= precio) {

			monedas -= precio;

			if (index < 6) {
				Equipable equip;
				equip = Instantiate (equipables [index], (inventario.transform.position + vectors), transform.rotation) as Equipable;
				equip.transform.SetParent (inventario.transform);
				inventarioItems.Add (equip);
				if (vectors.x == 120) {	
					vectors = new Vector3 (0, -50, 0);
				} else {
					vectors += new Vector3 (70, 0, 0);

				}
			}

			if (index == 6) {
				pocionesvida += 1;
			}

			if (index == 7) {
				pocionesfuerza += 1;
			}

			if (index == 8) {
				pocionesvelocidad += 1;
			}


		} else
        {
            Debug.Log("No alcanza");
        }
	}
		
}

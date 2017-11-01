using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Jugador : Personaje {

    
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
    private int modo = 1;
    public GameObject bala;
    public Collider ataque;
    private bool atacando = false;
    public bool comprarActivo = false;
    public GameObject generador;
    public Equipable[] ItemsActivos;
	private Vector3 heading;
	private Vector3 direccionjefe;
	private float distanciajefe;
    public Animation anim;
    public GameObject disparador;
    public Text ATK_t;
    public Text DEF_t;
    public Text VEL_t;
    private bool suelo;
    private bool pocionfuerza = false;
    private bool pocionvelocidadd = false;

    // Use this for initialization
    void Start () {
        
    }

    // Update is called once per frame
    void Update()
    {
		heading = GameObject.Find ("Jefe").transform.position - transform.position;
		distanciajefe = heading.magnitude;
		direccionjefe = heading / distanciajefe;

        if (vida > 40)
        {
            vida = 40;          // para que la vida maxima sea 40
        }

        if (vida < 0)
        {
            vida = 0;
            SceneManager.LoadScene("gameover");
        }

        monedastienda.text = monedas.ToString();   // que se muestren las monedas en la tienda
        PocionesVida.text = pocionesvida.ToString();	// que se muestren la cantidad de pociones (int)
        PocionesVelocidad.text = pocionesvelocidad.ToString();
        PocionesFuerza.text = pocionesfuerza.ToString();
        ATK_t.text = ATK.ToString();
        DEF_t.text = defensa.ToString();
        VEL_t.text = ((velocidad - 2.5)*-10).ToString("F0");
        


        if (Input.GetKeyDown(KeyCode.Alpha1))
        {

            if (pocionesvida > 0)
            {

                vida += 8;
                pocionesvida -= 1;      // al presionar la tecla "1" si hay pociones de vida aumenta esta en 8 unidades

            }
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {

            if (pocionesfuerza > 0)
            {
                if (!pocionfuerza)
                {
                    ATK += 3;
                    pocionesfuerza -= 1;      // al presionar la tecla "1" si hay pociones de vida aumenta esta en 8 unidades
                    Invoke("FueraFuerza", 10f);
                }

            }
        }

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {

            if (pocionesfuerza > 0)
            {
                if (!pocionvelocidadd)
                {
                    velocidad -= 0.5f;
                    pocionesvelocidad -= 1;      // al presionar la tecla "1" si hay pociones de vida aumenta esta en 8 unidades
                    Invoke("Fueravelocidad", 10f);
                }

            }
        }

        /// movimiento 
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector3.back * 3 * Time.deltaTime);
            if (modo == 1)
            {
                anim.CrossFade("IzquierdaPistola", 0);
            }
            
        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector3.forward * 3 * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector3.left* 5 * Time.deltaTime);
            if (modo == 1 && !atacando)
            {
                anim.CrossFade("WalkingArma", 0);
            }else if (!atacando)
            {
                anim.CrossFade("WalkingShakespeare", 0);
            }

        }

        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(Vector3.right * 2 * Time.deltaTime);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if(suelo)
            saltar(alturasalto);

        }

        if (Input.GetKeyDown(KeyCode.C))
        {
            modo *= -1;
            anim.CrossFade("CambiarArma", 0);

        }


        if (Input.GetMouseButtonDown(0))
        {
            if (modo == 1)
            {
                if (!generador.GetComponent<Generador>().tiendactiva && !generador.GetComponent<Generador>().inventarioactivo)
                {
                    if (!atacando)
                    {
                        Disparar();
                        anim.CrossFade("DisparoShakespeare", 0);
                        atacando = true;
                        StartCoroutine(espera());
                    }
                }
            }

            if (modo == -1)
            {
                if (!atacando)
                {
                    
                    atacando = true;
                    StartCoroutine(espera());
                    StartCoroutine(espada());
                    StartCoroutine(espadas());
                    anim.CrossFade("EspadaShakespeare", 0);
                }
            }

        }
    }

    private void FueraFuerza()
    {
        ATK -= 3;
        pocionfuerza = false;
    }

    private void FueraVelocidad()
    {
        velocidad += 0.5f;
        pocionfuerza = false;
        pocionvelocidadd = true;
    }

    public void Disparar ()
    {
        GameObject newbala;
        newbala = Instantiate(bala, disparador.transform.position, disparador.transform.rotation);
		newbala.GetComponent<Bala>().poder = ATK;
        StartCoroutine(espera());
    }

	public void comprar (int precio, int index) {		//funcion para comprar, recibe el precio del item y un index que definirá cual objeto compró
		if (monedas >= precio) {	// se comprueba que el jugador tenga el dinero suficiente para comprar el item

			monedas -= precio;			// se resta el precio del item de las monedas del jugador


			if (index < 6) {			// toma el index e instacia el item correspondiente como un equipable dentro del inventario
				Equipable equip;
				equip = Instantiate (equipables [index], (inventario.transform.position + vectors), Quaternion.Euler(0,0,0)) as Equipable;
				equip.transform.SetParent (inventario.transform);
				inventarioItems.Add (equip);
                equip.jugador = GameObject.FindGameObjectWithTag("Player").gameObject;
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

	public void RecibirDano(int daño) {
		if (defensa < daño) {
			vida -= (daño - defensa);
		}
	}

	public void Atraccion() {
		rig.AddForce(new Vector3 (direccionjefe.x,0,direccionjefe.z) * 15, ForceMode.Impulse);
	}

    IEnumerator espera()
    {
		yield return new WaitForSeconds(velocidad);
        atacando = false;
    }

    IEnumerator espada()
    {
        yield return new WaitForSeconds(velocidad);
        ataque.enabled = false;
        
    }

    IEnumerator espadas()
    {
        yield return new WaitForSeconds(0.6f);
        ataque.enabled = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Tienda")
        {
            comprarActivo = true;
        }
			
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Tienda")
        {
            comprarActivo = false;
        }


    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Finish")
        {
            suelo = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Finish")
        {
            suelo = false;
        }
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bala: MonoBehaviour {

    public int poder;
    public float velocidad;
	public float distancia;
    public GameObject particulas;
    

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
		distancia -= Time.deltaTime;
        Moverse();

		if (distancia <= 0) {
			Destruir ();
		}
    }

    public virtual void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemigo")
        {
            collision.gameObject.GetComponent<Enemigo>().vida -= poder;
            Destroy(gameObject);

        }

		if (collision.gameObject.name == "Jefe")
		{
			collision.gameObject.GetComponent<EnemigoJefe>().Daño(0);

		}
    }

    public virtual void Moverse()
    {
        transform.Translate(Vector3.forward * velocidad * Time.deltaTime);
    }

	protected void Destruir() {
		Destroy (gameObject);
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bala : MonoBehaviour {

    public int poder;
    public float velocidad;
    

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        Moverse();
    }

    public virtual void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemigo")
        {
            collision.gameObject.GetComponent<Enemigo>().vida -= poder;
            Destroy(gameObject);

        }
    }

    public virtual void Moverse()
    {
        transform.Translate(Vector3.forward * velocidad * Time.deltaTime);
    }
}

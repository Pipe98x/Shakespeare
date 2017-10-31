using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class Enemigo : Personaje {

	public GameObject[] loot;
    private bool loots = false;
    public GameObject vidita;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
        
	}

    public virtual void Moverse()
    {
    }

    public void DarLoot()
    {
        if (!loots)
        {
            Instantiate(loot[Random.Range(0, 10)], transform.position, transform.rotation);
            loots = true;
        }
    }

    public virtual void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Espada")
        {
            vida -= GameObject.FindGameObjectWithTag("Player").gameObject.GetComponent<Jugador>().ATK;
         }
    }


}

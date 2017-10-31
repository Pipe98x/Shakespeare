using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemigo : Personaje {

	public GameObject[] loot;
    private bool loots = false;

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


}

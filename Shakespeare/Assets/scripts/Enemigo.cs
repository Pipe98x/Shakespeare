using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemigo : Personaje {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
        if (vida <= 0)
        {
            morir();
        }
	}

    public virtual void Moverse()
    {
    }


}

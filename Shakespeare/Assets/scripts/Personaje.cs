using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Personaje : MonoBehaviour {
	public int vida;
	public float velocidad;
	public int ATK;
	public int defensa;
    public Rigidbody rig;
    public float alturasalto;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void morir() {

	}

    public void saltar(float fuerza)
    {
        rig.AddForce(new Vector3(0, fuerza, 0), ForceMode.Impulse);
    }

	

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Apuntar : MonoBehaviour {

    public GameObject padre;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        transform.LookAt (padre.GetComponent<EnemigoGuardian>().apuntar);
	}
}

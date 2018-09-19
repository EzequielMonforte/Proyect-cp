using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BalaEnem1 : balaControl {
    
	// Use this for initialization
	void Start () {
        Movimientosbala(-1);
	}
	
	// Update is called once per frame
	void Update () {
        if (this.transform.position.y > 10.5)
        {
            Destroy(gameObject);
        }
    }
}

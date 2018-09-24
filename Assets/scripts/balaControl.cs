using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class balaControl : MonoBehaviour {
    public int cantidadBalas = 20;
    public float speed = 1;
    Animator animador;
	public GameObject balamuerte;
	public GameObject balamuerte1;
	public GameObject balamuerte2;
	public GameObject balamuerte3;
	// Use this for initialization
	void Start () {
        Movimientosbala(speed);
        animador=GetComponent<Animator>();
	}

    public void Movimientosbala(float speed)
    {
        GetComponent<Rigidbody2D>().velocity = new Vector3(0, speed, 0);
    }

    // Update is called once per frame
    void Update () {
		if(this.transform.position.y> 10.5)
        {
            Destroy(gameObject);
        }
		
    }
    void OnTriggerEnter2D(Collider2D otro)
    {
		
		if (otro.gameObject.tag == "Enem1"|| otro.gameObject.tag == "Enem2" || otro.gameObject.tag== "Piedra")
        {
			Destroy(gameObject, 0.085f);
			Movimientosbala(-1);
			recibirEstado("Explota");
			

		}
	}

    void recibirEstado(string state)
    {
        if (state != null)
        {
            animador.Play(state);
        }
    }

}

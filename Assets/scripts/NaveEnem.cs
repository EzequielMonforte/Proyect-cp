﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class NaveEnem : MonoBehaviour {

	public Animator animador;
    float velocidad=-4.2f;
    GameObject BalaEnem;
    public float vida;
	public AudioSource sonidos;
	
	
	
    


	// Use this for initialization
	void Start () {
        
        animador= GetComponent<Animator>();
		//Establecer velocidades naves y objetos que aparecen
		if (gameObject.tag == "Enem1")
		{
			vida = 5;
			CaracteristicasNave(-2, -6);

		}
		if (gameObject.tag == "Enem2")
		{
			CaracteristicasNave(-5, -7.2f);

		}
		if (gameObject.tag == "RecargaBalas")
		{
			velocidad = -6.1f; 
		}
		if (gameObject.tag == "Piedra")
		{
			velocidad = -3.85f;
		}



    }

    private void CaracteristicasNave(float ranMin,float ranMax)
    {
        velocidad = UnityEngine.Random.Range(ranMin, ranMax);
        

    }

    // Update is called once per frame
    void Update () {
	
		if (transform.position.y < -11)
        {
            Destroy(gameObject);
            
            
        }//movimientos nave
        this.transform.position += new Vector3(0, velocidad * Time.deltaTime, 0); 
		
	}

    void OnTriggerEnter2D(Collider2D otro)
    {
        if(vida<= 1&& otro.gameObject.tag == "Disparo" && vida >= 1)
        {


			sonidos.Play();
			Destroy(gameObject, 0.25f);





			//puntos que da cada nave destruida por parametro

			if (tag == "Enem1")
				BaseDatos.scoreActual += 50;
			if (tag == "Enem2")
				BaseDatos.scoreActual += 10;



		}

        if (otro.gameObject.tag == "Disparo" && vida >=1)
        {
            //Debug.Log("golpeo");
          
            recibirEstado("enem1Golpe");
           
            vida--;
            
        }

		if (otro.gameObject.tag == "perdervida" && gameObject.tag != "RecargaBalas" && gameObject.tag!= "Piedra" && gameObject.tag != "Vida") {
			GameControl.restarVida();
			
			Debug.Log(GameControl.vida);
		}

		if (otro.gameObject.tag == "Jugador" && gameObject.tag == "RecargaBalas")
		{
			HudJuego.cantidadBalas += 15;
			sonidos.Play();
			Destroy(gameObject, 0.23f);
		}
		if (otro.gameObject.tag == "Jugador" && gameObject.tag == "Piedra")
		{
			GameControl.restarVida();
			sonidos.Play();
		}
		if (otro.gameObject.tag == "Jugador" && gameObject.tag == "Vida")
		{
			if (GameControl.aumentarVida())
			{
				sonidos.Play();
				Destroy(gameObject, 0.3f);
			}
		}
		

	}



	void recibirEstado(string state)
    {
		
        if(state!= null)
        {
            animador.Play(state);
        }
    }
	public void destruir()
	{
		DestroyImmediate(this);
	}
}

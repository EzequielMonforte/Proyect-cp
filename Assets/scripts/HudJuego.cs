using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HudJuego :MonoBehaviour{
	public Text puntos;
	public Text balas;
	public GameObject panel;
	public Animator animador;
	public AudioSource sonido;

	public static int cantidadBalas;
	
	// Use this for initialization
	void Start () {
		animador = GetComponent<Animator>();
		puntos.text = "0";
		cantidadBalas = 50;
		
		
	}
	
	// Update is called once per frame
	void Update () {
		puntos.text = BaseDatos.scoreActual.ToString();
		balas.text = cantidadBalas.ToString();
		if (GameControl.vida == 3)
		{
			
			recibirEstado("Vida3");
		}
		if (GameControl.vida == 2)
		{
			
			recibirEstado("Vida2");
		}
		if (GameControl.vida == 1)
		{
			
			recibirEstado("Vida1");
		}
	}

	public void recibirEstado(string state)
	{
		if (state != null)
		{
			
			animador.Play(state);
		}
	}



}

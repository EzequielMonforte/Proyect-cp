using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HudJuego :MonoBehaviour{
	public Text puntos;
	public Text balas;
	public static int cantidadBalas;
	// Use this for initialization
	void Start () {
		puntos.text = "0";
		cantidadBalas = 50;
	}
	
	// Update is called once per frame
	void Update () {
		puntos.text = BaseDatos.scoreActual.ToString();
		balas.text = cantidadBalas.ToString();
	}

	

}

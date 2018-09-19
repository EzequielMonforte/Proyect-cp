using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UsuarioMostrarScores : MonoBehaviour {

	public Text nombre;
	public Text ultscore;
	public Text maxscore;
	
	// Use this for initialization
	void Start () {
		
	}
	 void Update()
	{
		nombre.text = BaseDatos.usuario;
		maxscore.text = "Max Punt: " + BaseDatos.maxscore;

		ultscore.text = "Ultima Puntuacion: " + BaseDatos.ultscore;
	}

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Final : MonoBehaviour {

	public Button remake;
	public Button logout;
	public Text usuario;
	public Text score;
	// Use this for initialization
	void Start()
	{
		usuario.text = BaseDatos.usuario;
		
	}


	// Update is called once per frame
	void Update () {
		
		if (BaseDatos.scoreActual > int.Parse(BaseDatos.maxscore)) {
			score.text = (BaseDatos.scoreActual.ToString()) + " Nuevo Record!!";
				}
		else score.text = BaseDatos.scoreActual.ToString();
	}

	public void salir()
	{
		
		
		SceneManager.LoadScene(0);
		BaseDatos.Salir();

	}
}

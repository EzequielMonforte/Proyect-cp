using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour {
	public GameObject nombre;
	public GameObject puntuacion;

	public void SetScore(string Usuario, string Puntuacion)
	{
		nombre.GetComponent<Text>().text = Usuario;
		puntuacion.GetComponent<Text>().text = Puntuacion;
	}
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}



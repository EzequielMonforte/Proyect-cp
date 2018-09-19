using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class Menu : MonoBehaviour {

	public InputField usuario;
	public InputField contrasena;
	public Button log;
	public Text mensajes;
	string[] datoUsuario;
	public void callLogin()
	{
		if (usuario.text == "debug")
		{
			SceneManager.LoadScene(1);
		}
		else
			StartCoroutine(Login());
		
	}

	 IEnumerator Login()
	{
		WWWForm form = new WWWForm();
		form.AddField("usuario", usuario.text);
		form.AddField("contrasena", contrasena.text);
		WWW www= new WWW("http://spacefighter.sytes.net/www/login.php", form);
		yield return www;
		if (www.text[0] == '1')
		{
			mensajes.text = "Error de conexion";
		}
		if (www.text[0] == '2')
		{
			mensajes.text = "No existe el usuario. Registrese";
		}
		if (www.text[0] == '3')
		{
			mensajes.text = "Contraseña incorrecta";
		}
		if (www.text[0] == '0')
		{
			
			datoUsuario = www.text.Split(';');
			BaseDatos.scoreActual = 0;
			BaseDatos.usuario = usuario.text;
			BaseDatos.ultscore = datoUsuario[1];
			BaseDatos.maxscore = datoUsuario[2];



			ComenzarJuego();
		}

	}

	public void ComenzarJuego()
	{
		SceneManager.LoadScene(1);
	}
}

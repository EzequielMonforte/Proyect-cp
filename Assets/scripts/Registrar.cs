using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Registrar : MonoBehaviour {

	public InputField ingresoUsuario;
	public InputField ingresoContrasena;
	public InputField ingresoMail;


	public Button registro;
	public Text mensajes;

	public bool CheckMail() {
		if (!(ingresoMail.text.Contains("@") && ingresoMail.text.Contains(".com"))) {
			return false;
		}
		return true;
	}
	public void llamarRegistro() {
		if (!CheckMail()) {
			mensajes.text = "ingrese un mail valido";
			return;
		}else
		StartCoroutine(Registro());
	}

		IEnumerator Registro()
		{
		WWWForm form = new WWWForm();
		form.AddField("usuario", ingresoUsuario.text);
		form.AddField("contrasena", ingresoContrasena.text);
		form.AddField("mail", ingresoMail.text);
		WWW www = new WWW("http://spacefighter.sytes.net/www/registro.php", form);
		yield return www;
		if (www.text[0] == '0')
		{
			mensajes.text = "Usuario registrado";
			
		}
		if (www.text[0] == '1')
		{
			mensajes.text = "No se pudo conectar";

		}
		if (www.text[0] == '2')
		{
			mensajes.text = "Ingrese una contraseña!!";
		}
		if (www.text[0] == '3')
		{
			mensajes.text = "Ya existe ese usuario";
		}
		if (www.text[0] == '4')
		{
			mensajes.text = "Ingrese un mail!";
		}
		if (www.text[0] == '5')
		{
			mensajes.text = "El mail ya existe";
		}

		
	}

	
}

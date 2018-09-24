using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VerScores : MonoBehaviour {

	private string UrlPuntaciones = "spacefighter.sytes.net/www/verscores.php";
	private List<FilaScore> rankingJugadores = new List<FilaScore>();
	private string[] currentArray = null;
	public Transform tfPanelCarga;
	public GameObject panelPre;
	public Text mensajes;

	private void Start()
	{
		StartCoroutine(ObtenerJugadores());
	}

	IEnumerator ObtenerJugadores()
	{
		WWW www = new WWW("http://" + UrlPuntaciones);
		mensajes.text="Cargando puntuaciones...";
		yield return www;
		
		if (www.error != null)
		{
			mensajes.text = "Error al conectar con base de datos";
		}
		if (www.text[0] == '1')
		{
			mensajes.text = "Error de conexion";
		}

		else {
			mensajes.text = "";
			obtenerRegistros(www);
			VerRegistros();


	}
}

	private void VerRegistros()
	{
		for (int i = 0; i < rankingJugadores.Count; i++) {
			GameObject obj = Instantiate(panelPre);
			FilaScore fs = rankingJugadores[i];
			obj.GetComponent<Score>().SetScore(fs.jugador, fs.puntuacion);
			obj.transform.SetParent(tfPanelCarga);
			obj.GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);
		}
		
	}

	private void obtenerRegistros(WWW www)
	{
		currentArray = System.Text.Encoding.UTF8.GetString(www.bytes).Split("\t"[0]);
		for (int i = 0; i <= currentArray.Length - 3; i = i + 2)
		{
			rankingJugadores.Add(new FilaScore(currentArray[i], currentArray[i + 1]));
		}

	}

	public class FilaScore
{
	public string jugador;
	public string puntuacion;

	public FilaScore(string nombreJugador, string puntuacionJugador)
	{
		puntuacion = puntuacionJugador;
		jugador = nombreJugador;
	}

}
}

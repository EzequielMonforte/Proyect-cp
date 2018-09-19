using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameControl : MonoBehaviour {
	public static int vida;
    
    public RawImage background;
	public enum EstadosJuego{ espera, jugando, final};
    public EstadosJuego estados = EstadosJuego.espera;
    public GameObject UiInicio;
	public GameObject UiGame;
	public GameObject UiFinal;
    public GameObject GeneradorNaves;
	public GameObject jugador;
	
	
	


	void Start () {

		
	}
	
	// Update is called once per frame
	void Update () {
		//start game
		if (vida < 0 && estados==EstadosJuego.jugando)
		{
			
			callScore();
			GeneradorNaves.SendMessage("pararGenerador");
			estados = EstadosJuego.final;
			
			UiFinal.SetActive(true);
			UiGame.SetActive(false);
			jugador.SetActive(false);
			
			
		}
		if (estados == EstadosJuego.espera)
		{
			jugador.transform.position = new Vector3(0, -40, -2);
			Movimientos.activo = false;
			MoverFondo(1f);
			UiGame.SetActive(false);
			UiFinal.SetActive(false);
			UiInicio.SetActive(true);
			jugador.SetActive(true);

		}
		
		if (estados == EstadosJuego.espera && Input.GetKeyDown(KeyCode.Space))
        {
			Movimientos.activo = true;
            estados = EstadosJuego.jugando;
            UiInicio.SetActive(false);
			UiGame.SetActive(true);
            GeneradorNaves.SendMessage("iniciarGenerador");
			vida = 3;
			
		}
        //jugan2
         if (estados == EstadosJuego.jugando)
        {
			MoverFondo(0.2f);
		}
        
	}

	public static void restarVida()
	{
		vida = vida - 1;
	}
   

    private void MoverFondo(float velocidad)
    {
        float velocidadfinal = velocidad * Time.deltaTime;
        background.uvRect = new Rect(0f, background.uvRect.y + velocidadfinal, 1f, 1f);
    }

	public void Remake()
	{
		
		if (BaseDatos.scoreActual > int.Parse(BaseDatos.maxscore)){
			BaseDatos.maxscore = BaseDatos.scoreActual.ToString();
		}
		BaseDatos.ultscore = BaseDatos.scoreActual.ToString();
		BaseDatos.scoreActual = 0;
		
		estados = EstadosJuego.espera;
		SceneManager.LoadScene(1);
	}
	public void callScore()
	{
		StartCoroutine(GuardarScore());

	}
	IEnumerator GuardarScore()
	{
		WWWForm form = new WWWForm();
		form.AddField("usuario", BaseDatos.usuario);
		form.AddField("ultscore", BaseDatos.scoreActual);
		form.AddField("maxscore",int.Parse(BaseDatos.maxscore));
		WWW www = new WWW("http://spacefighter.sytes.net/www/guardarscore.php", form);
		yield return www;
		if (www.text[0] == '0')
		{
			Debug.Log("upadeteado");
		}
	}
}

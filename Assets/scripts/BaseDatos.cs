using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class BaseDatos{

	public static string usuario;
	public static string maxscore;
	public static string ultscore;
	public static int scoreActual;
	

	public static bool logueado { get { return usuario != null; } }


	public static void Salir()
	{
		usuario = null;
		maxscore = null;
		ultscore = null;
		scoreActual = 0;
		
	}
}

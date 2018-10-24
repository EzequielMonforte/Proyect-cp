using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerarNaves : MonoBehaviour {
    public GameObject NaveEnem1;
    public GameObject NaveEnem2;
	public GameObject NaveEnem3;
	public GameObject RecargaBalas;
	public GameObject Piedra;
	public GameObject aumentaVida;
	



    // Use this for initialization
    void Start () {
        
    }
	
	// Update is called once per frame
	void Update () {
        
        
    }
	public void generarAumentaVida()
	{
		var objeto = GameObject.Find("Generarnaves");

		Vector3 alaIzq = objeto.transform.position + Vector3.back * 6f + Vector3.right * UnityEngine.Random.Range(-7, 8);

		//Instantiate(RecargaBalas, alaIzq, Quaternion.identity);
		Instantiate(aumentaVida, alaIzq, Quaternion.identity);



	}
	public void generarRecargaBalas()
	{
		var objeto = GameObject.Find("Generarnaves");

		Vector3 alaIzq = objeto.transform.position + Vector3.back * 6f + Vector3.right * UnityEngine.Random.Range(-7, 8);

		//Instantiate(RecargaBalas, alaIzq, Quaternion.identity);
		Instantiate(RecargaBalas, alaIzq, Quaternion.identity);
		


	}
	public void generarEnemigo3()
	{
		var objeto = GameObject.Find("Generarnaves");

		Vector3 alaIzq = objeto.transform.position + Vector3.back * 6f + Vector3.right * UnityEngine.Random.Range(-7, 8);

		Instantiate(NaveEnem3, alaIzq, Quaternion.identity);

	}
	public void generarEnemigo2()
    {
        var objeto = GameObject.Find("Generarnaves");

        Vector3 alaIzq = objeto.transform.position + Vector3.back * 6f + Vector3.right * UnityEngine.Random.Range(-7, 8);

		Instantiate(NaveEnem2, alaIzq, Quaternion.identity);

	}

    public void generarEnemigo1()
    {
        var objeto = GameObject.Find("Generarnaves");

        Vector3 alaIzq = objeto.transform.position+Vector3.back*6f+ Vector3.right * UnityEngine.Random.Range(-7, 8);

		Instantiate(NaveEnem1, alaIzq, Quaternion.identity);

	}
	public void GenerarPiedra() {
		var objeto = GameObject.Find("Generarnaves");

		Vector3 alaIzq = objeto.transform.position + Vector3.back * 6f + Vector3.right * UnityEngine.Random.Range(-7, 8);

		Instantiate(Piedra, alaIzq, Quaternion.identity);
	}
    public void iniciarGenerador()
    {
        InvokeRepeating("generarEnemigo1", UnityEngine.Random.Range(5f, 15f), UnityEngine.Random.Range(10f, 15f));
        InvokeRepeating("generarEnemigo2", UnityEngine.Random.Range(0f, 5f), UnityEngine.Random.Range(4.5f, 9f));
		InvokeRepeating("generarEnemigo3", UnityEngine.Random.Range(0f, 5f), UnityEngine.Random.Range(2f, 6.7f));
		InvokeRepeating("GenerarPiedra", UnityEngine.Random.Range(0f, 5f), UnityEngine.Random.Range(5f, 10f));
		InvokeRepeating("generarRecargaBalas", UnityEngine.Random.Range(8f, 13f), UnityEngine.Random.Range(5f, 10f));
		InvokeRepeating("generarAumentaVida", UnityEngine.Random.Range(40f, 50f), UnityEngine.Random.Range(45f, 70f));

	}
    public void pararGenerador()
    {
		CancelInvoke("GenerarPiedra");
		CancelInvoke("generarEnemigo1");
        CancelInvoke("generarEnemigo2");
		CancelInvoke("generarEnemigo3");
		CancelInvoke("generarRecargaBalas");
		CancelInvoke("generarAumentaVida");
	}
}

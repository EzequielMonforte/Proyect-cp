using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerarNaves : MonoBehaviour {
    public GameObject NaveEnem1;
    public GameObject NaveEnem2;
	public GameObject RecargaBalas;



    // Use this for initialization
    void Start () {
        
    }
	
	// Update is called once per frame
	void Update () {
        
        
    }
	public void generarRecargaBalas()
	{
		var objeto = GameObject.Find("Generarnaves");

		Vector3 alaIzq = objeto.transform.position + Vector3.back * 6f + Vector3.right * UnityEngine.Random.Range(-7, 8);

		Instantiate(RecargaBalas, alaIzq, Quaternion.identity);
		

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
    public void iniciarGenerador()
    {
        InvokeRepeating("generarEnemigo1", UnityEngine.Random.Range(5f, 15f), UnityEngine.Random.Range(10f, 15f));
        InvokeRepeating("generarEnemigo2", UnityEngine.Random.Range(0f, 5f), UnityEngine.Random.Range(1f, 2f));
		
		InvokeRepeating("generarRecargaBalas", UnityEngine.Random.Range(10f, 22f), UnityEngine.Random.Range(9.5f, 14.5f));

	}
    public void pararGenerador()
    {
		
		CancelInvoke("generarEnemigo1");
        CancelInvoke("generarEnemigo2");
		CancelInvoke("generarRecargaBalas");
    }
}

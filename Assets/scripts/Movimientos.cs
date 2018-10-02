using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Movimientos : MonoBehaviour {

	// Use this for initialization
	public GameObject body;
	public float velocidad = 9.5f;
	public float padding = 2.66f;
	public GameObject bala;
	public static bool activo;
	public AudioSource sonidoDisparo;



	void Start() {
		activo = true;
		
	}

	// Update is called once per frame
	void Update()
	{
		if (activo)
		{

			//movimientos flechas
			if (Input.GetKey(KeyCode.LeftArrow))
			{
				this.transform.position -= new Vector3(velocidad * Time.deltaTime, 0, 0);
			}
			else if (Input.GetKey(KeyCode.A))
			{
				this.transform.position -= new Vector3(velocidad * Time.deltaTime, 0, 0);
			}
			
			//movimientos a d


			if (Input.GetKey(KeyCode.D))
			{
				this.transform.position += new Vector3(velocidad * Time.deltaTime, 0, 0);
			}
			else if (Input.GetKey(KeyCode.RightArrow))
			{
				this.transform.position += new Vector3(velocidad * Time.deltaTime, 0, 0);
			}
			
				float xCorregir = Mathf.Clamp(transform.position.x, -10 + padding, 10 - padding);
			this.transform.position = new Vector3(xCorregir, -8, 0);

			//disparar

			if (Input.GetKeyDown(KeyCode.Space))
			{

				if (HudJuego.cantidadBalas > 0)
				{

					Invoke("Disparo", 0.01f);
					sonidoDisparo.Play();
					
					HudJuego.cantidadBalas--;

				}
			}
			else if (Input.GetKeyUp(KeyCode.Space))
				CancelInvoke("Disparo");
			//android
			if (Input.touchCount==1)
			{

				if (HudJuego.cantidadBalas > 0)
				{

					Invoke("Disparo", 0.01f);
					sonidoDisparo.Play();

					HudJuego.cantidadBalas--;

				}
				else if (Input.touchCount==0)
					CancelInvoke("Disparo");
			}
			
		}
	}


	void OnTriggerEnter2D(Collider2D otro) {

		if (otro.tag == "Enem1")
		{
			Debug.Log("nave enemiga chocadda");
		}
		if (otro.tag == "Enem2")
		{

			Debug.Log("nave enemiga chocadda");
		}
		if (otro.tag == "RecargaBala")
		{
			HudJuego.cantidadBalas += 30;
			Debug.Log("balas recargadas");
		}


	}
    void Disparo()
    {
        var nave = GameObject.Find("Jugador");
        if (nave != null)
        {
            Vector3 alaDer = nave.transform.position + Vector3.up * 0.65f + Vector3.right * 0.95f;
            Vector3 alaIzq = nave.transform.position + Vector3.up * 0.65f + Vector3.left * 0.95f;
            Instantiate(bala, alaDer, Quaternion.identity);
            Instantiate(bala, alaIzq, Quaternion.identity);
            
        }

    }


}

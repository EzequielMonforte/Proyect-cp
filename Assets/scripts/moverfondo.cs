using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class moverfondo : MonoBehaviour {
	public RawImage background;
	public float velocidad = 0.5f;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		MoverFondo(velocidad);
	}
	private void MoverFondo(float velocidad)
	{
		float velocidadfinal = velocidad * Time.deltaTime;
		background.uvRect = new Rect(0f, background.uvRect.y + velocidadfinal, 1f, 1f);
	}
}

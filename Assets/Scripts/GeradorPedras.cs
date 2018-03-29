	 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeradorPedras : MonoBehaviour {

	public GameObject pedrasPrefab;
	public float delayPedras = 2f;

	// Use this for initialization
	void Start () {
		InvokeRepeating ("GerarPedras", delayPedras, delayPedras);
	}

	void GerarPedras () {
		Instantiate (pedrasPrefab);
	}
}

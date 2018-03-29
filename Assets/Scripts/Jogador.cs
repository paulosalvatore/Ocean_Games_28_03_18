using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Jogador : MonoBehaviour {

	private Rigidbody2D rb;

	public float forcaPulo = 300f;

	private int pontos = 0;
	public Text pontosText;

	public float delayMorrer = 2f;

	private bool morto = false;

	public Text gameOverText;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (!morto && Input.GetKeyDown(KeyCode.Space)) {
			Pular ();
		}
	}

	void Pular ()
	{
		rb.velocity = Vector2.zero;
		rb.AddForce (Vector2.up * forcaPulo);
	}

	void OnTriggerEnter2D(Collider2D colisor) {
		if (colisor.CompareTag("ColisorPontos")) {
			pontos = pontos + 1;
			pontosText.text = "Pontos: " + pontos;
		}
	}

	void OnCollisionEnter2D(Collision2D colisao) {
		if (colisao.gameObject.CompareTag("Inimigos")) {
			Morrer ();
			Invoke ("ReiniciarJogo", delayMorrer);
		}
	}

	void Morrer() {
		morto = true;

		gameOverText.enabled = true;
	}

	void ReiniciarJogo() {
		SceneManager.LoadScene (SceneManager.GetActiveScene().buildIndex);
	}
}

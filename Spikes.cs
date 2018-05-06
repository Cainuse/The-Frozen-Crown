using UnityEngine;
using System.Collections;

public class Spikes : MonoBehaviour {

	private PlayerControler player;

	// Use this for initialization
	void Start () {

		player = GameObject.FindGameObjectWithTag ("Player").GetComponent<PlayerControler> ();
	
	}
	
	// Update is called once per frame
	void OnTriggerEnter2D (Collider2D col) {

		if (col.CompareTag ("Player")) {

			player.Damage (1000);

			StartCoroutine (player.Knockback (0.02f, 300, player.transform.position));
		
		}
	
	}



}

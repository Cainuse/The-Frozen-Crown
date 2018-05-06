using UnityEngine;
using System.Collections;

public class DoorDamage : MonoBehaviour {


	public int currentHealth;
	public int maxHealth;

    public AudioSource clank;

	void Start()
	{
        clank.Pause();
		currentHealth = maxHealth;
	}


	void Update(){
		if (currentHealth <= 0) {
			Destroy (gameObject);
		}
	}
			
	
	public void Damage (int damage)
	{
		currentHealth -= damage;
        clank.Play();
        gameObject.GetComponent<Animation>().Play("Player_RedFlashes");

	}
}

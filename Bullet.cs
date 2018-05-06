using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {



	void OnTriggerEnter2D (Collider2D col) 
	{

		if (col.isTrigger != true) 
		{
			
			if (col.CompareTag ("Player")) 
			{

				col.GetComponent<PlayerControler> ().Damage (5);

				Destroy (gameObject);
			}
            else if (col.CompareTag("Untagged"))
            {
                Destroy(gameObject);
            }


        }

    }
}

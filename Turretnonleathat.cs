using UnityEngine;
using System.Collections;

public class Turretnonleathat : MonoBehaviour {

    private PlayerControler player;

    void Start()
    {

        player = GameObject.FindGameObjectWithTag ("Player").GetComponent<PlayerControler> ();
       
     }

    void OnTriggerEnter2D(Collider2D col)
    {

        if (col.isTrigger != true)
        {

            if (col.CompareTag("Player"))
            {

                col.GetComponent<PlayerControler>().Damage(0);

                StartCoroutine(player.Knockback(0.02f, 0, player.transform.position));

                Destroy(gameObject);

            }
            else if (col.CompareTag("Untagged"))
            {
                Destroy(gameObject);
            }

        }

    }
}

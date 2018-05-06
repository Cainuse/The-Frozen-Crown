using UnityEngine;
using System.Collections;

public class AttackConeTurret : MonoBehaviour {

    public TurretAi turretai;

    public bool isLeft = false; //check if it is left or right

    void Awake()
    {



    }

    void OnTriggerStay2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            if (isLeft)
            {
                turretai.Attack(false);
            }
            else
            {
                turretai.Attack(true);
            }
        }

    }
}

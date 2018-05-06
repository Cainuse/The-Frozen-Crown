using UnityEngine;
using System.Collections;

public class AttackCone : MonoBehaviour {

	public PedobearAi pedobearai;

	public bool isLeft = false; //check if it is left or right

	void Awake()
	{



	}

	void OnTriggerStay2D(Collider2D col)
	{
		if(col.CompareTag("Player"))
		{
			if(isLeft)
			{
				pedobearai.Attack (false);
			}
			else
			{
				pedobearai.Attack (true);
			}
		}

	}
}

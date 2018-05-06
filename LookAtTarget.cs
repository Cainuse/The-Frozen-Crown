// C#
using System;
using UnityEngine;


public class LookAtTarget : MonoBehaviour
{
	public Transform target;
	public float object1;
	public float dist; 
	public float facing;


	void Update()
	{
		facing = GameObject.Find("Monster_1").transform.localScale.x;
		object1 = GameObject.Find("Monster_1").transform.position.x;
		dist = object1 - target.transform.position.x; 
		if(target != null)
		{
			if(dist > 0)
			{
				if(facing == 1)
				{
					Vector3 theScale = transform.localScale;
					theScale.x *= -1;
					transform.localScale = theScale;
				}
			}

			if(dist < 0)
			{
				if(facing == -1)
				{
					Vector3 theScale = transform.localScale;
					theScale.x *= -1;
					transform.localScale = theScale;
				}
			}




		}
	}

}
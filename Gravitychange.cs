using UnityEngine;
using System.Collections;

public class Gravitychange : MonoBehaviour {
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
		if(Input.GetKeyDown (KeyCode.LeftShift))
		{
			Reversegravity ();
			
		}
	}
	
	void Reversegravity () {

		Vector3 thescale = transform.localScale;
		thescale.x *= -1;
		transform.localScale = thescale;
	}






	
	
}

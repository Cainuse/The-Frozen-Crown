using UnityEngine;
using System.Collections;

public class Camerafollow : MonoBehaviour {
	
	private Vector2 velocity;
	
	public float smoothtimeX;
	public float smoothtimeY;
	
	public GameObject player;

	public bool bound; //this is used to determine if the camera location is within boundry

	public Vector3 maxcamerapos;
	public Vector3 mincamerapos;
	
	void Start () {
		
		player = GameObject.FindGameObjectWithTag ("Player"); //used to find the location of my poor little charcater
		
	}
	
	
	void FixedUpdate () {
		
		float posx = Mathf.SmoothDamp(transform.position.x, player.transform.position.x, ref velocity.x, smoothtimeX);
		float posy = Mathf.SmoothDamp(transform.position.y, player.transform.position.y, ref velocity.y, smoothtimeY);	

			transform.position = new Vector3 (posx, posy, transform.position.z);		//allows us to move the camera

		if(bound){
			transform.position = new Vector3 (Mathf.Clamp (transform.position.x, mincamerapos.x, maxcamerapos.x), 
				Mathf.Clamp (transform.position.y, mincamerapos.y, maxcamerapos.y), 
				Mathf.Clamp (transform.position.z, mincamerapos.z, maxcamerapos.z));
		}
}

}
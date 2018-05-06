using UnityEngine;
using System.Collections;

public class MovingPlatform : MonoBehaviour {

    /*
    public GameObject movingplatform;

    public float moveSpeed;

    public Transform currentpoint;

    public Transform[] points;

    public int pointsSelection;

    private Rigidbody2D rb2d;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        currentpoint = points[pointsSelection];
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.collider.CompareTag("Player"))
        {
            StartCoroutine(fall());
        }


    }

    IEnumerator fall()
    {

        movingplatform.transform.position = Vector3.MoveTowards(movingplatform.transform.position, currentpoint.position, Time.deltaTime * moveSpeed);

        yield return 0;
    }
    */


     public GameObject movingplatform;

    public float moveSpeed;

    public Transform currentpoint;

    public Transform[] points;

    public int pointsSelection;

    void Start()
    {
        currentpoint = points[pointsSelection];
    }



    void Update()
    {
        movingplatform.transform.position = Vector3.MoveTowards(movingplatform.transform.position, currentpoint.position, Time.deltaTime * moveSpeed);

        if (movingplatform.transform.position == currentpoint.position)
        {
            pointsSelection++;

            if (pointsSelection == points.Length)
            {
                pointsSelection = 0;
            }

            currentpoint = points[pointsSelection];

        }

    } 
}
  

    

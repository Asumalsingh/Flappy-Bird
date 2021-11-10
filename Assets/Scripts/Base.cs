using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Base : MonoBehaviour
{
    
    [SerializeField]
    private float speed = 1f;

    private Vector2 startPosition;
    private float tileSize;
    private float newPosition;


    // Start is called before the first frame update
    void Start()
    {
        startPosition = transform.position;
        tileSize = transform.GetComponent<Renderer>().bounds.size.x;
    }

    // Update is called once per frame
    void Update()
    {
        newPosition = Mathf.Repeat(Time.time * speed, tileSize);
        transform.position = startPosition + Vector2.left * newPosition;
    }



}

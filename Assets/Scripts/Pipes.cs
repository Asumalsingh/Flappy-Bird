using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pipes : MonoBehaviour
{
    
    public float speed;
   [SerializeField]
   private Rigidbody2D  mybody;

     public float leftLimit ;

    // Start is called before the first frame update
    void Start()
    {
        mybody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        mybody.velocity = new Vector2(speed, mybody.velocity.y);
        DestroyPipes();
    }

    void DestroyPipes()
    {
        if (gameObject.CompareTag("Column"))
        {
            if (transform.position.x <= leftLimit)
            {
                Destroy(gameObject);
            }
        }

    }
    
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject[] pipeRefrence; 

    
    public float minY;
    public float maxY;

    private int randomIndex;
    private GameObject spawnedPipe;


    // Start is called before the first frame update
    void Start()
    {
         StartCoroutine(SpawnPipes());         
    }
    IEnumerator SpawnPipes()
    {

        while (true)
        {
            yield return new WaitForSeconds(Random.Range(2,2));
            randomIndex = Random.Range(0, pipeRefrence.Length);
            float randomYposition = Random.Range(minY, maxY);

            spawnedPipe = Instantiate(pipeRefrence[randomIndex]);
            spawnedPipe.transform.position = new Vector2(transform.position.x, randomYposition);

            spawnedPipe.GetComponent<Pipes>().speed = -2f;
        }

    }
    
    

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class Player : MonoBehaviour
{
    [SerializeField]
    private Rigidbody2D myBody;
   
    private Animator anim;
    public float jumpSpeed;    

    public int score;
    public int highScore;

    //Refrence for score and Highscore
    public Text SCORE;
    public Text HIGH_SCORE;
        
    //Refrence for replayGame
    public GameObject replayBtn;

    //Refrence for game over
    public GameObject gameOverImage;

    //Refrence for canvas
    public GameObject Canvas;
    

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1; //to restart game
        myBody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        //AddHighScore();       
    }

    public void Update()
    {
        SCORE.text = score.ToString();
        HIGH_SCORE.text = highScore.ToString();
        AddHighScore();
                
    }
    private void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            myBody.velocity = Vector2.up * jumpSpeed;
            anim.SetBool("Fly", true);           
        }        
       
    }

    public void AddScore()
    {
        score++;
    }

    public void AddHighScore()
    {
        if(score > highScore)
        {
            PlayerPrefs.SetInt("HighScore",  score);
        }
        highScore = PlayerPrefs.GetInt("HighScore");
    }

    void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.CompareTag("Ground") || collision.gameObject.CompareTag("Pipe"))
        {
            anim.SetBool("Fly", false);

            //Game over
            Time.timeScale = 0;                      

            //Activating canvas
            Canvas.SetActive(true);          
            
        }        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Column"))
        {
            //adding scores
            print("score up");
            AddScore();
        }
    }

    
    public void ReplayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void GameOver()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    


}

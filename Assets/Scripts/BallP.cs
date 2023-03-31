using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BallP : MonoBehaviour
{
    Rigidbody2D rbBall;
    Collider2D Ballcollider;
    Vector2 speedCheck;
    float random;
    bool started;
    bool did = false;
    int score;
    int moment;
    int liczbaPrzyspieszen = 1;
    public Animator transition;
    public GameObject tekst;


    public static int actualSpeed;

    public Sprite purpleBall, greenBall, redBall, pokeBall, tenisBall, pokeBlackBall;
    SpriteRenderer  renderBall;
    
   
    void Awake()
    {
        
        speedCheck = new Vector2();
        actualSpeed = 7;
        
        rbBall = GetComponent<Rigidbody2D>();
        Ballcollider = GetComponent<CircleCollider2D>();
        renderBall = this.GetComponent<SpriteRenderer>();

        if(PlayerPrefs.GetInt("Ball") == 0)
        {
            renderBall.sprite = purpleBall;
        }else if(PlayerPrefs.GetInt("Ball") == 1)
        {
            renderBall.sprite = greenBall;
        }else if(PlayerPrefs.GetInt("Ball") == 2)
        {
            renderBall.sprite = redBall;
        }else if (PlayerPrefs.GetInt("Ball") == 3)
        {
            renderBall.sprite = pokeBall;
        }
        else if (PlayerPrefs.GetInt("Ball") == 4)
        {
            renderBall.sprite = tenisBall;
        }
        else if (PlayerPrefs.GetInt("Ball") == 5)
        {
            renderBall.sprite = pokeBlackBall;
        }
    }


    void Update()
    {
        if (!started)
        {
            if (Input.anyKeyDown)
            {
                FirstRandomBounce();
                //transition.SetBool("Tapto", false);
                tekst.SetActive(false);
                started = true;
            }
        }else if(started)
        {
            SpeedCheck();
        }
        score = GameManager.score;
        DidMan();
        SpeedIncrease();
        
        
        
    }
    void FirstRandomBounce()
    {
        random = Random.Range(-1, 1);
        if (random == 0)
        {
            random++;

        }
        Vector2 randomDir = new Vector2(random, 1);
        rbBall.AddForce(randomDir * actualSpeed, ForceMode2D.Impulse);


    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.tag == "Lose")
        {
            InGameSounds.instance.LostSound();
            GameManager.instance.Lost();
            rbBall.velocity = new Vector2(0f, 0f);
            rbBall.constraints = RigidbodyConstraints2D.FreezePosition;
            PaddleP.rbPaddle.constraints = RigidbodyConstraints2D.FreezeAll;
            GameManager.score = 0;
            liczbaPrzyspieszen = 1;
            actualSpeed = 7;
        }
        else if (collision.gameObject.tag == "Paddle")
        {
            GameManager.instance.ScoreMan();
        }
        else if (collision.gameObject.tag == "Wall")
        {
            InGameSounds.instance.WallSound();
        }
        else if (collision.gameObject.tag == "LoseEnemy")
        {
            
            InGameSounds.instance.LostSound();
            GameManager.instance.EnemyLost();
            rbBall.velocity = new Vector2(0f, 0f);
            if (SceneManager.GetActiveScene().name == "G2")
            {
                PaddleP.rbPaddle.constraints = RigidbodyConstraints2D.FreezeAll;
            }
            rbBall.constraints = RigidbodyConstraints2D.FreezePosition;
            GameManager.score = 0;
            liczbaPrzyspieszen = 1;
            actualSpeed = 7;

        }
        else if (collision.gameObject.tag == "YouLose")
        {
            InGameSounds.instance.LostSound();
            GameManager.instance.YouLost();
            rbBall.velocity = new Vector2(0f, 0f);
            rbBall.constraints = RigidbodyConstraints2D.FreezePosition;
            if (SceneManager.GetActiveScene().name == "G2") { 
                PaddleP.rbPaddle.constraints = RigidbodyConstraints2D.FreezeAll;
            }
           GameManager.score = 0;
           liczbaPrzyspieszen = 1;
           actualSpeed = 7;
       }
       
       

    }
    private void SpeedCheck(){
//Prędkośc piłki jest stała nawet gdy uderzy w nierówny kąt paddle
       
        speedCheck = rbBall.velocity;
        if(speedCheck.x > (actualSpeed* -1) && speedCheck.x < 0){
            rbBall.velocity = new Vector2((actualSpeed* -1), rbBall.velocity.y);
        }else if(speedCheck.y > (actualSpeed* -1) && speedCheck.y < 0 ){
            rbBall.velocity = new Vector2(rbBall.velocity.x,(actualSpeed* -1));
        }else if(speedCheck.x < actualSpeed && speedCheck.x > 0){
            rbBall.velocity = new Vector2(actualSpeed, rbBall.velocity.y);
        }else if (speedCheck.y < actualSpeed && speedCheck.y > 0){
            rbBall.velocity = new Vector2(rbBall.velocity.x , actualSpeed);
        }

    }
    public void SpeedIncrease(){
        
    
        if(score == moment){
            
            actualSpeed++;

            if(speedCheck.x < 0  && (!did)){
                speedCheck.x  = actualSpeed * -1;
            }else if (speedCheck.x > 0  && (!did)){
                speedCheck.x  = actualSpeed;
            }else if (speedCheck.y < 0  && (!did)){
                speedCheck.y  = actualSpeed* -1;
            }else if (speedCheck.y > 0  && (!did)){
                speedCheck.y  = actualSpeed;
            }
            //did = true;
            liczbaPrzyspieszen++;
        }
    }
    private void DidMan(){
//Wspiera dzialanie speed increase  
        moment = 5 * liczbaPrzyspieszen;
        

    }
   
}

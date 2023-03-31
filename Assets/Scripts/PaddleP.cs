using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleP : MonoBehaviour
{
    public static Rigidbody2D rbPaddle;
    public float paddleY = 4.57f;
    public float Speed;

    Vector2 posOfTouchLR;
    Vector2 posOfTouchTT;
    Vector2 direction;
    Vector2 paddlePos;
    
    public GameObject ball;
    private int randomRandom;
    private int  movementType;
    public Sprite purple, green, red, frozen, neon, wooden;

    SpriteRenderer render;    

    void Awake()
    {
        rbPaddle = GetComponent<Rigidbody2D>();
        GameManager.canPaddleMove = true;
        movementType = PlayerPrefs.GetInt("LR");
        render = this.GetComponent<SpriteRenderer>();

        if(PlayerPrefs.GetInt("Paddle") == 0)
        {
            render.sprite = purple;
        }else if(PlayerPrefs.GetInt("Paddle") == 1)
        {
            render.sprite = green;
        }else if(PlayerPrefs.GetInt("Paddle") == 2)
        {
            render.sprite = red;
        }
        else if (PlayerPrefs.GetInt("Paddle") == 3)
        {
            render.sprite = frozen;
        }
        else if (PlayerPrefs.GetInt("Paddle") == 4)
        {
            render.sprite = neon;
        }
        else if (PlayerPrefs.GetInt("Paddle") == 5)
        {
            render.sprite = wooden;
        }

    }
    void FixedUpdate()
    {
        if(Input.GetMouseButton(0) && GameManager.canPaddleMove)
        {
            if(movementType == 1){
                MoveLR();
            }else if (movementType == 0)
            {
                MoveToTouch();
            }
        }else
        {
            rbPaddle.velocity = Vector2.zero;
        }
    }

    void MoveLR() 
    {
            posOfTouchLR = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            if (posOfTouchLR.x < 0)
            {
                rbPaddle.velocity = Vector2.left * Speed;
            }
            else if (posOfTouchLR.x > 0)
            {
                rbPaddle.velocity = Vector2.right * Speed;
            }
    } 
    void MoveToTouch()
    {
            posOfTouchTT = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            paddlePos = rbPaddle.position; 
            direction = posOfTouchTT - paddlePos;
            rbPaddle.velocity = new Vector2(direction.x, (transform.position.y * 0) - paddleY) * Speed* 100 * Time.deltaTime;     
    } 
    private void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.tag == "Ball") {
            InGameSounds.instance.PaddleSound();
        } 
        else if(other.gameObject.tag == "BallDown")
        {
            InGameSounds.instance.PowerUpSound();
            ball.transform.localScale = new Vector2 (0.5f,0.5f);
            Destroy(other.gameObject);
            StartCoroutine(Czas());

        }else if(other.gameObject.tag == "BallUp"){
            InGameSounds.instance.PowerUpSound();
            Destroy(other.gameObject);
            ball.transform.localScale = new Vector2 (2,2);
            StartCoroutine(Czas());

        }else if(other.gameObject.tag == "CoinBonus"){
            InGameSounds.instance.PowerUpSound();
            GameManager.instance.kaska++;
            Destroy(other.gameObject);
            

        }else if(other.gameObject.tag == "Random"){
            InGameSounds.instance.PowerUpSound();
            Destroy(other.gameObject);
            randomRandom = Random.Range(1,5);
            
            if(randomRandom == 1)
            {
            ball.transform.localScale = new Vector2 (0.5f,0.5f);
            StartCoroutine(Czas());

            }else if(randomRandom == 2)
            {
                ball.transform.localScale = new Vector2 (2,2);
                StartCoroutine(Czas());

            }else if(randomRandom == 3)
            {
                GameManager.instance.kaska++;
            }else if(randomRandom == 4){
            this.transform.localScale = new Vector2(0.75f, 1);
            StartCoroutine(Czas());
            }

        }else if(other.gameObject.tag == "Size"){
            InGameSounds.instance.PowerUpSound();
            Destroy(other.gameObject);
            this.transform.localScale = new Vector2(0.75f, 1);
            StartCoroutine(Czas());

        } 
    }
    IEnumerator Czas ()
    {
        yield return new WaitForSeconds(5);
        ball.transform.localScale = new Vector2(1,1);
        this.transform.localScale = new Vector2 (1,1);
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAi : MonoBehaviour
{

    Vector2 posOfTouchTT;
    Vector2 direction;
    Vector2 paddlePos;
    Rigidbody2D rbPaddle;
    public Rigidbody2D rbBall;
    SpriteRenderer render; 
    public Sprite red;
    Vector2 siema;
    Vector2 posT;
    public static bool didEnd;
    int randomSpeed;

    void Awake()
    {
        randomSpeed = 140;
        didEnd = false;
        render = this.GetComponent<SpriteRenderer>();
        rbPaddle = GetComponent<Rigidbody2D>();
        render.sprite = red;
    }

    void Update()
    {
        if(!didEnd){
        PaddleMovement();
        }else if (didEnd)
        {
            rbPaddle.constraints = RigidbodyConstraints2D.FreezeAll;
        }
    }
    void PaddleMovement()
    {
        posOfTouchTT = rbBall.transform.position;
        posT = new Vector2 (posOfTouchTT.x, 4.57f);
            
        siema = Vector2.Lerp(this.gameObject.transform.position, posT, randomSpeed* Time.deltaTime);  
            
        paddlePos = rbPaddle.position; 
        direction = posOfTouchTT - paddlePos;

        if(rbBall.transform.position.y > -1){
            rbPaddle.position = siema;  
        }
    }
    void RandomAi()
    {
        randomSpeed = Random.Range(100, 180);
    } 
    private void OnCollisionEnter2D(Collision2D other) 
    {
        if(other.gameObject.tag == "Ball"&& GameManager.score % 3 == 0 && GameManager.score > 1 )
        {
           RandomAi();
        }
        if(other.gameObject.tag == "Ball") {
            InGameSounds.instance.PaddleSound();
        }  
    }
}

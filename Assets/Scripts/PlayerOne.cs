using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerOne : MonoBehaviour
{
    public static Rigidbody2D rbPaddle;
    public float paddleY = 4.57f;
    public float Speed;

    Vector2 posOfTouchLR;
    Vector2 posOfTouchTT;
    Vector2 direction;
    Vector2 paddlePos;

    public GameObject ball;
    private int movementType;

    void Awake()
    {
        rbPaddle = GetComponent<Rigidbody2D>();
        GameManager.canPaddleMove = true;
        movementType = PlayerPrefs.GetInt("LR");

    }
    void FixedUpdate()
    {
        foreach(Touch touch in Input.touches)
        {
            if (GameManager.canPaddleMove && touch.position.y < Screen.height / 2)
            {
                if (movementType == 1)
                {
                    posOfTouchLR = Camera.main.ScreenToWorldPoint(touch.position);

                    if (posOfTouchLR.x < 0)
                    {
                        rbPaddle.velocity = Vector2.left * Speed;
                    }
                    else if (posOfTouchLR.x > 0)
                    {
                        rbPaddle.velocity = Vector2.right * Speed;

                    }
                }
                else if (movementType == 0)
                {
                    posOfTouchTT = Camera.main.ScreenToWorldPoint(touch.position);
                    paddlePos = rbPaddle.position;
                    direction = posOfTouchTT - paddlePos;
                    rbPaddle.velocity = new Vector2(direction.x, (transform.position.y * 0) - paddleY) * Speed * 100 * Time.deltaTime;
                }
            }
            else if (!GameManager.canPaddleMove)
            {
                rbPaddle.velocity = Vector2.zero;
            }
        } 
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ball")
        {
            InGameSounds.instance.PaddleSound();
        }
    }
}

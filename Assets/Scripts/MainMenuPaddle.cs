using GoogleMobileAds.Api;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Unity.Burst.Intrinsics.Arm;

public class MainMenuPaddle : MonoBehaviour
{
    float random;
    //public GameObject paddle;
    public Rigidbody2D rbBall;
    public Rigidbody2D rbPaddle;
    Vector2 posOfTouchTT;
    public float paddleY = 4.57f;
    public float Speed;
    public SpriteRenderer render;
    SpriteRenderer  renderBall;

    public Sprite purple, green, red, frozen, neon ,wooden;
    public Sprite purpleBall, greenBall, redBall, tenisBall, pokeBlackBall, pokeBall;

    void Start()
    {
        rbBall = GetComponent<Rigidbody2D>();
        renderBall = this.GetComponent<SpriteRenderer>();

        if (PlayerPrefs.GetInt("Paddle") == 0)
        {
            render.sprite = purple;
        }
        else if (PlayerPrefs.GetInt("Paddle") == 1)
        {
            render.sprite = green;
        }
        else if (PlayerPrefs.GetInt("Paddle") == 2)
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

        if (PlayerPrefs.GetInt("Ball") == 0)
        {
            renderBall.sprite = purpleBall;
        }
        else if (PlayerPrefs.GetInt("Ball") == 1)
        {
            renderBall.sprite = greenBall;
        }
        else if (PlayerPrefs.GetInt("Ball") == 2)
        {
            renderBall.sprite = redBall;
        }
        else if (PlayerPrefs.GetInt("Ball") == 3)
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
        FirstRandomBounce();
    }

    void Update()
    {
        PaddleMovement();        
    }
    void FirstRandomBounce()
    {
        random = Random.Range(-1, 1);
        if (random == 0)
        {
            random++;
        }
        Vector2 randomDir = new Vector2(random, 1);
        rbBall.AddForce(randomDir * 7, ForceMode2D.Impulse);
    }
    void PaddleMovement()
    {
        posOfTouchTT = rbBall.transform.position;
        rbPaddle.position = new Vector2(posOfTouchTT.x, -4.57f);     
    }
}

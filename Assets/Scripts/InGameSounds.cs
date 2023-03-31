using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGameSounds : MonoBehaviour
{
    public static InGameSounds instance;
    public AudioSource ball;
    public AudioSource paddle;
    public AudioSource enemyPaddle;
    //public AudioSource powerUp;
    public AudioClip wall;
    public AudioClip lost;
    public AudioClip powerUp1;
    public AudioClip powerUp2;
    public AudioClip powerUp3;
    private int random;
    void Awake()
    {
        instance = this;
        GameObject.FindGameObjectWithTag("Music").GetComponent<AudioSource>().Stop();
    }

    public void WallSound()
    {
        if (PlayerPrefs.GetInt("soundsOff") == 0)
        {
            //ball.clip = wall;
            ball.pitch = 1;
            ball.PlayOneShot(wall);
        }
    }
    public void PaddleSound()
    {
        if (PlayerPrefs.GetInt("soundsOff") == 0)
        {
            //ball.clip = wall;
            paddle.pitch = 0.7f;
            paddle.PlayOneShot(wall);
        }
    }
    public void EnemyPaddle()
    {
        if(PlayerPrefs.GetInt("soundsOff") == 0)
        {
            enemyPaddle.pitch = 0.7f;
            enemyPaddle.PlayOneShot(wall);
        }
    }
    public void LostSound()
    {
        if (PlayerPrefs.GetInt("soundsOff") == 0)
        {
            //ball.clip =lost;
            paddle.pitch = 1;
            paddle.PlayOneShot(lost);
        }
    }
    public void PowerUpSound()
    {
        if (PlayerPrefs.GetInt("soundsOff") == 0)
        {
            random = Random.Range(1, 3);
            if (random == 1)
            {
                paddle.PlayOneShot(powerUp1);
            }
            else if (random == 2)
            {
                //ball.clip = powerUp2;
                paddle.PlayOneShot(powerUp2);
            }
            else if (random == 3)
            {
                // ball.clip = powerUp3;
                paddle.PlayOneShot(powerUp3);
            }
        }
        
    }
}

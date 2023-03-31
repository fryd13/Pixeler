using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
    public Image purplePaddle, greenPaddle, redPaddle, purpleBall, greenBall,
    redBall, gPaddleCoins, gBallCoins, rBallCoins, rPaddleCoins, 
    frozenPaddle, neonPaddle, woodenPaddle, pokeBall, tenisBall, pokeBlackBall,
    frozenCoins, neonCoins, woodenCoins, pokeCoins, tenisCoins, pokeBlackCoins;

    public Sprite redRamka, greenRamka, purpleRamka;

    int przedZakupem, poZakupie;
    public Animator notEnough;
    
    private void Awake() 
    {
        Ramki();   
    }
    public void GreenPaddle()
    {  
    if(PlayerPrefs.GetInt("kaska") >= 35 && PlayerPrefs.GetInt("KGP") == 0)
        {
            PlayerPrefs.SetInt("KGP", 1);
            Kasa();
            PlayerPrefs.SetInt("Paddle", 1);
            Ramki();

        }else if (PlayerPrefs.GetInt("KGP") == 1)
        {
            PlayerPrefs.SetInt("Paddle", 1);
            Ramki();

        }else
        {
            notEnough.SetTrigger("Not");
        }
    }
    public void GreenBall()
    {
        if(PlayerPrefs.GetInt("kaska") >= 35 && PlayerPrefs.GetInt("KGB") == 0)
        {
            PlayerPrefs.SetInt("KGB", 1);
            Kasa();
            PlayerPrefs.SetInt("Ball", 1);
            Ramki();
        }else if (PlayerPrefs.GetInt("KGB") == 1)
        {
            PlayerPrefs.SetInt("Ball", 1);
            Ramki();
        }else
        {
            notEnough.SetTrigger("Not");
        }
    }
    public void RedBall()
    {
        if(PlayerPrefs.GetInt("kaska") >= 35 && PlayerPrefs.GetInt("KRB") == 0)
        {
            PlayerPrefs.SetInt("KRB", 1);
            Kasa();
            PlayerPrefs.SetInt("Ball", 2);
            Ramki();
        }else if (PlayerPrefs.GetInt("KRB") == 1)
        {
            PlayerPrefs.SetInt("Ball", 2);
            Ramki();
        }else
        {
            notEnough.SetTrigger("Not");
        }
    }
    public void RedPaddle()
    {
        
        if(PlayerPrefs.GetInt("kaska") >= 35 && PlayerPrefs.GetInt("KRP") == 0)
        {
            PlayerPrefs.SetInt("KRP", 1);
            Kasa();
            PlayerPrefs.SetInt("Paddle", 2);
            Ramki();
        }else if (PlayerPrefs.GetInt("KRP") == 1)
        {
            PlayerPrefs.SetInt("Paddle", 2);
            Ramki();
        }else
        {
            notEnough.SetTrigger("Not");
        }
    }
    public void FrozenPaddle()
    {

        if (PlayerPrefs.GetInt("kaska") >= 100 && PlayerPrefs.GetInt("KFP") == 0)
        {
            PlayerPrefs.SetInt("KFP", 1);
            KasaWiecej();
            PlayerPrefs.SetInt("Paddle", 3);
            Ramki();
        }
        else if (PlayerPrefs.GetInt("KFP") == 1)
        {
            PlayerPrefs.SetInt("Paddle", 3);
            Ramki();
        }
        else
        {
            notEnough.SetTrigger("Not");
        }
    }
    public void NeonPaddle()
    {

        if (PlayerPrefs.GetInt("kaska") >= 100 && PlayerPrefs.GetInt("KNP") == 0)
        {
            PlayerPrefs.SetInt("KNP", 1);
            KasaWiecej();
            PlayerPrefs.SetInt("Paddle", 4);
            Ramki();
        }
        else if (PlayerPrefs.GetInt("KNP") == 1)
        {
            PlayerPrefs.SetInt("Paddle", 4);
            Ramki();
        }
        else
        {
            notEnough.SetTrigger("Not");
        }
    }
    public void WoodenPaddle()
    {

        if (PlayerPrefs.GetInt("kaska") >= 100 && PlayerPrefs.GetInt("KWP") == 0)
        {
            PlayerPrefs.SetInt("KWP", 1);
            KasaWiecej();
            PlayerPrefs.SetInt("Paddle", 5);
            Ramki();
        }
        else if (PlayerPrefs.GetInt("KWP") == 1)
        {
            PlayerPrefs.SetInt("Paddle", 5);
            Ramki();
        }
        else
        {
            notEnough.SetTrigger("Not");
        }
    }
    public void PokeBall()
    {
        if (PlayerPrefs.GetInt("kaska") >= 100 && PlayerPrefs.GetInt("KPB") == 0)
        {
            PlayerPrefs.SetInt("KPB", 1);
            KasaWiecej();
            PlayerPrefs.SetInt("Ball", 3);
            Ramki();
        }
        else if (PlayerPrefs.GetInt("KPB") == 1)
        {
            PlayerPrefs.SetInt("Ball", 3);
            Ramki();
        }
        else
        {
            notEnough.SetTrigger("Not");
        }
    }
    public void TenisBall()
    {
        if (PlayerPrefs.GetInt("kaska") >= 100 && PlayerPrefs.GetInt("KTB") == 0)
        {
            PlayerPrefs.SetInt("KTB", 1);
            KasaWiecej();
            PlayerPrefs.SetInt("Ball", 4);
            Ramki();
        }
        else if (PlayerPrefs.GetInt("KTB") == 1)
        {
            PlayerPrefs.SetInt("Ball", 4);
            Ramki();
        }
        else
        {
            notEnough.SetTrigger("Not");
        }
    }
    public void PokeBallBlack()
    {
        if (PlayerPrefs.GetInt("kaska") >= 100 && PlayerPrefs.GetInt("KPBB") == 0)
        {
            PlayerPrefs.SetInt("KPBB", 1);
            KasaWiecej();
            PlayerPrefs.SetInt("Ball", 5);
            Ramki();
        }
        else if (PlayerPrefs.GetInt("KPBB") == 1)
        {
            PlayerPrefs.SetInt("Ball", 5);
            Ramki();
        }
        else
        {
            notEnough.SetTrigger("Not");
        }
    }


    public void PurpleBall()
    {
        PlayerPrefs.SetInt("Ball", 0);
        Ramki();
    }
    public void PurplePaddle()
    {
        PlayerPrefs.SetInt("Paddle", 0);
        Ramki();
    }
    void Ramki()
    {
        //Ustawianie kupionych /niekupionych itemów
       
        if(PlayerPrefs.GetInt("KRP") == 0)
        {
            redPaddle.sprite = redRamka;
        }
        else if (PlayerPrefs.GetInt("KRP") == 1)
        {
            redPaddle.sprite = purpleRamka;
            rPaddleCoins.gameObject.SetActive(false);
        }

        if(PlayerPrefs.GetInt("KRB") == 0)
        {
            redBall.sprite = redRamka;
        }else if (PlayerPrefs.GetInt("KRB") == 1)
        {
            redBall.sprite = purpleRamka;
            rBallCoins.gameObject.SetActive(false);
        }

        
        if(PlayerPrefs.GetInt("KGP") == 0)
        {
            greenPaddle.sprite = redRamka;
        }
        else if (PlayerPrefs.GetInt("KGP") == 1)
        {
            greenPaddle.sprite = purpleRamka;
            gPaddleCoins.gameObject.SetActive(false);
        }

        if(PlayerPrefs.GetInt("KGB") == 0)
        {
            greenBall.sprite = redRamka;
        }else if (PlayerPrefs.GetInt("KGB") == 1)
        {
            greenBall.sprite = purpleRamka;
            gBallCoins.gameObject.SetActive(false);

        }
        if (PlayerPrefs.GetInt("KNP") == 0)
        {
            neonPaddle.sprite = redRamka;
        }
        else if (PlayerPrefs.GetInt("KNP") == 1)
        {
            neonPaddle.sprite = purpleRamka;
            neonCoins.gameObject.SetActive(false);
        }
        if (PlayerPrefs.GetInt("KWP") == 0)
        {
            woodenPaddle.sprite = redRamka;
        }
        else if (PlayerPrefs.GetInt("KWP") == 1)
        {
            woodenPaddle.sprite = purpleRamka;
            woodenCoins.gameObject.SetActive(false);
        }
        if (PlayerPrefs.GetInt("KFP") == 0)
        {
            frozenPaddle.sprite = redRamka;
        }
        else if (PlayerPrefs.GetInt("KFP") == 1)
        {
            frozenPaddle.sprite = purpleRamka;
            frozenCoins.gameObject.SetActive(false);
        }

        if (PlayerPrefs.GetInt("KPB") == 0)
        {
            pokeBall.sprite = redRamka;
        }
        else if (PlayerPrefs.GetInt("KPB") == 1)
        {
            pokeBall.sprite = purpleRamka;
            pokeCoins.gameObject.SetActive(false);
        }
        if (PlayerPrefs.GetInt("KTB") == 0)
        {
            tenisBall.sprite = redRamka;
        }
        else if (PlayerPrefs.GetInt("KTB") == 1)
        {
            tenisBall.sprite = purpleRamka;
            tenisCoins.gameObject.SetActive(false);
        }
        if (PlayerPrefs.GetInt("KPBB") == 0)
        {
            pokeBlackBall.sprite = redRamka;
        }
        else if (PlayerPrefs.GetInt("KPBB") == 1)
        {
            pokeBlackBall.sprite = purpleRamka;
            pokeBlackCoins.gameObject.SetActive(false);
        }

        purpleBall.sprite = purpleRamka;
        purplePaddle.sprite = purpleRamka;

        //Ustawianie Wybranych Itemów
        if(PlayerPrefs.GetInt("Paddle") == 0)
        {
            purplePaddle.sprite = greenRamka;
        }else if(PlayerPrefs.GetInt("Paddle") == 1)
        {
            greenPaddle.sprite = greenRamka;
        }else if(PlayerPrefs.GetInt("Paddle") == 2)
        {
            redPaddle.sprite = greenRamka;
        }
        else if (PlayerPrefs.GetInt("Paddle") == 3)
        {
            frozenPaddle.sprite = greenRamka;
        }
        else if (PlayerPrefs.GetInt("Paddle") == 4)
        {
            neonPaddle.sprite = greenRamka;
        }
        
        else if (PlayerPrefs.GetInt("Paddle") == 5)
        {
            woodenPaddle.sprite = greenRamka;
        }
        

        if (PlayerPrefs.GetInt("Ball") == 0)
        {
            purpleBall.sprite = greenRamka;
        }else if(PlayerPrefs.GetInt("Ball") == 1)
        {
            greenBall.sprite = greenRamka;
        }else if(PlayerPrefs.GetInt("Ball") == 2)
        {
            redBall.sprite = greenRamka;
        }
        else if (PlayerPrefs.GetInt("Ball") == 3)
        {
            pokeBall.sprite = greenRamka;
        }
        else if (PlayerPrefs.GetInt("Ball") == 4)
        {
            tenisBall.sprite = greenRamka;
        }
        else if (PlayerPrefs.GetInt("Ball") == 5)
        {
            pokeBlackBall.sprite = greenRamka;
        }
    }
    void Kasa()
    {
        przedZakupem = PlayerPrefs.GetInt("kaska");
        poZakupie = przedZakupem - 35;
        PlayerPrefs.SetInt("kaska", poZakupie);
    }
    void KasaWiecej(){
        przedZakupem = PlayerPrefs.GetInt("kaska");
        poZakupie = przedZakupem - 100;
        PlayerPrefs.SetInt("kaska", poZakupie);
    }
}

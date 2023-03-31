using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using System;

public class GameManager : MonoBehaviour
{

    public GameObject fullScreenAd;

    public static GameManager instance;

    public Text punkty;
    public static int score;

    public Animator transition;
    public Animator lostAnimator;
    public Animator pkt;
    public Animator youLost;
    public Animator enemyLost;
    public float transitionTime = 1f;
    private string sceneName;

    public static bool canPaddleMove = true;
    public Animator notEnough;

    public GameObject lost;
    public Text kaskaLost;
    public Text kaskaMain;
    public int kaska;
    public int przejsciowy;
    public int kaskaOgolem;

    public TextMeshProUGUI leftRight, toPoint;

    public TextMeshProUGUI punkt;
    public TextMeshProUGUI on, off;
    //Kupno 1v1
    public TextMeshProUGUI buy;



    private void Awake()
    {
        instance = this;
        if(SceneManager.GetActiveScene().name == "Main"){
        kaskaMain.text = PlayerPrefs.GetInt("kaska").ToString();
        if(!GameObject.FindGameObjectWithTag("Music").GetComponent<AudioSource>().isPlaying&& PlayerPrefs.GetInt("soundsOff") == 0)
        {
            GameObject.FindGameObjectWithTag("Music").GetComponent<AudioSource>().Play();
        }
        
        }
        //Zmiana koloru przyciskow od movementu i sound
        if(SceneManager.GetActiveScene().name == "Settings")
        {
            if(PlayerPrefs.GetInt("LR")  == 0)
            {
                toPoint.color = new Color32(212,94,83,255);
                leftRight.color = new Color32(255,255,255,255);
            }else if (PlayerPrefs.GetInt("LR")  == 1)
            {
                leftRight.color = new Color32(212,94,83,255);
                toPoint.color = new Color32(255,255,255,255);
            }
            if (PlayerPrefs.GetInt("soundsOff") == 0){
                on.color = new Color32(212, 94, 83, 255);
                off.color = new Color32(255, 255, 255, 255);
            }else if (PlayerPrefs.GetInt("soundsOff") == 1)
            {
                on.color = new Color32(255, 255, 255, 255);
                off.color = new Color32(212, 94, 83, 255);
            }
        }
       
        if(SceneManager.GetActiveScene().name == "wybor"){
            if (PlayerPrefs.GetInt("1v1") == 0)
            {
                //buy.enabled = true;
                buy.gameObject.SetActive(true);
            }
            else if (PlayerPrefs.GetInt("1v1") == 1)
            {
                //buy.enabled = false;
                buy.gameObject.SetActive(false);
            }
        }
       
        
    }
    public void ScoreMan()
    {
        score++;
        punkt.text = score.ToString();
        if(score % 5 == 0)
        {
            kaska++;
        }        
    }
#region Scenes
    public void Klik()
    {
        sceneName = "wybor";
        StartCoroutine(Tryby(sceneName));
    }
    public void Menu(){
        GoogleMobileAdsBanner.instance.bannerView.Destroy();
        sceneName = "Main";
        StartCoroutine(Tryby(sceneName));
    }
    public void Endless()
    {
        GoogleMobileAdsBanner.instance.bannerView.Destroy();
        sceneName = "G1";
        StartCoroutine(Tryby(sceneName));    
        transition.SetBool("Tapto", true);
    }
    public void AgaintAi()
    {
        GoogleMobileAdsBanner.instance.bannerView.Destroy();
        if (PlayerPrefs.GetInt("kaska") >= 15)
        {
            kaska = -15;
            Save();
            sceneName = "G2";
            StartCoroutine(Tryby(sceneName));
        }else
        {
            notEnough.SetTrigger("Not");
        }   
    }
    public void AgainstPlayer()
    {
        GoogleMobileAdsBanner.instance.bannerView.Destroy();
        if(PlayerPrefs.GetInt("1v1")== 1) 
        {
            sceneName = "G3";
            StartCoroutine(Tryby(sceneName));
        }else{
            if(PlayerPrefs.GetInt("kaska") >= 30){
                PlayerPrefs.SetInt("1v1", 1);
                kaska = -30;
                Save();
                sceneName = "G3";
                StartCoroutine(Tryby(sceneName));
            }
            else{
                notEnough.SetTrigger("Not");
            }
        }
    }
    public void Sklep()
    {
        sceneName = "Shop";
        StartCoroutine(Tryby(sceneName));    

    }
    public void Settings()
    {
        sceneName = "Settings";
        StartCoroutine(Tryby(sceneName));

    }
    public void Credits()
    {
        sceneName = "Credits";
        StartCoroutine(Tryby(sceneName));
    }
    public void Statistics()
    {
        sceneName = "Stats";
        StartCoroutine(Tryby(sceneName));
    }

    IEnumerator Tryby (string sceneName)
    {
      transition.SetTrigger("Start");
      yield return new WaitForSeconds(transitionTime);
      SceneManager.LoadScene(sceneName);
    }
#endregion
#region GameFinished
    public void Lost()
    {
        FullScreenAd();
        lostAnimator.SetTrigger("Lost");
        pkt.SetTrigger("Lost");
        kaskaLost.text = kaska.ToString();
        canPaddleMove = false;
        SpeedOfSpawned.didEnd = true;
        Save();
        //Rekord
        if(score > PlayerPrefs.GetInt("endlessScore")){
            PlayerPrefs.SetInt("endlessScore", score);
        }
    }
    public void EnemyLost()
    {
        FullScreenAd();
        pkt.SetTrigger("Lost");
        enemyLost.SetTrigger("EnemyLost");    
        canPaddleMove = false;
        SpeedOfSpawned.didEnd = true;
        if (SceneManager.GetActiveScene().name == "G2")
        {
            EnemyAi.didEnd = true;
            kaska = 30;
            Save();
            if (score > PlayerPrefs.GetInt("againstScore"))
            {
                PlayerPrefs.SetInt("againstScore", score);
            }
        }else if(SceneManager.GetActiveScene().name == "G3"){
            if (score > PlayerPrefs.GetInt("1v1Score"))
            {
                PlayerPrefs.SetInt("1v1Score", score);
            }
        }
    }
    public void YouLost()
    {
        FullScreenAd();
        pkt.SetTrigger("Lost");
        youLost.SetTrigger("YouLost");      
        canPaddleMove = false;
        SpeedOfSpawned.didEnd = true;
        Save();
        if (SceneManager.GetActiveScene().name == "G2")
        {
            EnemyAi.didEnd = true;
            if (score > PlayerPrefs.GetInt("againstScore"))
            {
                PlayerPrefs.SetInt("againstScore", score);
            }
        }else if (SceneManager.GetActiveScene().name == "G3")
        {
            if (score > PlayerPrefs.GetInt("1v1Score"))
            {
                PlayerPrefs.SetInt("1v1Score", score);
            }
        }
    }
    //Saving money
    void Save()
    {
        przejsciowy = PlayerPrefs.GetInt("kaska");
        kaskaOgolem = kaska + przejsciowy;
        PlayerPrefs.SetInt("kaska", kaskaOgolem);
        kaska = 0;
    } 
    private void FullScreenAd(){
        //Reklama pelnyekran co 4 przegrane
        if (PlayerPrefs.GetInt("reklama") == 3)
        {
            fullScreenAd.GetComponent<GoogleMobileAdsFullScreen>().StartAd();
            PlayerPrefs.SetInt("reklama", 0);
        }
        else if (PlayerPrefs.GetInt("reklama") < 3)
        {
            PlayerPrefs.SetInt("reklama", PlayerPrefs.GetInt("reklama") + 1);
        }
    }
#endregion
#region Movement
    public void MoveLR()
    {
        PlayerPrefs.SetInt("LR", 1);
        leftRight.color = new Color32(212,94,83,255);
        toPoint.color = new Color32(255,255,255,255);
    }
    public void MoveTT()
    {
        PlayerPrefs.SetInt("LR", 0);
        toPoint.color = new Color32(212,94,83,255);
        leftRight.color = new Color32(255,255,255,255);
    }
    #endregion


}

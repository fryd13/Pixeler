using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Languages : MonoBehaviour
{
    public static Languages instance;
    Scene scene;
    public TextMeshProUGUI settings, language, movementType, sounds, play, endless, modes, 
    tapto, nice, tryAgain, youHave, lp, toTouch, polski, english, credits, author, font, music,
    shop,notEnough, againstAI, cost, on, off, highscores, twoPlayers, comingSoon, pOne,pTwo, oneVone;
    //Against AI
    public TextMeshProUGUI youLost, youWon, tryAgainT;


    void Awake()
    {
        instance = this;
        SceneChanged();
    }
    public void English()
    {
        PlayerPrefs.SetInt("Lang", 0);
        SceneChanged();
    }
    public void Polish()
    {
        PlayerPrefs.SetInt("Lang", 1);
        SceneChanged();
    }
    public void SceneChanged()
    {
        scene = SceneManager.GetActiveScene();
        if(PlayerPrefs.GetInt("Lang")  == 0){
            if (scene.name == "Main")
            {
                play.text = "PLAY!";
            }
            else if (scene.name == "Settings")
            {
                settings.text = "SETTINGS";
                language.text = "LANGUAGE";
                movementType.text = "MOVEMENT TYPE";
                sounds.text = "SOUNDS";
                toTouch.text = "TO POINT OF TOUCH";
                lp.text = "LEFT/\nRIGHT";
                on.text = "ON";
                off.text = "OFF";
                english.color = new Color32(212, 94, 83, 255);
                polski.color = new Color32(255, 255, 255, 255);
            }
            else if (scene.name == "wybor")
            {
                endless.text = "ENDLESS";
                modes.text = "GAME MODES";
                againstAI.text = "AGAINST AI";
                notEnough.text = "YOU HAVEN'T GOT ENOUGH MONEY!";
                cost.text = "COST: 15";
                twoPlayers.text = "TWO PLAYERS";
                comingSoon.text = "BUY: 30";
            }
            else if (scene.name == "Shop")
            {
                shop.text = "SHOP";
                notEnough.text = "YOU HAVEN'T GOT ENOUGH MONEY!";
            }
            else if (scene.name == "G1")
            {
                tapto.text = "TAP TO START";
                nice.text = "NICE TRY!";
                tryAgain.text = "TRY AGAIN!";
                youHave.text = "YOU HAVE EARNED:";
            }
            else if (scene.name == "G2")
            {
                youWon.text = "YOU WON!";
                youLost.text = "ALMOST!";
                tryAgain.text = "TRY AGAIN!";
                tryAgainT.text = "TRY AGAIN!";
                notEnough.text = "YOU HAVEN'T GOT ENOUGH MONEY!";
            }else if (scene.name == "G3")
            {
                pOne.text = "GREEN PLAYER WON!";
                pTwo.text = "RED PLAYER WON!";
                tryAgain.text = "TRY AGAIN!";
                tryAgainT.text = "TRY AGAIN!";
            }
            else if (scene.name == "Credits")
            {            
                font.text = "FONT";
                author.text = "AUTHOR";
                music.text = "MUSIC";
                credits.text = "INFO";
             }else if (scene.name == "Shop")
             {
                 shop.text = "SHOP";
                 notEnough.text = "YOU HAVEN'T GOT ENOUGH MONEY!";
             }else if (scene.name == "Stats")
            {
                highscores.text = "HIGHSCORES";
                endless.text = "ENDLESS: " + PlayerPrefs.GetInt("endlessScore"); ;
                againstAI.text = "AGAINST AI: " + PlayerPrefs.GetInt("againstScore");
                oneVone.text = "1v1: " + PlayerPrefs.GetInt("1v1Score");
            }
        }
        else if (PlayerPrefs.GetInt("Lang")  == 1)
        {
            if(scene.name == "Main")
            {
                play.text = "GRAJ!";
            }
            else if (scene.name == "Settings")
            {
                settings.text = "USTAWIENIA";
                language.text = "JEZYK";
                movementType.text = "TRYB PORUSZANIA";
                sounds.text = "DZWIEK";
                toTouch.text  = "DO MIEJSCA DOTYKU";
                lp.text = "LEWO/\nPRAWO";
                on.text = "WL";
                off.text = "WYL";
                polski.color = new Color32(212,94,83,255);
                english.color = new Color32(255,255,255,255);

            }
            else if (scene.name == "wybor")
            {
                endless.text = "BEZ KONCA";
                modes.text = "TRYBY GRY";
                againstAI.text = "PRZECIWKO AI";
                notEnough.text = "NIE MASZ WYSTARCZAJACEJ ILOSCI MONET";
                cost.text = "KOSZT: 15";
                twoPlayers.text = "DWOCH GRACZY";
                comingSoon.text = "KUP: 30";
            }
            else if (scene.name == "Shop")
            {
                shop.text = "SKLEP";
                notEnough.text = "NIE MASZ WYSTARCZAJACEJ ILOSCI MONET";
            }
            else if (scene.name == "G1")
            {
                tapto.text = "KLIKNIJ ABY ROZPOCZAC";
                nice.text = "NIEZLE!";
                tryAgain.text = "SPROBUJ PONOWNIE!";
                youHave.text = "ZDOBYWASZ";

            }else if (scene.name == "G2")
            {
                youWon.text = "ZWYCIESTWO!";
                youLost.text = "BYLO BLISKO!";
                tryAgain.text = "SPROBUJ PONOWNIE!";
                tryAgainT.text = "SPROBUJ PONOWNIE!";
                notEnough.text = "NIE MASZ WYSTARCZAJACEJ ILOSCI MONET";
            }else if(scene.name == "G3"){
                pOne.text = "GRACZ ZIELONY WYGRAL!";
                pTwo.text = "GRACZ CZERWONY WYGRAL!";
                tryAgain.text = "SPROBUJ PONOWNIE!";
                tryAgainT.text = "SPROBUJ PONOWNIE!";
            }
            else if (scene.name == "Credits")
            {
                font.text = "CZCIONKA";
                author.text = "AUTOR";
                music.text = "MUZYKA";
                credits.text = "INFO";
            }else if (scene.name == "Shop")
             {
                 shop.text = "SKLEP";
                 notEnough.text = "NIE MASZ WYSTARCZAJACEJ ILOSCI PIENIEDZY!";
             }
            else if (scene.name == "Stats")
            {
                highscores.text = "REKORDY";
                endless.text = "BEZ KONCA: "+ PlayerPrefs.GetInt("endlessScore");
                againstAI.text = "PRZECIWKO AI: " + PlayerPrefs.GetInt("againstScore");
                oneVone.text = "1v1: " + PlayerPrefs.GetInt("1v1Score");
            }
        } 
    }                  
}

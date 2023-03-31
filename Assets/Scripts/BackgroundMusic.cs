using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
 public class BackgroundMusic : MonoBehaviour
 {
     private static BackgroundMusic instance;
 
     void Awake(){
  
        if (instance != null && instance != this){
            Destroy(this.gameObject);
            return;
        }
        else{
            instance = this;
        }
        DontDestroyOnLoad(this.gameObject);
     }
 
     public void turnMusicOff()
     {
        if (instance != null)
        {
            Destroy(this.gameObject);
            instance = null;
        }
     }
    void OnApplicationQuit()
    {
        instance = null;
    }
        /*
     void Scene()
     {
        if(SceneManager.GetActiveScene().name == "G1")
        {
            instance.GetComponent<AudioSource>().Stop();
        }else if(SceneManager.GetActiveScene().name == "G2"){
            instance.GetComponent<AudioSource>().Stop();
        }  
     }
     */
}
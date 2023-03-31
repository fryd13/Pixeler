using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpawner : MonoBehaviour
{

    private int dodawanie;
    private int spawnOnScore;
    public int spawnObjectId;

    public GameObject size;
    public GameObject slowBall;
    public GameObject coinBonus;
    public GameObject fastBall;
    public GameObject random;
    Vector2 spawnOn;  

    void Start()
    {
        spawnOnScore = Random.Range(1, 3);
    }

    void Update()
    {
        if(GameManager.score == spawnOnScore){
            spawnOn = new Vector2(Random.Range(-1.1f, 1.1f), 6);
            spawnObjectId = Random.Range(0,5);
            Spawner();
            dodawanie = Random.Range(1,3);
            spawnOnScore += dodawanie;
        } 
    }
    void Spawner()
    {        
        if(spawnObjectId == 0){
             Instantiate(random, spawnOn, Quaternion.identity);
        }
        if(spawnObjectId == 1)
        {
            Instantiate(size, spawnOn, Quaternion.identity);
        }
        if(spawnObjectId == 2){
             Instantiate(slowBall, spawnOn, Quaternion.identity);
        }
        if(spawnObjectId == 3){
             Instantiate(coinBonus, spawnOn, Quaternion.identity);
        }
        if(spawnObjectId == 4){
             Instantiate(fastBall, spawnOn, Quaternion.identity);
        }
    }
}

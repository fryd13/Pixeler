using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedOfSpawned : MonoBehaviour
{    
    Vector2 speed;
    public static bool didEnd;
    BoxCollider2D coll;
    int  y;
    private void Awake() {
        coll = GetComponent<BoxCollider2D>();
        y = Random.Range(-2, -4);
        speed = new Vector2(0, y);
        didEnd = false; 
}
    
    void Update()
    {
        if(!didEnd)
        {
            transform.position = new Vector2(transform.position.x, transform.position.y + speed.y * Time.deltaTime);
        }
    }
    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.tag=="Lose")
       {
           Debug.Log("Naura");
           Destroy(this.gameObject);
       }
    }
}

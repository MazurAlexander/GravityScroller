using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformContorller : MonoBehaviour
{

    public void PlatformSpeed()
    {
        GetComponent<Rigidbody2D>().velocity = new Vector2(-70, 0);
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {

        Destroy(gameObject);
        GameController.I.platformList.Remove(this);
        GameController.I.createCount--;
        GameController.I.score++;
        GameController.I.Score();


    }

    void Start()
    {

        PlatformSpeed();

    }
}

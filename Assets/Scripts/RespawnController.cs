using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnController : MonoBehaviour {

    public GameObject BottomCollider;
    public GameObject TopColldier;


    private void CreateBottomCollider() {

        BottomCollider.GetComponent<BoxCollider2D>().size = new Vector2(Screen.width, Screen.height / 8);
        BottomCollider.transform.position = new Vector2(Screen.width / 2, Screen.height / 16);

    }

    private void CreateTopCollider() {

        TopColldier.GetComponent<BoxCollider2D>().size = new Vector2(Screen.width, Screen.height / 8);
        TopColldier.transform.position = new Vector2(Screen.width / 2, Screen.height - Screen.height / 16);
    }

    private void CreateDestrtoyColl()
    {

        GameObject LeftCollider = new GameObject();
        LeftCollider.gameObject.AddComponent<BoxCollider2D>();
        LeftCollider.name = "DestroyColl";
        LeftCollider.GetComponent<BoxCollider2D>().size = new Vector2(1, Screen.height);
        LeftCollider.GetComponent<BoxCollider2D>().isTrigger = true;
        LeftCollider.transform.position = new Vector2(-250, Screen.height / 2);
    }

    public void DestoyAll()
    {
        Destroy(BottomCollider);
        Destroy(TopColldier);

     }
    private void Start()
    {
        CreateBottomCollider();
        CreateTopCollider();
        CreateDestrtoyColl();
    }

}

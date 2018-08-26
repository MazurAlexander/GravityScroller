using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class BallContoller : MonoBehaviour, IEndDragHandler, IBeginDragHandler, IDragHandler
{

    private bool ChangeGrav = true;



    public void OnBeginDrag(PointerEventData eventData)
    {
        if (ChangeGrav)
        {
            Physics2D.gravity = new Vector3(0f, 50f, 0f);
            ChangeGrav = false;
        }
        else
        {
            Physics2D.gravity = new Vector3(0f, -50f, 0f);
            ChangeGrav = true;
        }

    }
    public void OnEndDrag(PointerEventData eventData)
    {

    }

    public void OnDrag(PointerEventData eventData)
    {

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Respawn"))
        {
            Destroy(gameObject);
            GameController.I.CheckScore();
            GameController.I.ClearCanvas();
            GameController.I.score = 0;
            GameController.I.GameOver();

            Physics2D.gravity = new Vector3(0f, -50f, 0f);

        }
    }


    void Start()
    {


    }

    void Update()
    {
         if (Input.GetMouseButtonDown(0))
        {

            if (ChangeGrav)
            {
                Physics2D.gravity = new Vector3(0f, 50f, 0f);
                ChangeGrav = false;
            }
            else
            {
                Physics2D.gravity = new Vector3(0f, -50f, 0f);
                ChangeGrav = true;
            }
        }
    }
}




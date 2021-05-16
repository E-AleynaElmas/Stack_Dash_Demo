using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwipeDetection : MonoBehaviour
{
    public PlayerController player;
    private Vector2 startPos;
    public int pixelDistToDetect = 20;
    private bool fingerDown;

    void Update()
    {
        //For finger to mobile
        //if (fingerDown == false && Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Began)
        //{
        //    startPos = Input.touches[0].position;
        //    fingerDown = true;
        //}

        //if (fingerDown)
        //{
        //    if (Input.touches[0].position.y >= startPos.y + pixelDistToDetect)
        //    {
        //        fingerDown = false;
        //        player.Slide("up");
        //        Debug.Log("Swipe up");
        //    }

        //    else if (Input.touches[0].position.y <= startPos.y - pixelDistToDetect)
        //    {
        //        fingerDown = false;
        //        player.Slide("down");
        //        Debug.Log("Swipe down");
        //    }

        //    else if(Input.touches[0].position.x <= startPos.x - pixelDistToDetect)
        //    {
        //        fingerDown = false;
        //        player.Slide("left");
        //        Debug.Log("Swipe left");
        //    }

        //    else if(Input.touches[0].position.x >= startPos.y + pixelDistToDetect)
        //    {
        //        fingerDown = false;
        //        player.Slide("right");
        //        Debug.Log("Swipe right");
        //    }
        //}

        //if(fingerDown && Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Ended)
        //{
        //    fingerDown = false;
        //}

        //Testing for pc

        if (fingerDown == false && Input.GetMouseButtonDown(0))
        {
            startPos = Input.mousePosition;
            fingerDown = true;
        }

        if (fingerDown)
        {
            if(Input.mousePosition.y >= startPos.y + pixelDistToDetect)
            {
                fingerDown = false;
                player.Slide("up");
                Debug.Log("Swipe up");
            }

            else if (Input.mousePosition.y <= startPos.y - pixelDistToDetect)
            {
                fingerDown = false;
                player.Slide("down");
                Debug.Log("Swipe down");
            }

            else if (Input.mousePosition.x >= startPos.x + pixelDistToDetect)
            {
                fingerDown = false;
                player.Slide("right");
                Debug.Log("Swipe right");
            }

            else if (Input.mousePosition.x <= startPos.x - pixelDistToDetect)
            {
                fingerDown = false;
                player.Slide("left");
                Debug.Log("Swipe left");
            }
        }

        if(fingerDown && Input.GetMouseButtonUp(0))
        {
            fingerDown = false;
        }

    }
}

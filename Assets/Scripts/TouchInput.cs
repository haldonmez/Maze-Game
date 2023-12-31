using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchInput : MonoBehaviour
{
    public CharacterMovement player;
    private Vector2 startPosition;
    public int PixelDistanceToDetect = 20;
    private bool fingerDown;


    private void Update()
    {
        if (fingerDown == false && Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Began)
        {
            startPosition = Input.touches[0].position;
            fingerDown = true;
        }

        if (fingerDown)
        {
            if (Input.touches[0].position.y >= startPosition.y + PixelDistanceToDetect && player.canDash)
            {
                fingerDown = false;
                Debug.Log("Swiped up");
                StartCoroutine(player.DashUp());
            }
            else if (Input.touches[0].position.y <= startPosition.y - PixelDistanceToDetect && player.canDash)
            {
                fingerDown = false;
                Debug.Log("Swiped down");
                StartCoroutine(player.DashDown());
            }
            else if (Input.touches[0].position.x >= startPosition.x + PixelDistanceToDetect && player.canDash)
            {
                fingerDown = false;
                Debug.Log("Swiped Right");
                StartCoroutine(player.DashRight());
            }
            else if (Input.touches[0].position.x <= startPosition.x - PixelDistanceToDetect && player.canDash)
            {
                fingerDown = false;
                Debug.Log("Swiped Left");
                StartCoroutine(player.DashLeft());
            }

        }
        
        if(fingerDown && Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Ended)
        {
            fingerDown = false;
        }

        //TESTING FOR PC

        if(fingerDown == false && Input.GetMouseButtonDown(0))
        {
            startPosition = Input.mousePosition;
            fingerDown = true;
        }

        if(fingerDown)
        {
            if(Input.mousePosition.y >= startPosition.y + PixelDistanceToDetect)
            {
                fingerDown = false;
                Debug.Log("Swiped up on a Computer.");
            }
        }

        if(fingerDown && Input.GetMouseButtonUp(0))
        {
            fingerDown = false;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using Valve.VR.InteractionSystem;


public class ThumbStickInput : MonoBehaviour
{

    public SteamVR_Action_Boolean thumbstickPressed
    = SteamVR_Input.GetAction<SteamVR_Action_Boolean>("default", "PressDown");
    public SteamVR_Action_Vector2 Swipe
    =  SteamVR_Input.GetAction<SteamVR_Action_Vector2>("default", "ThumbStickInput");
    public Hand hand;

    public float sensitivity = 0.5f;
    //swipe

    public float swipeSum;
    public float touchLast;
    public float touchCurrent;
    public float distance;

  //public float thumbH;
    public float thumbV;
    public bool hasSwipedLeft;
    public bool hasSwipedRight;
    public bool hasSwipedUp;
    public bool hasSwipedDown;
    
    

    public ObjectMenuManager ObjectMenuManager;


    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (thumbstickPressed.stateUp)
        {
            touchCurrent = Swipe.GetLastAxis(hand.handType).x;
            thumbV = Swipe.GetLastAxis(hand.handType).y;

            if(Swipe[SteamVR_Input_Sources.RightHand].axis != Vector2.zero)
            {
               // touchLast = Swipe[SteamVR_Input_Sources.RightHand].axis.x;
               // touchCurrent = touchLast;
                distance = touchCurrent - touchLast;
                touchLast = touchCurrent;
                swipeSum += distance;
            }
            if (!hasSwipedLeft)
        {
            if (swipeSum < -0.5f)
            {
                swipeSum = 0;
                SwipeLeft();
                hasSwipedLeft = true;
                hasSwipedRight = false;
            }
        }
        if (!hasSwipedRight)
        {
            if(swipeSum > 0.5f)
            {
                swipeSum = 0;
                SwipeRight();
                hasSwipedLeft = false;
                hasSwipedRight = true;
                
            }
        }
        if (Swipe[SteamVR_Input_Sources.RightHand].axis == Vector2.zero)
        {
            swipeSum = 0;
            touchCurrent = 0;
            touchLast = 0;
            hasSwipedLeft = false;
            hasSwipedRight = false;
        }
        if (thumbstickPressed.stateDown)
        {
            SpawnObject();
        }
    }

   }

  //  private void OnTriggerStay(Collider col)
  //  {
   //     if (col.gameObject.CompareTag("Structure"))
    //    {
     //       if (thumbstickPressed[SteamVR_Input_Sources.Any].stateDown)
     //       {
      //          GrabObject(col);
      //      }else if (thumbstickPressed[SteamVR_Input_Sources.Any].stateUp)
      //      {
       //         PlaceObject(col);
        //    }
      //  }
  //  }

   // void GrabObject(Collider col)
  //  {
   //     col.transform.SetParent(gameObject.transform);
   //     col.GetComponent<Rigidbody>().isKinematic = true;

   // }

  //  void PlaceObject(Collider col)
   // {
    //    col.transform.parent = null;
   // }

    void SpawnObject()
    {
        ObjectMenuManager.SpawnCurrentObject();
    }

    void SwipeLeft()
    {
        ObjectMenuManager.MenuLeft();
        Debug.Log("SwipeLeft");
    }

    void SwipeRight()
    {
        ObjectMenuManager.MenuRight();
        Debug.Log("SwipeRight");
    }

  

}
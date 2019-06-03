using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using Valve.VR.InteractionSystem;

public class ObjectMenuManager : MonoBehaviour {

    public List<GameObject> objectList; // handled automatically at start

    public List<GameObject> objectPrefabList; // set manually in inspector and MUST match order of scene menu objects

    public int currentObject = 0;


    public bool isActive = false;





    void Start()
    {


        // Generate the list of objects

        foreach (Transform child in transform)
        {

            objectList.Add(child.gameObject);

        }



        // hide all objects 

        foreach (GameObject obj in objectList)
        {

            obj.SetActive(false);

        }



    }


    public void MenuLeft()
    {

        objectList[currentObject].SetActive(false);

        currentObject--;

        if (currentObject < 0)
        {

            currentObject = objectList.Count - 1;

        }

        objectList[currentObject].SetActive(true);



    }



    public void MenuRight()
    {

        objectList[currentObject].SetActive(false);

        currentObject++;

        if (currentObject > objectList.Count - 1)
        {

            currentObject = 0;

        }

        objectList[currentObject].SetActive(true);



    }


    //Spawn objects
    public void SpawnCurrentObject()
    {

        GameObject spawnObject = Instantiate(objectPrefabList[currentObject],

             objectList[currentObject].transform.position,

             objectList[currentObject].transform.rotation);

    }




}

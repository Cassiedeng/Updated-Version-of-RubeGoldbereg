using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collectible : MonoBehaviour {

    private Goal goal;

    void OnTriggerEnter(Collider col)
    {
        GameObject obj = col.gameObject;
        if(obj.name == "Ball")
        {
            collectItem();
            this.gameObject.SetActive(false);
        }
    }

    void collectItem()
    {
        goal.decrementCounter();
    }
}

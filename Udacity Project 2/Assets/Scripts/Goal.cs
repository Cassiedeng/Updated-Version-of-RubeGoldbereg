using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using Valve.VR.InteractionSystem;

public class Goal : MonoBehaviour {

    public SteamVR_LoadLevel loadLevel;

    [SerializeField]
    public List<GameObject> collectibleList;//hold collectible prefabs
    private bool levelCompleted = false;

    private static int availableCollectibles;
    public int AvailableCollectibles
    {
        get
        {
            return availableCollectibles;
        }
        set
        {
            availableCollectibles = value;
        }
    }

	// Use this for initialization
	void Start () {
        resetCounter();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public int getAvailableCollectibles()
    {
        return availableCollectibles;
    }

    public void resetCounter()
    {
        AvailableCollectibles = collectibleList.Count;
    }

    public void decrementCounter()
    {
        AvailableCollectibles--;
    }

    private void sceneLoad(string nextScene)
    {
        if (levelCompleted)
        {
            SteamVR_LoadLevel.Begin(nextScene);
        }
    }

    private void checkStatus()
    {
        if(getAvailableCollectibles() == 0)
        {
            levelCompleted = true;
            loadLevel.Trigger();
        }
    }
}

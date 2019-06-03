using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BallReset : MonoBehaviour {

    public Vector3 originPos;
    public Rigidbody rigidbody;
    SphereCollider BallCollider;
    private Goal goal;
    


    public GameObject platform;

	// Use this for initialization
	void Start () {
        rigidbody = GetComponent<Rigidbody>();
        originPos = gameObject.transform.position;
        BallCollider = GetComponent<SphereCollider>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.CompareTag("Ground"))
        {
            Reset();
            ResetCollectibles();
        }
    }

    void Reset()
    {
        rigidbody.velocity = new Vector3(0, 0, 0);
        rigidbody.angularVelocity = new Vector3(0, 0, 0);
        gameObject.transform.position = originPos;
    }

    public void DisableBall()
    {
        BallCollider.enabled = false;
    }

    public void EnableBall()
    {
        BallCollider.enabled = true;
    }

    void ResetCollectibles()
    {
        goal.resetCounter();
        foreach(GameObject collectible in goal.collectibleList)
        {
            if (!collectible.activeSelf)
            {
                collectible.SetActive(true);
            }
        }
    }
}

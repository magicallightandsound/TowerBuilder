using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActsAsColliderPlatform : MonoBehaviour {

    [SerializeField]
    public int gameOverFallenBlockCount = 4;

    
    public delegate void TowerHasFallen(Collider collider);
    public static event TowerHasFallen OnTowerHasFallen;

    private int fallenBlockCount = 0;

    private void Awake()
    {

    }

    // Use this for initialization
    void Start () {
		

	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnTriggerEnter(Collider collider)
    {
        Debug.Log("OnTriggerEnter");

        fallenBlockCount += 1;

        if (fallenBlockCount == gameOverFallenBlockCount)
        {
            fallenBlockCount = 0;
            OnTowerHasFallen(collider);
        }
    }

}

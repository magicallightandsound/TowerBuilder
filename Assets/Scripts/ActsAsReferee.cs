using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActsAsReferee : MonoBehaviour {


    [SerializeField]
    GameObject colliderPlatform = null;

    private void Awake()
    {
        ActsAsColliderPlatform actsAsColliderPlatform = colliderPlatform.GetComponent<ActsAsColliderPlatform>();
        ActsAsColliderPlatform.OnTowerHasFallen += OnTowerHasFallen;
    }
    // Use this for initialization
    void Start () {

    }

    private void OnDestroy()
    {
        ActsAsColliderPlatform.OnTowerHasFallen -= OnTowerHasFallen;
    }

    // Update is called once per frame
    void Update () {
		
	}

    public void OnTowerHasFallen(Collider collider)
    {
        Debug.Log("Tower has fallen, game over");

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActsAsPlatform : MonoBehaviour {

	// Use this for initialization
	void Start () {

        // Give the game object Physics
        this.gameObject.AddComponent<Rigidbody>();
        
        var rigidBody = this.gameObject.GetComponent<Rigidbody>();

        // Do not allow other Rigidbodies to affect the Platform
        rigidBody.isKinematic = true;

        rigidBody.constraints = RigidbodyConstraints.FreezeAll;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}

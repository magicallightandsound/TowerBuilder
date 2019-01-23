using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActsAsRotatingMarker : MonoBehaviour {

    [SerializeField]
    public float timeout = .15f;
    public float degrees = 6f;

    private float timeSinceLastRequest = 0f;
    
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        timeSinceLastRequest += Time.deltaTime;
        if (timeSinceLastRequest > timeout)
        {
            timeSinceLastRequest = 0f;

            // Rotate around the Y axis, 
            transform.Rotate(new Vector3(0, 1, 0), degrees);
        }
    }
}

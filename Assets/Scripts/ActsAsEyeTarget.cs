using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActsAsEyeTarget : MonoBehaviour {

    public bool debugMode = false;

    public bool coolDown = false;

    private float timeSinceLastRequest = 0F;
    public float timeout = 1F;

    [SerializeField]
    private float cooldownDelta = -0.01F;

    [SerializeField]
    public float heatupDelta = 0.01F;


    private Vector3 initialScale;
    private Vector3 maxScale;
    private bool maxHeat = false;
    private bool hasBeenTargetted = false;

    // Use this for initialization
    void Start () {
        initialScale = gameObject.transform.localScale;
        maxScale = new Vector3(initialScale.x, initialScale.y, initialScale.z);

        hasBeenTargetted = debugMode;
    }
	
	// Update is called once per frame
	void Update () {

        if (maxHeat || !hasBeenTargetted)
        {
            return;
        }

        if (coolDown)
        {
            timeSinceLastRequest -= Time.deltaTime;

            // Animated Cooldown 
            Vector3 scale = this.gameObject.transform.localScale;
            scale.y += cooldownDelta;
            this.gameObject.transform.localScale = scale;
        }
        else
        {
            timeSinceLastRequest += Time.deltaTime;

            // Animated Heatup
            Vector3 scale = this.gameObject.transform.localScale;
            scale.y += heatupDelta;
            this.gameObject.transform.localScale = scale;
        }

        if (timeSinceLastRequest < 0)
        {
            // Animate full cold
            this.gameObject.transform.localScale = initialScale;

            timeSinceLastRequest = 0f;

            if (debugMode)
            {
                coolDown = false;   
            }
        }


        if (timeSinceLastRequest > timeout)
        {
            if (debugMode)
            {
                coolDown = true;
                return;
            }

            maxHeat = true;
        }
    }

    // Called by the ActsAsEyeTracker, when this ActsAsTarget is
    // being targetted by the ActsAsEyeTracker raycast
    public void OnTarget()
    {
        hasBeenTargetted = true;
        coolDown = false;
    }

    // Called by the ActsAsEyeTracker, when this ActsAsTarget is
    // being no longer targetted by the ActsAsEyeTracker raycast
    public void OffTarget()
    {
        coolDown = true;
    }
}

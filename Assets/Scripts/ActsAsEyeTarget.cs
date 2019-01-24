using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActsAsEyeTarget : MonoBehaviour {

    public bool coolDown = false;

    private float timeSinceLastRequest = 0F;
    private float timeout = 3F;

    [SerializeField]
    private float cooldownDelta = -0.1F;

    [SerializeField]
    public float heatupDelta = 0.1F;


    private Vector3 initialScale;
    private Vector3 maxScale;

    // Use this for initialization
    void Start () {
        initialScale = gameObject.transform.localScale;
        maxScale = new Vector3(initialScale.x, initialScale.y, initialScale.z);
    }
	
	// Update is called once per frame
	void Update () {
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
            return;
        }


        if (timeSinceLastRequest > timeout)
        {
            // Animated full heat
            this.gameObject.transform.localScale = maxScale;
            timeSinceLastRequest = 0f;
        }
    }

    // Called by the ActsAsEyeTracker, when this ActsAsTarget is
    // being targetted by the ActsAsEyeTracker raycast
    public void OnTarget()
    {
        coolDown = false;
    }

    // Called by the ActsAsEyeTracker, when this ActsAsTarget is
    // being no longer targetted by the ActsAsEyeTracker raycast
    public void OffTarget()
    {
        coolDown = true;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.MagicLeap;


public class ActsAsEyeTracker : MonoBehaviour {

    [SerializeField]
    public int hitLayer;

    private ActsAsEyeTarget currentActsAsEyeTarget = null;

    // Use this for initialization
    void Start () {
		
	}

    private void OnEnable()
    {
        if (!MLEyes.IsStarted)
        {
            MLEyes.Start();
        }
    }

    private void OnDisable()
    {
        if (MLEyes.IsStarted)
        {
            MLEyes.Stop();
        }
    }

    // Update is called once per frame
    void Update () {

        if (MLEyes.FixationPoint == null)
        {
            return;
        }

        Vector3 eyetrackerDirection = (MLEyes.FixationPoint - Camera.main.transform.position).normalized;

        // Bit shift the index of the layer (hitLayer) to get a bit mask
        int layerMask = 1 << hitLayer;

        RaycastHit raycastHit;
        bool hit = Physics.Raycast(Camera.main.transform.position, eyetrackerDirection, out raycastHit, Mathf.Infinity, layerMask);

        if (hit)
        {
            Rigidbody rigidbody = raycastHit.rigidbody;
            GameObject go = rigidbody.GetComponent<GameObject>();
            ActsAsEyeTarget actsAsEyeTarget = go.GetComponent<ActsAsEyeTarget>();
            if (actsAsEyeTarget)
            {
                if (currentActsAsEyeTarget && (currentActsAsEyeTarget.GetInstanceID() != actsAsEyeTarget.GetInstanceID()))
                {
                    currentActsAsEyeTarget.OffTarget(); // Cool down the eye target object, that was previously looked at
                    currentActsAsEyeTarget = actsAsEyeTarget;
                }
                actsAsEyeTarget.OnTarget(); // Heat up the eye target object, that is now being looked at
            }
            
        }
    }
}

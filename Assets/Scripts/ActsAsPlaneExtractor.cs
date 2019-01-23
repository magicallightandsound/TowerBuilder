using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.MagicLeap;

public class ActsAsPlaneExtractor : MonoBehaviour {

    [SerializeField]
    public GameObject planePrefab;

    public ArrayList mlPlanes = null;
    public float timeSinceLastRequest = 0f;
    public float timeout = 5f;
    public MLWorldPlanesQueryParams queryParms;
    public uint maxPlaneResults = 100;
    public float minPlaneArea = 0.25F; // 1/4 square meter
    public float minHoleLength = 0;


    private void Awake()
    {
       
        this.mlPlanes = new ArrayList();    
    }

    // Use this for initialization
    void Start () {
        if (MagicLeapDevice.IsReady())
        {

            
            queryParms.Flags = FilterForInnerHorizontalPlanes();
            queryParms.MaxResults = maxPlaneResults;
            queryParms.MinPlaneArea = minPlaneArea; 
            queryParms.MinHoleLength = minHoleLength;

            MLWorldPlanes.Start();
        }
        
	}

    private void OnDestroy()
    {
        if (MLWorldPlanes.IsStarted)
        {
            MLWorldPlanes.Stop();
        }
    }

    // Update is called once per frame
    void Update () {
        timeSinceLastRequest += Time.deltaTime;
        if (timeSinceLastRequest > timeout)
        {
            timeSinceLastRequest = 0f;

            // Update the query with the latest Camera position
            queryParms.BoundsCenter = Camera.main.transform.position;
            queryParms.BoundsExtents = new Vector3(1, 1, 1);
            queryParms.BoundsRotation = Camera.main.transform.rotation;

            MLWorldPlanes.GetPlanes(queryParms, HandleOnReceivedPlanes);
        }
    }

    private void HandleOnReceivedPlanes(MLResult result, MLWorldPlane[] planes, MLWorldPlaneBoundaries[] boundaries)
    {
        for (int i = mlPlanes.Count - 1; i >= 0; --i)
        {
            Destroy(mlPlanes[i] as GameObject);
            mlPlanes.Remove(mlPlanes[i]);
        }

        GameObject newPlane;
        for (int i = 0; i < planes.Length; ++i)
        {
            newPlane = Instantiate(planePrefab);
            newPlane.transform.position = planes[i].Center;
            newPlane.transform.rotation = planes[i].Rotation;
            newPlane.transform.localScale = new Vector3(planes[i].Width, planes[i].Height, 1f); // Set plane scale
            mlPlanes.Add(newPlane);
        }

    }

    public MLWorldPlanesQueryFlags FilterForInnerHorizontalPlanes()
    {
        return (MLWorldPlanesQueryFlags.Horizontal |
        MLWorldPlanesQueryFlags.Inner);
    }
    public bool IsMagicLeapEnabled()
    {
        return MLWorldPlanes.IsStarted;
    }

    public void DebugAwake()
    {
        Awake();
    }
}

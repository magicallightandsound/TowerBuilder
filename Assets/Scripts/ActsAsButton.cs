using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActsAsButton : MonoBehaviour
{
    [SerializeField]
    public int identifier = 0;

    public delegate void ButtonTriggered(int buttonIdentifier);
    public static event ButtonTriggered OnButtonTriggered;


    // When eventCount is 2, then a trigger down and up has occured
    private int eventCount = 0;
    private int maxEventCount = 2;
    private bool isOnHover = false;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }


    protected void OnEnable()
    {
        ActsAsCursor.OnCursorHover += OnCursorHover;
        ActsAsCursor.OnCursorStopHover += OnCursorStopHover;

        ActsAsInputController.OnTriggerDown += OnTriggerDown;
        ActsAsInputController.OnTriggerUp += OnTriggerUp;
    }

    protected void OnDisable()
    {
        ActsAsInputController.OnTriggerDown -= OnTriggerDown;
        ActsAsInputController.OnTriggerUp -= OnTriggerUp;

        ActsAsCursor.OnCursorHover -= OnCursorHover;
        ActsAsCursor.OnCursorStopHover -= OnCursorStopHover;
    }

    // These are called by Input Controller


    public void OnCursorHover(GameObject gameObject, Transform cursorTransform, RaycastHit raycastHit)
    {

        ///
        /// Return if we are not the gameObject that is being hovered by the Cursor
        ///
        if (this.gameObject.GetInstanceID() != gameObject.GetInstanceID())
        {
            return;
        }

        isOnHover = true;

    }

    public void OnCursorStopHover(GameObject gameObject)
    {
        // Cursor has stopped hovering over the button
        eventCount = 0;
        isOnHover = false;
    }


    public void OnTriggerDown(byte controllerId, float value, GameObject gameObject, Transform cursorTransform)
    {
        if (isOnHover == true)
        {
            eventCount += 1;
        }
        
    }

    public void OnTriggerUp(byte controllerId, float value, GameObject gameObject, Transform cursorTransform)
    {
        if (isOnHover == true)
        {
            eventCount += 1;

            if (eventCount >= maxEventCount)
            {
                Debug.Log("ActsAsButton::OnTriggerUp");
                OnButtonTriggered(identifier);
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActsAsGameMenu : MonoBehaviour {


    [SerializeField]
    public GameObject startButton = null;

    [SerializeField]
    public GameObject exitButton = null;


    const int startButtonIdentifier = 100;
    const int exitButtonIdentifier = 101;

    // Use this for initialization
    void Start () {

        startButton.AddComponent<ActsAsButton>();
        ActsAsButton actsAsStartButton = startButton.GetComponent<ActsAsButton>();
        actsAsStartButton.identifier = startButtonIdentifier;

        exitButton.AddComponent<ActsAsButton>();
        ActsAsButton actsAsExitButton = startButton.GetComponent<ActsAsButton>();
        actsAsStartButton.identifier = exitButtonIdentifier;
    }
	
	// Update is called once per frame
	void Update () {
		
	}


    private void OnEnable()
    {
        ActsAsButton.OnButtonTriggered += OnButtonTriggered;
    }

    private void OnDisable()
    {
        ActsAsButton.OnButtonTriggered -= OnButtonTriggered;
    }

    void OnButtonTriggered(int buttonIdentifier)
    {
        switch (buttonIdentifier)
        {
            case startButtonIdentifier:
                {
                    Debug.Log("User has triggered Start Button");
                }
                break;
            case exitButtonIdentifier:
                {
                    Debug.Log("User has triggered Exit Button");
                }
                break;
            default:
                break;
        }
    }
}



using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

/*
 * Manages a stack of blocks
 * 
 * When instantiating, the blocks will have Rigidbody applied
 * The rigidbody will be constrained on the X and Z axis so 
 * that they fall straight down.
 * 
 */
public class ActsAsBlockStack : MonoBehaviour {

    public ArrayList stack = new ArrayList();

    [SerializeField]
    public GameObject zBlock1L1 = null;
    
    [SerializeField]
    public GameObject zBlock2L1 = null;

    [SerializeField]
    public GameObject zBlock3L1 = null;

    [SerializeField]
    public GameObject xBlock1L2 = null;

    [SerializeField]
    public GameObject xBlock2L2 = null;

    [SerializeField]
    public GameObject xBlock3L2 = null;

    [SerializeField]
    public GameObject zBlock1L3 = null;

    [SerializeField]
    public GameObject zBlock2L3 = null;

    [SerializeField]
    public GameObject zBlock3L3 = null;

    private void Awake()
    {
        Assert.raiseExceptions = true;
    }

    // Use this for initialization
    void Start () {
        stack = new ArrayList
        {
            zBlock1L1, zBlock2L1, zBlock3L1,
            xBlock1L2, xBlock2L2, xBlock3L2,
            zBlock1L3, zBlock2L3, zBlock3L3
        };

        ApplyRigidBodyToBlocks();
        ConstrainRigidBodysOnStack();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void DebugAwake()
    {
        this.Awake();
    }

    public void DebugStart()
    {
        this.Start();
    }

    public void ApplyRigidBodyToBlocks()
    {
        foreach (GameObject gameObject in this.stack)
        {
            Rigidbody rigidBody = gameObject.GetComponent<Rigidbody>();
            if (rigidBody == null)
            {
                gameObject.AddComponent<Rigidbody>();
            }
            
        }
    }

    public void ConstrainRigidBodysOnStack()
    {
        foreach (GameObject gameObject in this.stack)
        {
            Rigidbody rigidBody = gameObject.GetComponent<Rigidbody>();
            Assert.IsTrue(rigidBody != null);

            if (rigidBody != null)
            {
                rigidBody.constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionZ;
            }
            
        }
    }
}

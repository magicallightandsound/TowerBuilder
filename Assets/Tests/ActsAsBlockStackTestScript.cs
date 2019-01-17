using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;

/*
 *  Test the ActsAsBlockStack 
 */
public class ActsAsBlockStackTestScript {

    [Test]
    public void ShouldHaveAStackOfBlocks() {

        var gameObject = new GameObject("BlockStackGameObject");
        gameObject.AddComponent<ActsAsBlockStack>();

        ActsAsBlockStack actsAsBlockStack = gameObject.GetComponent<ActsAsBlockStack>();

        Assert.IsInstanceOf<ActsAsBlockStack>(actsAsBlockStack);
        Assert.IsNotNull(actsAsBlockStack.stack);

    }

    [UnityTest]
    public IEnumerator ShouldApplyRigidBodyToStack()
    {

        var gameObject = new GameObject("BlockStackGameObject");
        gameObject.AddComponent<ActsAsBlockStack>();

        ActsAsBlockStack actsAsBlockStack = gameObject.GetComponent<ActsAsBlockStack>();
        actsAsBlockStack.zBlock1L1 = new GameObject();
        actsAsBlockStack.zBlock2L1 = new GameObject();
        actsAsBlockStack.zBlock3L1 = new GameObject();
        actsAsBlockStack.xBlock1L2 = new GameObject();
        actsAsBlockStack.xBlock2L2 = new GameObject();
        actsAsBlockStack.xBlock3L2 = new GameObject();
        actsAsBlockStack.zBlock1L3 = new GameObject();
        actsAsBlockStack.zBlock2L3 = new GameObject();
        actsAsBlockStack.zBlock3L3 = new GameObject();

        actsAsBlockStack.DebugAwake();
        actsAsBlockStack.DebugStart();

        actsAsBlockStack.ApplyRigidBodyToBlocks();

        yield return null;

        foreach (GameObject go in actsAsBlockStack.stack)
        {
            Assert.IsNotNull(go);
            Rigidbody rigidBody = go.GetComponent<Rigidbody>();
            Assert.IsNotNull(rigidBody);
        }


    }


    [UnityTest]
    public IEnumerator ShouldConstrainRigidBodysToStack()
    {

        var gameObject = new GameObject("BlockStackGameObject");
        gameObject.AddComponent<ActsAsBlockStack>();

        ActsAsBlockStack actsAsBlockStack = gameObject.GetComponent<ActsAsBlockStack>();
        actsAsBlockStack.zBlock1L1 = new GameObject();
        actsAsBlockStack.zBlock2L1 = new GameObject();
        actsAsBlockStack.zBlock3L1 = new GameObject();
        actsAsBlockStack.xBlock1L2 = new GameObject();
        actsAsBlockStack.xBlock2L2 = new GameObject();
        actsAsBlockStack.xBlock3L2 = new GameObject();
        actsAsBlockStack.zBlock1L3 = new GameObject();
        actsAsBlockStack.zBlock2L3 = new GameObject();
        actsAsBlockStack.zBlock3L3 = new GameObject();

        actsAsBlockStack.DebugAwake();
        actsAsBlockStack.DebugStart();

        actsAsBlockStack.ApplyRigidBodyToBlocks();
        actsAsBlockStack.ConstrainRigidBodysOnStack();

        yield return null;

        foreach (GameObject go in actsAsBlockStack.stack)
        {
            Assert.IsNotNull(go);
            Rigidbody rigidBody = go.GetComponent<Rigidbody>();
            Assert.IsNotNull(rigidBody);

            bool constrained = rigidBody.constraints.Equals(RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionZ);
            Assert.IsTrue(constrained);
        }


    }


}

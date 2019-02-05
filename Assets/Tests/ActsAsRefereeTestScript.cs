using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;

public class ActsAsRefereeTestScript
{

    [Test]
    public void ShouldHitTestTheTopMostBlocksOfTheTower()
    {
        // Use the Assert class to test conditions.
    }

    [Test]
    public void ShouldDisplayEndOfGameNotice() {

        var gameObject = new GameObject("BlockStackGameObject");
        gameObject.AddComponent<ActsAsBlockStack>();

        ActsAsBlockStack actsAsBlockStack = gameObject.GetComponent<ActsAsBlockStack>();

    }

    // A UnityTest behaves like a coroutine in PlayMode
    // and allows you to yield null to skip a frame in EditMode
    [UnityTest]
    public IEnumerator NewTestScriptWithEnumeratorPasses() {
        // Use the Assert class to test conditions.
        // yield to skip a frame
        yield return null;
    }
}

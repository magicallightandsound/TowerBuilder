using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;

public class ActsAsEyeTargetTestScript {

    /*
     * When the player looks at the game object that has the 
     * ActsAsEyeTarget script, we count how many seconds the 
     * Player has looked at the target. 
     *
     * When the cooldown is true, the count goes down (cools)
     * but when the cooldown is false, the count goes up (heats)
     */
    [Test]
    public void ShouldHaveEyeGazeCoolDownFlag ()
    {
        var gameObject = new GameObject("ActsAsEyeTargetGameObject");
        gameObject.AddComponent<ActsAsEyeTarget>();

        ActsAsEyeTarget actsAsEyeTarget = gameObject.GetComponent<ActsAsEyeTarget>();

        Assert.IsInstanceOf<ActsAsEyeTarget>(actsAsEyeTarget);

        Assert.IsFalse(actsAsEyeTarget.coolDown == true);

    }

    [Test]
    public void NewTestScriptSimplePasses() {
        // Use the Assert class to test conditions.
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

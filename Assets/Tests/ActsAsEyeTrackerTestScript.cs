using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;

public class ActsAsEyeTrackerTestScript {

    [Test]
    public void ShouldHaveAHitLayerOf15() {
        var gameObject = new GameObject("ActsAsEyeTracker");
        gameObject.AddComponent<ActsAsEyeTracker>();

        ActsAsEyeTracker actsAsEyeTracker = gameObject.GetComponent<ActsAsEyeTracker>();

        Assert.IsTrue(actsAsEyeTracker.hitLayer == 15);
    }


    [Test]
    public void ShouldHaveADampenTimeOutOf33()
    {
        var gameObject = new GameObject("ActsAsEyeTracker");
        gameObject.AddComponent<ActsAsEyeTracker>();

        ActsAsEyeTracker actsAsEyeTracker = gameObject.GetComponent<ActsAsEyeTracker>();

        Assert.IsTrue(actsAsEyeTracker.dampenTimeout - 0.33F == 0.0F);
    }


}

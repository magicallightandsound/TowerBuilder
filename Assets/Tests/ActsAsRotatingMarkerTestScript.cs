using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;


public class ActsAsRotatingMarkerTestScript {

    [Test]
    public void ShouldHaveDefaultTimeoutOf15F()
    {
        var gameObject = new GameObject("ActsAsRotatingMarkerGameObject");
        gameObject.AddComponent<ActsAsRotatingMarker>();

        ActsAsRotatingMarker actsAsRotatingMarker = gameObject.GetComponent<ActsAsRotatingMarker>();

        Assert.IsInstanceOf<ActsAsRotatingMarker>(actsAsRotatingMarker);

        Assert.IsTrue(actsAsRotatingMarker.timeout == .15f);
    }

    [Test]
    public void ShouldHaveDefaultDegreesOf6F()
    {
        var gameObject = new GameObject("ActsAsRotatingMarkerGameObject");
        gameObject.AddComponent<ActsAsRotatingMarker>();

        ActsAsRotatingMarker actsAsRotatingMarker = gameObject.GetComponent<ActsAsRotatingMarker>();

        Assert.IsInstanceOf<ActsAsRotatingMarker>(actsAsRotatingMarker);

        Assert.IsTrue(actsAsRotatingMarker.degrees == 6f);
    }
}

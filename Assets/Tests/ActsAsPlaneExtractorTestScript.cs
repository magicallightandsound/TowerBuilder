using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;
using UnityEngine.XR.MagicLeap;


public class ActsAsPlaneExtractorTestScript {

    [Test]
    public void ShouldHaveAContainerOfPlanes()
    {
        var gameObject = new GameObject("ActsAsPlaneExtractorGameObject");
        gameObject.AddComponent<ActsAsPlaneExtractor>();

        ActsAsPlaneExtractor actsAsPlaneExtractor = gameObject.GetComponent<ActsAsPlaneExtractor>();

        Assert.IsInstanceOf<ActsAsPlaneExtractor>(actsAsPlaneExtractor);

        actsAsPlaneExtractor.DebugAwake();

        Assert.IsNotNull(actsAsPlaneExtractor.mlPlanes);
    }


    [Test]
    public void ShouldDetectHorizontalInnerPlanes()
    {
        var gameObject = new GameObject("ActsAsPlaneExtractorGameObject");
        gameObject.AddComponent<ActsAsPlaneExtractor>();

        ActsAsPlaneExtractor actsAsPlaneExtractor = gameObject.GetComponent<ActsAsPlaneExtractor>();

        Assert.IsInstanceOf<ActsAsPlaneExtractor>(actsAsPlaneExtractor);


        MLWorldPlanesQueryFlags result = actsAsPlaneExtractor.FilterForInnerHorizontalPlanes();


        Assert.IsTrue((result & MLWorldPlanesQueryFlags.Horizontal) == MLWorldPlanesQueryFlags.Horizontal);

        Assert.IsTrue((result & MLWorldPlanesQueryFlags.Inner) == MLWorldPlanesQueryFlags.Inner);
    }

    [Test]
    public void ShouldQueryForPlanesEveryFiveFrames()
    {
        var gameObject = new GameObject("ActsAsPlaneExtractorGameObject");
        gameObject.AddComponent<ActsAsPlaneExtractor>();

        ActsAsPlaneExtractor actsAsPlaneExtractor = gameObject.GetComponent<ActsAsPlaneExtractor>();

        Assert.IsInstanceOf<ActsAsPlaneExtractor>(actsAsPlaneExtractor);

        Assert.IsTrue(actsAsPlaneExtractor.timeout == 5f);
    }
}

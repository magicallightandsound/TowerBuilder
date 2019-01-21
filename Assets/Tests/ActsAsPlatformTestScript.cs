using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;

/*
 *  Test the ActsAsPlatform
 */
public class ActsAsPlatformTestScript  {

	[Test]
    public void ShouldHaveARigidBody()
    {
        var gameObject = new GameObject("ActsAsPlatformGameObject");
        gameObject.AddComponent<ActsAsPlatform>();


    }
}

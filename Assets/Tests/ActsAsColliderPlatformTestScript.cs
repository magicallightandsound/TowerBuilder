using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;

public class ActsAsColliderPlatformTestScript {

    [Test]
    public void ShouldHaveGameOverFallenBlockCountOf4() {

        var gameObject = new GameObject("ActsAsColliderPlatform");
        gameObject.AddComponent<ActsAsColliderPlatform>();

        ActsAsColliderPlatform actsAsColliderPlatform = gameObject.GetComponent<ActsAsColliderPlatform>();

        Assert.IsTrue(actsAsColliderPlatform.gameOverFallenBlockCount == 4);
    }

    [Test]
    public void ShouldHaveTowerHasFallenEvent()
    {
        ActsAsColliderPlatform.OnTowerHasFallen += TowerHasFallen;      
    }

    void TowerHasFallen(Collider collider)
    {

    }
}

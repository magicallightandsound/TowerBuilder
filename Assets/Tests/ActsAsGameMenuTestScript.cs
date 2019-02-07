using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;

public class ActsAsGameMenuTestScript {

    [Test]
    public void ShouldHaveStartButton() {

        var gameObject = new GameObject("ActsAsGameMenu");
        gameObject.AddComponent<ActsAsGameMenu>();

        ActsAsGameMenu actsAsGameMenu = gameObject.GetComponent<ActsAsGameMenu>();

        Assert.IsNull(actsAsGameMenu.startButton);

    }


    [Test]
    public void ShouldHaveExitButton()
    {
        var gameObject = new GameObject("ActsAsGameMenu");
        gameObject.AddComponent<ActsAsGameMenu>();

        ActsAsGameMenu actsAsGameMenu = gameObject.GetComponent<ActsAsGameMenu>();

        Assert.IsNull(actsAsGameMenu.exitButton);

    }


}

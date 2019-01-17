using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;

public class ActsAsBlockPlayTestScript {




    [UnityTest]
    public IEnumerator ShouldHaveAStackOfNineInstantiatedBlocks()
    {
        MonoBehaviourTest<ActsAsBlockStackTest> test = new MonoBehaviourTest<ActsAsBlockStackTest>();
        test.component.zBlock1L1 = new GameObject();
        test.component.zBlock2L1 = new GameObject();
        test.component.zBlock3L1 = new GameObject();
        test.component.xBlock1L2 = new GameObject();
        test.component.xBlock2L2 = new GameObject();
        test.component.xBlock3L2 = new GameObject();
        test.component.zBlock1L3 = new GameObject();
        test.component.zBlock2L3 = new GameObject();
        test.component.zBlock3L3 = new GameObject();


        yield return test;

        Assert.IsTrue(test.component.stack.Count == 9);

        foreach (var item in test.component.stack)
        {
            Assert.IsNotNull(item);
        }
    }

    public class ActsAsBlockStackTest : ActsAsBlockStack, IMonoBehaviourTest
    {
        private int frameCount;
        public bool IsTestFinished
        {
            get { return frameCount > 10; }
        }

        void Update()
        {
            frameCount++;
        }
    }
}

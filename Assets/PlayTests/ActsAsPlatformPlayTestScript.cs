using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;

public class ActsAsPlatformPlayTestScript  {

    [UnityTest]
    public IEnumerator ShouldHaveRigidBodyAndNotBeAffectedByOtherRigidBodies()
    {
        MonoBehaviourTest<ActsAsPlatformTest> test = new MonoBehaviourTest<ActsAsPlatformTest>();
       
        yield return test;

        var rb = test.component.GetComponent<Rigidbody>();
        Assert.IsNotNull(rb);

        Assert.IsTrue(rb.isKinematic);

    }


    public class ActsAsPlatformTest : ActsAsPlatform, IMonoBehaviourTest
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

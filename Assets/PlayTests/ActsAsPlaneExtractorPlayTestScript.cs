using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;
using UnityEngine.XR.MagicLeap;

public class ActsAsPlaneExtractorPlayTestScript : MonoBehaviour {

    [UnityTest]
    public IEnumerator ShouldStartExtractingPlanesOnAwake()
    {
        MonoBehaviourTest<ActsAsPlaneExtractorTest> test = new MonoBehaviourTest<ActsAsPlaneExtractorTest>();

        yield return test;

        if (MagicLeapDevice.IsReady())
        {
            Assert.IsTrue(test.component.IsMagicLeapEnabled());
        }
        
    }

    public class ActsAsPlaneExtractorTest : ActsAsPlaneExtractor, IMonoBehaviourTest
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

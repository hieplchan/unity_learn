using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEditor.VersionControl;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;

public class CoinCollectionRuntimeTests
{
    [Test]
    public void VerifyApplicationPlaying()
    {
        Assert.That(Application.isPlaying, Is.True);
    }

    [Test]
    public void VerifyScene()
    {
        var go = GameObject.Find("CoinComponent");
        Assert.That(go, Is.Not.Null, "CoinComponent not found in {0}", SceneManager.GetActiveScene().path);
    }
}

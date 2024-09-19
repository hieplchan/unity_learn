using System.Collections.Generic;
using NUnit.Framework;
using UnityEditor;
using UnityEditor.VersionControl;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CoinCollectionRuntimeTests
{
    [Test]
    public void VerifyApplicationPlaying()
    {
        Assert.That(Application.isPlaying, Is.True);
    }

    [Test]
    [LoadScene("Assets/Scenes/SampleScene.unity")]
    public void VerifyScene()
    {
        var go = GameObject.Find("CoinComponent");
        Assert.That(go, Is.Not.Null, "CoinComponent not found in {0}", SceneManager.GetActiveScene().path);
    }
}
using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using UnityEditor;
using UnityEditor.SceneManagement;
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
    [LoadScene("Assets/Scenes/SampleScene.unity")]
    public void VerifyScene()
    {
        var go = GameObject.Find("CoinComponent");
        Assert.That(go, Is.Not.Null, "CoinComponent not found in {0}", SceneManager.GetActiveScene().path);
    }
}

public class LoadSceneAttribute : NUnitAttribute, IOuterUnityTestAction
{
    private string scene;
    
    public LoadSceneAttribute(string scene)
    {
        this.scene = scene;
    }
    
    public IEnumerator BeforeTest(ITest test)
    {
        Debug.Assert(scene.EndsWith(".unity"), "Scene must end with .unity");
        yield return EditorSceneManager.LoadSceneInPlayMode(scene, new LoadSceneParameters(LoadSceneMode.Single));
    }

    public IEnumerator AfterTest(ITest test)
    {
        yield return null;
    }
}
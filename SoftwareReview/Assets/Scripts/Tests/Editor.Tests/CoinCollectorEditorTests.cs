using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using CollectableCoin;
using NSubstitute;
using NUnit.Framework;
using UnityEditor.VersionControl;
using UnityEngine;
using UnityEngine.TestTools;

public class CoinCollectorEditorTests
{
    [Test]
    public void CoinCollectorEditorTestsSimplePasses()
    {
        // 1st level Is/Has/Does/Contains
        // 2nd level All/Not/Some/Exactly
        // Or/And/Not
        // Is.Unique / Is.Ordered
        // Asset.IsTrue

        string username = "User123";
        Assert.That(username, Does.StartWith("U"));
        Assert.That(username, Does.EndWith("3"));

        var list = new List<int> { 1, 2, 3, 4, 5 };
        Assert.That(list, Contains.Item(3));
        Assert.That(list, Is.All.Positive);
        Assert.That(list, Has.Exactly(2).LessThan(3));
        Assert.That(list, Is.Ordered);
        Assert.That(list, Is.Unique);
        Assert.That(list, Has.Exactly(3).Matches<int>(NumberPredicates.IsOdd));
    }

    private ICoinController _controller;
    private ICoinView _view;
    private ICoinModel _model;
    private ICoinService _service;

    [SetUp]
    public void Setup()
    {
        _view = Substitute.For<ICoinView>();
        _service = Substitute.For<ICoinService>();
        _model = Substitute.For<ICoinModel>();
        
        Assert.That(_view, Is.Not.Null);
        Assert.That(_service, Is.Not.Null);
        Assert.That(_model, Is.Not.Null);

        _model.Coins.Returns(new Observable<int>(0));
        
        Assert.That(_model.Coins, Is.Not.Null);
        Assert.That(_model, Has.Property("Coins").Not.Null);

        _service.Load().Returns(_model);
        _controller = new CoinController(_view, _service);
        
        Assert.That(_controller, Is.Not.Null);
    }
    
    [TearDown]
    public void TearDown() { }

    [Test]
    public void CoinController_Constructor_ShouldThrowArgumentException_WhenViewIsNull()
    {
        Assert.That(() => new CoinController(null, _service), Throws.ArgumentNullException);
        Assert.Throws<ArgumentNullException>(() => new CoinController(null, _service));
    }
}
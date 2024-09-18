using System.Collections;
using System.Collections.Generic;
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
}

public static class NumberPredicates
{
    public static bool IsEven(int number)
    {
        return number % 2 == 0;
    }

    public static bool IsOdd(int number)
    {
        return number % 2 != 0;
    }
}

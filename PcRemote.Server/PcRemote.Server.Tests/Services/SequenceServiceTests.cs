using NUnit.Framework;
using PcRemote.Server.Core.Application;
using PcRemote.Server.Core.Application.Commands;

namespace PcRemote.Server.Tests.Services;

[TestFixture]
public class SequenceServiceTests
{
    private SequenceService _sequenceService;

    [SetUp]
    public void Setup()
    {
        _sequenceService = new();
    }

    [TestCase(1)]
    [TestCase(10)]
    [TestCase(15)]
    [TestCase(1000)]
    [TestCase(15000)]
    public void PassSingleValue(int value)
    {
        // Act
        _sequenceService.Push(value);

        // Assert
        Assert.AreEqual(value, _sequenceService.Last);
        Assert.AreEqual(null, _sequenceService.SecondLast);
        Assert.AreEqual(null, _sequenceService.ThirdLast);
    }

    [TestCase(1, 2)]
    [TestCase(4, 5)]
    [TestCase(1, 5)]
    [TestCase(1000, 2000)]
    [TestCase(15000, 2)]
    public void PassTwoValues(int firstValue, int secondValue)
    {
        // Act
        _sequenceService.Push(firstValue);
        _sequenceService.Push(secondValue);

        // Assert
        Assert.AreEqual(secondValue, _sequenceService.Last);
        Assert.AreEqual(firstValue, _sequenceService.SecondLast);
        Assert.AreEqual(null, _sequenceService.ThirdLast);
    }

    [TestCase(1, 2, 3)]
    [TestCase(4, 5, 7)]
    [TestCase(1, 5, 1)]
    [TestCase(1000, 2000, 1500)]
    [TestCase(15000, 2, 8)]
    public void PassThreeValues(int firstValue, int secondValue, int thirdValue)
    {
        // Act
        _sequenceService.Push(firstValue);
        _sequenceService.Push(secondValue);
        _sequenceService.Push(thirdValue);

        // Assert
        Assert.AreEqual(thirdValue, _sequenceService.Last);
        Assert.AreEqual(secondValue, _sequenceService.SecondLast);
        Assert.AreEqual(firstValue, _sequenceService.ThirdLast);
    }

    [TestCase(new [] {1, 2, 3})]
    [TestCase(new [] {3, 2, 1})]
    [TestCase(new [] {1, 2, 3, 4})]
    [TestCase(new [] {4, 3, 2, 1})]
    [TestCase(new [] {5, 8, 1, 9, 2, 8, 9, 1, 34, 97})]
    [TestCase(new [] {5, 8, 1, 9, 2, 8, 9, 1, 34, 97, 8, 23, 98, 27, 73, 84})]
    public void PassManyValues(int[] values)
    {
        // Act
        foreach (var value in values)
        {
            _sequenceService.Push(value);
        }

        // Assert
        Assert.AreEqual(values[^1], _sequenceService.Last);
        Assert.AreEqual(values[^2], _sequenceService.SecondLast);
        Assert.AreEqual(values[^3], _sequenceService.ThirdLast);
    }
}
using System.Reflection;
using FluentAssertions;
using FluentAssertions.Execution;

namespace Jgs.ValueObjects.Spec;

public class WhenCheckingEquality
{
    #region Implementation

    public static IEnumerable<object[]> GetValueObjectFactories()
    {
        var factories = Assembly
            .GetExecutingAssembly()
            .GetTypes()
            .Where(t => typeof(IValueObjectFactory).IsAssignableFrom(t) && !t.IsInterface);

        foreach (var factory in factories)
            yield return new[] { Activator.CreateInstance(factory)! };
    }

    #endregion

    #region Requirements

    [Theory]
    [MemberData(nameof(GetValueObjectFactories))]
    public void WithDifferentStructure_ThenObjectsAreNotEqual(IValueObjectFactory factory)
    {
        var o1 = factory.Create();
        var o2 = factory.CreateOther();

        using var scope = new AssertionScope();

        o2.Should().NotBe(o1);
        (o2 == o1).Should().BeFalse();
        (o2 != o1).Should().BeTrue();
    }

    [Theory]
    [MemberData(nameof(GetValueObjectFactories))]
    public void WithSameReference_ThenObjectsAreEqual(IValueObjectFactory factory)
    {
        var o1 = factory.Create();
        var o2 = o1;

        using var scope = new AssertionScope();

        o2.Should().Be(o1);
        (o2 == o1).Should().BeTrue();
        (o2 != o1).Should().BeFalse();
    }

    [Theory]
    [MemberData(nameof(GetValueObjectFactories))]
    public void WithSameStructure_ThenObjectsAreEqual(IValueObjectFactory factory)
    {
        var o1 = factory.Create();
        var o2 = factory.Create();

        using var scope = new AssertionScope();

        o2.Should().Be(o1);
        (o2 == o1).Should().BeTrue();
        (o2 != o1).Should().BeFalse();
    }

    #endregion
}

using FluentAssertions;
using FluentAssertions.Execution;

namespace Jgs.ValueObjects.Spec;

public abstract class WhenCheckingEquality
{
    #region Implementation

    public abstract ValueObject Create();
    public abstract ValueObject CreateOther();

    #endregion

    #region Requirements

    [Fact]
    public void WithDifferentStructure_ThenObjectsAreNotEqual()
    {
        var o1 = Create();
        var o2 = CreateOther();

        using var scope = new AssertionScope();

        o2.Should().NotBe(o1);
        (o2 == o1).Should().BeFalse();
        (o2 != o1).Should().BeTrue();
    }

    [Fact]
    public void WithSameReference_ThenObjectsAreEqual()
    {
        var o1 = Create();
        var o2 = o1;

        using var scope = new AssertionScope();

        o2.Should().Be(o1);
        (o2 == o1).Should().BeTrue();
        (o2 != o1).Should().BeFalse();
    }

    [Fact]
    public void WithSameStructure_ThenObjectsAreEqual()
    {
        var o1 = Create();
        var o2 = Create();

        using var scope = new AssertionScope();

        o2.Should().Be(o1);
        (o2 == o1).Should().BeTrue();
        (o2 != o1).Should().BeFalse();
    }

    #endregion
}

using FluentAssertions;
using FluentAssertions.Execution;

namespace Jgs.ValueObjects.Spec;

public abstract class WhenCheckingEquality
{
    #region Implementation

    public abstract ValueObject Create();

    #endregion

    #region Requirements

    [Fact]
    public void WithSameReference_ThenObjectsAreEqual()
    {
        var o1 = Create();
        var o2 = o1;

        using var scope = new AssertionScope();

        o2.Should().Be(o1);
        (o2 == o1).Should().BeTrue();
    }

    #endregion
}

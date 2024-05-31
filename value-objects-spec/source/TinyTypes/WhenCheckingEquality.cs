using FluentAssertions;

namespace Jgs.ValueObjects.Spec.TinyTypes;

public class WhenCheckingEquality : Spec.WhenCheckingEquality
{
    #region Requirements

    [Fact]
    public void AgainstWrappedType_WithSameValue_ThenObjectsAreEqual()
    {
        var foo = new Foo(1);

        foo.Should().Be(1);
    }

    #endregion
}

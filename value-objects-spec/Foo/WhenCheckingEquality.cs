namespace Jgs.ValueObjects.Spec.Foo;

public class WhenCheckingEquality : Spec.WhenCheckingEquality
{
    #region Implementation

    public override ValueObject Create() => new Foo();

    #endregion

    public class Foo : ValueObject
    {
    }
}

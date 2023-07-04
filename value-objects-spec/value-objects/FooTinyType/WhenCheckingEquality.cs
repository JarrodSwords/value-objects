namespace Jgs.ValueObjects.Spec.FooTinyType;

public class WhenCheckingEquality : Spec.WhenCheckingEquality
{
    #region Implementation

    public override ValueObject Create() => new Foo(1);
    public override ValueObject CreateOther() => new Foo(2);

    #endregion

    public class Foo : TinyType<int>
    {
        #region Creation

        public Foo(int value) : base(value)
        {
        }

        #endregion
    }
}

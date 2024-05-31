namespace Jgs.ValueObjects.Spec.FooTinyType;

public class Foo : ValueObject
{
    public Foo(int bar)
    {
        Bar = bar;
    }

    public int Bar { get; }

    #region Equality

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Bar;
    }

    #endregion
}

public class FooFactory : IValueObjectFactory
{
    public ValueObject Create() => new Foo(1);

    public ValueObject CreateOther() => new Foo(2);
}

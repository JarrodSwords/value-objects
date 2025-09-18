namespace Jgs.ValueObjects.Spec;

public class Foo(int bar) : ValueObject
{
    public int Bar { get; } = bar;

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

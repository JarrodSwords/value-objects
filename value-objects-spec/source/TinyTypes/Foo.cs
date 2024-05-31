namespace Jgs.ValueObjects.Spec.TinyTypes;

public class Foo : TinyType<int>
{
    public Foo(int bar) : base(bar)
    {
    }
}

public class FooFactory : IValueObjectFactory
{
    public ValueObject Create() => new Foo(1);

    public ValueObject CreateOther() => new Foo(2);
}

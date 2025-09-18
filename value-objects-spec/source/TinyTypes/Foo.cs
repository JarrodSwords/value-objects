namespace Jgs.ValueObjects.Spec.TinyTypes;

public class Foo(int bar) : TinyType<int>(bar);

public class FooFactory : IValueObjectFactory
{
    public ValueObject Create() => new Foo(1);
    public ValueObject CreateOther() => new Foo(2);
}

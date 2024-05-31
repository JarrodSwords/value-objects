namespace Jgs.ValueObjects.Spec;

public interface IValueObjectFactory
{
    ValueObject Create();
    ValueObject CreateOther();
}

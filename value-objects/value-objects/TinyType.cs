namespace Jgs.ValueObjects;

public abstract class TinyType<T> : ValueObject where T : notnull
{
    protected TinyType(T value)
    {
        Value = value;
    }

    public T Value { get; }

    public static implicit operator T(TinyType<T> source) => source.Value;

    #region Equality

    public override bool Equals(object? obj)
    {
        if (obj is null)
            return false;

        return obj.GetType() == typeof(T)
            ? Value.Equals(obj)
            : base.Equals(obj);
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }

    #endregion
}

namespace Jgs.ValueObjects;

public abstract class TinyType<T> : ValueObject where T : notnull
{
    #region Creation

    protected TinyType(T value)
    {
        Value = value;
    }

    #endregion

    #region Implementation

    public T Value { get; }

    #endregion

    #region Equality

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }

    #endregion

    #region Static Interface

    public static implicit operator T(TinyType<T> source) => source.Value;

    #endregion
}

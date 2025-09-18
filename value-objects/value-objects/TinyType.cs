using System.Diagnostics;

namespace Jgs.ValueObjects;

[DebuggerDisplay("{_value}")]
public abstract class TinyType<T>(T value) : ValueObject where T : notnull
{
    private T _value = value;

    public static implicit operator T(TinyType<T> source) => source._value;

    #region Equality

    public override bool Equals(object? obj) =>
        obj?.GetType() == typeof(T)
            ? _value.Equals(obj)
            : base.Equals(obj);

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return _value;
    }

    #endregion
}

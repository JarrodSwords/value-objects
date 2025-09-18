using System.Diagnostics;

namespace Jgs.ValueObjects;

[DebuggerDisplay("{Value}")]
public abstract class TinyType<T>(T value) : ValueObject where T : notnull
{
    protected T Value = value;

    public static implicit operator T(TinyType<T> source) => source.Value;

    #region Equality

    public override bool Equals(object? obj) =>
        obj?.GetType() == typeof(T)
            ? Value.Equals(obj)
            : base.Equals(obj);

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }

    #endregion
}

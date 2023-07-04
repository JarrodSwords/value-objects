namespace Jgs.ValueObjects;

public abstract class ValueObject : IEquatable<ValueObject>
{
    #region Equality

    public bool Equals(ValueObject? other)
    {
        if (other is null)
            return false;

        if (GetType() != other.GetType())
            return false;

        return GetEqualityComponents().SequenceEqual(other.GetEqualityComponents());
    }

    public override bool Equals(object? obj)
    {
        if (ReferenceEquals(null, obj))
            return false;

        if (ReferenceEquals(this, obj))
            return true;

        if (obj.GetType() != GetType())
            return false;

        return Equals((ValueObject) obj);
    }

    public abstract IEnumerable<object> GetEqualityComponents();

    public override int GetHashCode() =>
        GetEqualityComponents().Aggregate(
            1,
            (current, obj) =>
            {
                unchecked
                {
                    return current * 23 + (obj?.GetHashCode() ?? 0);
                }
            }
        );

    #endregion

    #region Static Interface

    public static bool operator ==(ValueObject? left, ValueObject? right) => Equals(left, right);

    public static bool operator !=(ValueObject? left, ValueObject? right) => !Equals(left, right);

    #endregion
}

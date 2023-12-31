﻿namespace Jgs.ValueObjects.Spec.FooValueObject;

public class WhenCheckingEquality : Spec.WhenCheckingEquality
{
    #region Implementation

    public override ValueObject Create() => new Foo(1, "Bat");
    public override ValueObject CreateOther() => new Foo(2, "Bat");

    #endregion

    public class Foo : ValueObject
    {
        #region Creation

        public Foo(int bar, string bat)
        {
            Bar = bar;
            Bat = bat;
        }

        #endregion

        #region Implementation

        public int Bar { get; }
        public string Bat { get; }

        #endregion

        #region Equality

        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return Bar;
            yield return Bat;
        }

        #endregion
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DraftLabOne.Domain.Common
{
    public abstract class ValueObject
    {
        protected abstract IEnumerable<object> GetQualityComponents();
        public override bool Equals(object? obj)
        {
            if (obj == null)
                return false;
            if (GetType() != obj.GetType())
                return false;

           // var valueObject = (ValueObject)obj;

            if (obj is not ValueObject valueObject)
            {
                return false;
            }

            return GetQualityComponents().SequenceEqual(valueObject.GetQualityComponents());
            // return base.Equals(obj);
        }

        public override int GetHashCode() =>
            GetQualityComponents().Aggregate(
                default(int),
                (hashcode, value) =>
                HashCode.Combine(hashcode, value.GetHashCode()));

        public static bool operator == (ValueObject a, ValueObject b)
        {
            if (ReferenceEquals(a, null) && ReferenceEquals(b, null))
                return true;

            if (ReferenceEquals(a, null) || ReferenceEquals(b, null))
                return false;
            return a.Equals(b);
        }

        public static bool operator !=(ValueObject a, ValueObject b)
        {
            return !(a == b);
        }
    }
}

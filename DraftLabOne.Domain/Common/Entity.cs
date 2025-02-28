using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DraftLabOne.Domain.Common
{
    public abstract class Entity
    {
        protected Entity() { }

        protected Entity(long id)
        {
            Id = id;
        }

        public long Id { get; } 

        public static bool operator ==(Entity? left, Entity? right)
        { 
            if (ReferenceEquals(left, null) && ReferenceEquals(right, null))
                return true;

            if (ReferenceEquals(left, null) || ReferenceEquals(right, null))
                return false;
           
            return left.Equals(right); 
        }

        public static bool operator !=(Entity left, Entity right)
        {
            return !(left==right);
        }

        public override bool Equals(object? obj)
        {
            if (obj is not Entity other)
            {
                return false;
            }

            if (ReferenceEquals(this, other) == false) 
                 return false;

            if (GetType() != other.GetType())
                return false;

            return Id == other.Id;
        }

        public override int GetHashCode() 
        {
          return (GetType().ToString() + Id).GetHashCode();
        }

    }
}

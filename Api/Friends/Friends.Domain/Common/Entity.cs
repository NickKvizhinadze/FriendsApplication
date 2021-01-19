#nullable disable
using System;

namespace Friends.Domain.Common
{
    public abstract class Entity<T> where T : notnull
    {
        #region Constructor
        protected Entity()
        {
            Id = default;
        }

        protected Entity(T id)
        {
            Id = id;
        }
        #endregion

        #region Properties
        public virtual T Id { get; protected set; }
        #endregion

        #region Methods
        public override bool Equals(object obj)
        {
            if (!(obj is Entity<T> other))
                return false;

            if (ReferenceEquals(this, other))
                return true;

            if (GetRealType() != other.GetRealType())
                return false;

            if (Equals(Id, default(T)) || Equals(other.Id, default(T)))
                return false;

            return Equals(Id, other.Id);
        }

        public static bool operator ==(Entity<T> entity1, Entity<T> entity2)
        {
            if (entity1 is null && entity2 is null)
                return true;

            if (entity1 is null || entity2 is null)
                return false;

            return entity1.Equals(entity2);
        }

        public static bool operator !=(Entity<T> entity1, Entity<T> entity2)
        {
            return !(entity1 == entity2);
        }

        public override int GetHashCode()
        {
            return (GetRealType().ToString() + Id).GetHashCode();
        }
        #endregion

        #region Private Methods

        private Type GetRealType()
        {
            var type = GetType();
            if (type.ToString().Contains("Castle.Proxies."))
                return type.BaseType;

            return type;
        }
        #endregion
    }
}

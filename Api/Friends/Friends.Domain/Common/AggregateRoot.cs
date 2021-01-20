namespace Friends.Domain.Common
{
    public abstract class AggregateRoot<T> : Entity<T> where T : notnull
    {
        #region Cosntructors
        public AggregateRoot()
        {
        }

        public AggregateRoot(T id): base(id)
        {
        }
        #endregion
    }
}

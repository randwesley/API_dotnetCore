namespace Randerson.Domain.Data
{
    public abstract class BaseEntity<TId>
    {
        #region Properties
        public TId Id { get; set; }
        #endregion
        #region Overrides
        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }
            if (!(obj is BaseEntity<TId>))
            {
                return false;
            }
            if (obj.GetType() != GetType())
            {
                return false;
            }
            var entity = obj as BaseEntity<TId>;
            return entity.Id.Equals(this.Id);
        }
        public override int GetHashCode()
        {
            return this.Id.GetHashCode() ^ 31;
        }
        #endregion
    }

}

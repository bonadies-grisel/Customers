namespace knowledge.common.entities.Types
{
    public class EntityBase<TId>
    {
        #region Public Properties
        public TId Id { get; set; }
        public bool Active { get; set; }
        #endregion
    }
}

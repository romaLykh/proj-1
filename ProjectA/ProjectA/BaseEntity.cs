namespace LibraryDomain
{
    public abstract class BaseEntity : IEntity
    {
        protected BaseEntity()
        {
            Id = Random.Shared.Next(300);
        }

        public int Id { get; set; }

        // поліморфізм 1
        public override bool Equals(object? obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }
            return Id == ((BaseEntity)obj).Id;
        }

    }
}

using System;

namespace Data
{
    public class BaseModel : IEntity<Guid>
    {
        public Guid Id { get; set; }
    }
}

using System;

namespace MzsfData
{
    public class BaseModel : IEntity<Guid>
    {
        public Guid Id { get; set; }
    }
}

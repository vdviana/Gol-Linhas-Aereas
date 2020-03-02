using System;

namespace Gol.Domain.Entities
{
    public abstract class BaseEntity
    {
        public virtual int Id { get; set; }
        public virtual DateTime CreationDate { get; set; }
    }
}

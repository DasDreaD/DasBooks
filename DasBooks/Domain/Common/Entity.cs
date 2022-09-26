using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Common
{
    public class Entity
    {
        protected Entity(int id)
        {
            Id = id;
        }

        protected Entity() { }

        public int Id { get; protected set; }
    }
}

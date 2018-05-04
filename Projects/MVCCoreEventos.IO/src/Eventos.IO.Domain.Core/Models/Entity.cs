using FluentValidation;
using FluentValidation.Results;
using System;

namespace Eventos.IO.Domain.Core.Models
{
    public abstract class Entity<T> : AbstractValidator<T> where T : Entity<T>
    {
        public Entity()
        {
            ValidationResult = new ValidationResult();
        }

        public Guid Id { get; protected set; }

        public override bool Equals(object obj)
        {
            var compareTo = obj as Entity<T>;

            if (ReferenceEquals(this, compareTo)) return true;

            if (compareTo is null) return false;

            return Id.Equals(compareTo.Id);
        }

        public static bool operator ==(Entity<T> a, Entity<T> b)
        {
            if (a is null && b is null) return true;

            if (a is null || b is null) return false;

            return a.Equals(b);
        }

        public static bool operator !=(Entity<T> a, Entity<T> b)
        {
            return !(a == b);
        }

        public override int GetHashCode()
        {
            return (GetType().GetHashCode() * 3417) + Id.GetHashCode();
        }

        public override string ToString()
        {
            return GetType().Name + string.Format("[Id = {0}]", Id);
        }

        public abstract bool IsValid();

        public ValidationResult ValidationResult { get; protected set; }
    }
}

﻿using Proj.Manager.Core.Exceptions;
using Proj.Manager.Core.Primitives;

namespace Proj.Manager.Core.ValueObjects
{
    public sealed class Password : ValueObject
    {
        public string Value { get; private set; }
        public Password(string value)
        {
            Validate(value);

            Value = value;
        }

        private void Validate(string value)
        {
            if (value.Length == 0) throw new InvalidPasswordException("Invalid password passed.");
        }
    }
}

// Copyright (c) 2012 Andrew Cooper
//
// This file is part of JavaSpitzer.
//
// JavaSpitzer is free software: you can redistribute it and/or modify
// it under the terms of the GNU Lesser General Public License as published by
// the Free Software Foundation, either version 3 of the License, or
// (at your option) any later version.
//
// This program is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU Lesser General Public License for more details.
//
// You should have received a copy of the GNU Lesser General Public License
// along with this program.  If not, see <http://www.gnu.org/licenses/>.

namespace JavaSpitzer
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;

    public abstract class Enumeration<TEnum>
        where TEnum : Enumeration<TEnum>
    {
        protected static int nextOrdinal = 0;

        protected static readonly Dictionary<int, TEnum> byOrdinal = new Dictionary<int, TEnum>();
        protected static readonly Dictionary<string, TEnum> byName = new Dictionary<string, TEnum>();

        protected readonly string name;
        protected readonly int ordinal;

        protected Enumeration()
        {
            ordinal = nextOrdinal++;
            byOrdinal.Add(ordinal, (TEnum)this);
            name = typeof(TEnum).GetFields(BindingFlags.Public | BindingFlags.Static | BindingFlags.DeclaredOnly)[ordinal].Name;
            byName.Add(name, (TEnum)this);
        }

        public override string ToString()
        {
            return name;
        }

        public string Name
        {
            get { return name; }
        }

        public int Ordinal
        {
            get { return ordinal; }
        }

        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            if (GetType() != obj.GetType()) return false;
            return ((Enumeration<TEnum>)obj).ordinal == ordinal;
        }

        public override int GetHashCode()
        {
            return ordinal.GetHashCode();
        }

        public static IEnumerable<TEnum> Values
        {
            get { return byOrdinal.Values; }
        }

        public static implicit operator string(Enumeration<TEnum> obj)
        {
            return obj.name;
        }

        public static TEnum Parse(string value)
        {
            return Parse(value, false);
        }

        public static bool TryParse(string value, out TEnum result)
        {
            if (value == null)
            {
                result = null;
                return false;
            }
            
            return byName.TryGetValue(value, out result);
        }

        public static TEnum Parse(string value, bool ignoreCase)
        {
            if (value == null)
            {
                throw new ArgumentNullException(value, String.Format("Value cannot be null.{0}Parameter name: value", Environment.NewLine));
            }

            if (String.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("Must specify valid information for parsing in the string.");
            }

            TEnum result;
            if (TryParse(value, ignoreCase, out result))
            {
                return result;
            }
            else
            {
                throw new ArgumentException(String.Format("Requested value '{0}' was not found.", value));
            }
        }

        public static bool TryParse(string value, bool ignoreCase, out TEnum result)
        {
            if (value == null)
            {
                result = null;
                return false;
            }

            if (!ignoreCase)
            {
                return TryParse(value, out result);
            }
            
            var entry = byName.Where(kvp => kvp.Key.Equals(value, StringComparison.InvariantCultureIgnoreCase));
            if (entry.Count() == 0)
            {
                result = null;
                return false;
            }
            else
            {
                result = entry.First().Value;
                return true;
            }
        }
    }
}

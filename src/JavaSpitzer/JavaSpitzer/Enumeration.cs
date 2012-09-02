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

    public abstract class Enumeration<TEnum>
        where TEnum : Enumeration<TEnum>
    {
        protected static int nextOrdinal = 0;

        protected static readonly Dictionary<int, TEnum> byOrdinal = new Dictionary<int, TEnum>();
        protected static readonly Dictionary<string, TEnum> byName = new Dictionary<string, TEnum>();

        protected readonly string name;
        protected readonly int ordinal;

        protected Enumeration(string name)
        {
            this.name = name;
            ordinal = nextOrdinal++;
            byOrdinal.Add(ordinal, (TEnum)this);
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

        private Type EnumType
        {
            get { return typeof(TEnum); }
        }

        public static IEnumerable<TEnum> Values
        {
            get { return byOrdinal.Values; }
        }

        public static explicit operator int(Enumeration<TEnum> obj)
        {
            return obj.ordinal;
        }
    }
}

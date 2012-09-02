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

namespace Neo4Net.Helpers.Atomic
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading;

    public sealed class AtomicInt64
    {
        private long value;

        public AtomicInt64()
            : this(0L)
        {
        }

        public AtomicInt64(long value)
        {
            this.value = value;
        }

        public long Value
        {
            get { return value; }
            set { this.value = value; }
        }

        public void Set(long value)
        {
            this.value = value;
        }

        public long GetAndIncrement()
        {
            long initialValue, incremented;
            do
            {
                initialValue = value;
                incremented = initialValue + 1;
            } while (initialValue != Interlocked.CompareExchange(ref value, incremented, initialValue));
            return initialValue;
        }

        public long IncrementAndGet()
        {
            long initialValue, incremented;
            do
            {
                initialValue = value;
                incremented = initialValue + 1;
            } while (initialValue != Interlocked.CompareExchange(ref value, incremented, initialValue));
            return incremented;
        }
    }
}

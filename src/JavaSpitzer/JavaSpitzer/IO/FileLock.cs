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

namespace JavaSpitzer.IO
{
    using System;
    using System.IO;

    /// <summary>
    /// Provides compatibility with java.nio.channels.FileLock
    /// </summary>
    public abstract class FileLock
    {
        private readonly Stream stream;
        private readonly long position;
        private readonly long length;
        private readonly bool isShared;

        protected FileLock(Stream stream, long position, long length, bool shared)
        {
            if (position < 0) throw new ArgumentOutOfRangeException("position", "Negative position");
            if (length < 0) throw new ArgumentOutOfRangeException("length", "Negative length");
            if (position + length < 0) throw new ArgumentOutOfRangeException("position+length", "Negative position + length");

            this.stream = stream;
            this.position = position;
            this.length = length;
            this.isShared = shared;
        }

        public Stream Stream
        {
            get { return stream as Stream; }
        }

        public virtual Stream AcquiredBy
        {
            get { return stream; }
        }

        public void Close()
        {
            Release();
        }

        public bool IsShared
        {
            get { return isShared; }
        }

        public abstract bool IsValid { get; }

        public bool Overlaps(long position, long length)
        {
            if (position + length <= this.position)
                return false;
            return this.position + this.length > position;
        }

        public long Position
        {
            get { return position; }
        }

        public long Length
        {
            get { return length; }
        }

        public long Size
        {
            get { return length; }
        }

        public abstract void Release();

        public override string ToString()
        {
            return String.Format("{0}[{1}:{2} {3} {4}]", GetType().Name, Position, Length, IsShared ? "shared" : "exclusive", IsValid ? "valid" : "invalid");
        }
    }
}

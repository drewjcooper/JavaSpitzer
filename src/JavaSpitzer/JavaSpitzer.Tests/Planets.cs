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

namespace JavaSpitzer.Tests
{
    public class Planets : Enumeration<Planets>
    {
        public static readonly Planets Mercury = new Planets();
        public static readonly Planets Venus = new Planets();
        public static readonly Planets Earth = new Planets();
        public static readonly Planets Mars = new Planets();
        public static readonly Planets Jupiter = new Planets();
        public static readonly Planets Saturn = new Planets();
        public static readonly Planets Uranus = new Planets();
        public static readonly Planets Neptune = new Planets();

        private Planets() { }
    }
}

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
    using System;
    using NUnit.Framework;

    [TestFixture]
    public class TestEnumeration
    {
        [Test]
        public void TestMercury()
        {
            TestEnumerationValues(Planets.Mercury, "Mercury", 0);
        }

        [Test]
        public void TestVenus()
        {
            TestEnumerationValues(Planets.Venus, "Venus", 1);
        }

        [Test]
        public void TestEarth()
        {
            TestEnumerationValues(Planets.Earth, "Earth", 2);
        }

        [Test]
        public void TestMars()
        {
            TestEnumerationValues(Planets.Mars, "Mars", 3);
        }

        [Test]
        public void TestJupiter()
        {
            TestEnumerationValues(Planets.Jupiter, "Jupiter", 4);
        }

        [Test]
        public void TestSaturn()
        {
            TestEnumerationValues(Planets.Saturn, "Saturn", 5);
        }

        [Test]
        public void TestUranus()
        {
            TestEnumerationValues(Planets.Uranus, "Uranus", 6);
        }

        [Test]
        public void TestNeptune()
        {
            TestEnumerationValues(Planets.Neptune, "Neptune", 7);
        }

        private void TestEnumerationValues(Planets value, string expectedName, int expectedOrdinal)
        {
            Assert.That(value.Name, Is.EqualTo(expectedName));
            Assert.That(value.Ordinal, Is.EqualTo(expectedOrdinal));
        }

        [Test]
        public void TestCanBeUsedInSwitchStatement()
        {
            var planet = Planets.Earth;
            switch (planet)
            {
                case "Earth":
                    Assert.Pass();
                    break;

                default:
                    Assert.Fail();
                    break;
            }
        }


    }
}

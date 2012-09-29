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
    using NUnit.Framework;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    [TestFixture]
    public class TestEnumerationStringParsing
    {
        [TestCase("Mercury", 0)]
        [TestCase("Venus", 1)]
        [TestCase("Earth", 2)]
        [TestCase("Mars", 3)]
        [TestCase("Jupiter", 4)]
        [TestCase("Saturn", 5)]
        [TestCase("Uranus", 6)]
        [TestCase("Neptune", 7)]
        public void TestParseWithValidString(string value, int expectedOrdinal)
        {
            var planet = Planets.Parse(value);
            Assert.That(planet.Ordinal, Is.EqualTo(expectedOrdinal));
        }

        [TestCase("Mercury", 0)]
        [TestCase("Venus", 1)]
        [TestCase("Earth", 2)]
        [TestCase("Mars", 3)]
        [TestCase("Jupiter", 4)]
        [TestCase("Saturn", 5)]
        [TestCase("Uranus", 6)]
        [TestCase("Neptune", 7)]
        public void TestTryParseWithValidString(string value, int expectedOrdinal)
        {
            Planets planet = null;
            var result = Planets.TryParse(value, out planet);
            Assert.That(result, Is.True);
            Assert.That(planet.Ordinal, Is.EqualTo(expectedOrdinal));
        }

        [TestCase("Mercury", 0)]
        [TestCase("Venus", 1)]
        [TestCase("Earth", 2)]
        [TestCase("Mars", 3)]
        [TestCase("Jupiter", 4)]
        [TestCase("Saturn", 5)]
        [TestCase("Uranus", 6)]
        [TestCase("Neptune", 7)]
        public void TestCaseSensitiveParseWithValidString(string value, int expectedOrdinal)
        {
            var planet = Planets.Parse(value, false);
            Assert.That(planet.Ordinal, Is.EqualTo(expectedOrdinal));
        }

        [TestCase("Mercury", 0)]
        [TestCase("Venus", 1)]
        [TestCase("Earth", 2)]
        [TestCase("Mars", 3)]
        [TestCase("Jupiter", 4)]
        [TestCase("Saturn", 5)]
        [TestCase("Uranus", 6)]
        [TestCase("Neptune", 7)]
        public void TestCaseSensitiveTryParseWithValidString(string value, int expectedOrdinal)
        {
            Planets planet = null;
            var result = Planets.TryParse(value, false, out planet);
            Assert.That(result, Is.True);
            Assert.That(planet.Ordinal, Is.EqualTo(expectedOrdinal));
        }

        [TestCase("Mercury", 0)]
        [TestCase("Venus", 1)]
        [TestCase("Earth", 2)]
        [TestCase("Mars", 3)]
        [TestCase("Jupiter", 4)]
        [TestCase("Saturn", 5)]
        [TestCase("Uranus", 6)]
        [TestCase("Neptune", 7)]
        [TestCase("mercury", 0)]
        [TestCase("venus", 1)]
        [TestCase("earth", 2)]
        [TestCase("mars", 3)]
        [TestCase("jupiter", 4)]
        [TestCase("saturn", 5)]
        [TestCase("uranus", 6)]
        [TestCase("neptune", 7)]
        public void TestCaseInsensitiveParseWithValidString(string value, int expectedOrdinal)
        {
            var planet = Planets.Parse(value, true);
            Assert.That(planet.Ordinal, Is.EqualTo(expectedOrdinal));
        }

        [TestCase("Mercury", 0)]
        [TestCase("Venus", 1)]
        [TestCase("Earth", 2)]
        [TestCase("Mars", 3)]
        [TestCase("Jupiter", 4)]
        [TestCase("Saturn", 5)]
        [TestCase("Uranus", 6)]
        [TestCase("Neptune", 7)]
        [TestCase("mercury", 0)]
        [TestCase("venus", 1)]
        [TestCase("earth", 2)]
        [TestCase("mars", 3)]
        [TestCase("jupiter", 4)]
        [TestCase("saturn", 5)]
        [TestCase("uranus", 6)]
        [TestCase("neptune", 7)]
        public void TestCaseInsensitiveTryParseWithValidString(string value, int expectedOrdinal)
        {
            Planets planet = null;
            var result = Planets.TryParse(value, true, out planet);
            Assert.That(result, Is.True);
            Assert.That(planet.Ordinal, Is.EqualTo(expectedOrdinal));
        }

        [TestCase("Mercury1")]
        [TestCase("Mars Saturn")]
        [TestCase("earth")]
        [TestCase("Pluto")]
        public void TestParseWithInvalidStringThrowsArgumentException(string value)
        {
            var expectedMessage = String.Format("Requested value '{0}' was not found.", value);
            Assert.That(() => Planets.Parse(value), Throws.TypeOf<ArgumentException>().With.Message.EqualTo(expectedMessage));
            Assert.That(() => Planets.Parse(value, false), Throws.TypeOf<ArgumentException>().With.Message.EqualTo(expectedMessage));
        }

        [TestCase("")]
        [TestCase("\n")]
        [TestCase("  ")]
        public void TestParseWithEmptyOrWhitespaceStringThrowsArgumentException(string value)
        {
            var expectedMessage = String.Format("Must specify valid information for parsing in the string.");
            Assert.That(() => Planets.Parse(value), Throws.TypeOf<ArgumentException>().With.Message.EqualTo(expectedMessage));
            Assert.That(() => Planets.Parse(value, false), Throws.TypeOf<ArgumentException>().With.Message.EqualTo(expectedMessage));
        }

        [Test]
        public void TestParseWithNullStringThrowsArgumentNullException()
        {
            string value = null;
            var expectedMessage = String.Format("Value cannot be null.{0}Parameter name: value", Environment.NewLine);
            Assert.That(() => Planets.Parse(value), Throws.TypeOf<ArgumentNullException>().With.Message.EqualTo(expectedMessage));
            Assert.That(() => Planets.Parse(value, true), Throws.TypeOf<ArgumentNullException>().With.Message.EqualTo(expectedMessage));
            Assert.That(() => Planets.Parse(value, false), Throws.TypeOf<ArgumentNullException>().With.Message.EqualTo(expectedMessage));
        }

        [TestCase("Mercury1")]
        [TestCase("Mars Saturn")]
        [TestCase("earth")]
        [TestCase("Pluto")]
        [TestCase("")]
        [TestCase("\n")]
        [TestCase("  ")]
        [TestCase(null)]
        public void TestTryParseWithInvalidStringReturnsFalseAndNullOutput(string value)
        {
            var expectedMessage = String.Format("Requested value '{0}' was not found.", value);
            var planet = Planets.Jupiter;

            var result = Planets.TryParse(value, out planet);
            Assert.That(result, Is.False);
            Assert.That(planet, Is.Null);

            planet = Planets.Jupiter;
            result = Planets.TryParse(value, false, out planet);
            Assert.That(result, Is.False);
            Assert.That(planet, Is.Null);
        }
    }
}

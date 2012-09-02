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
    using System.Runtime.Serialization;
    using System.Security;

    /// <summary>
    /// A strongly-typed version of <see cref="System.WeakReference"/>.
    /// </summary>
    /// <remarks>This class is a simple wrapper around <see cref="System.WeakReference"/>
    ///     which ensures that the object being tracked is of the specified type.  It
    ///     makes code using weak references more readable.</remarks>
    /// <typeparam name="T">The type of the reference being weakly held.</typeparam>
    public class WeakReference<T> : WeakReference
        where T : class
    {
        /// <summary>
        /// Initializes a new instance of the <c>WeakReference<![CDATA[<T>]]></c> class, referencing
        ///     the specified object.
        /// </summary>
        /// <param name="target">The object to track or <c>null</c>.</param>
        public WeakReference(T target)
            : base(target)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <c>WeakReference<![CDATA[<T>]]></c> class, referencing
        ///     the specified object and using the specified resurrection tracking.
        /// </summary>
        /// <param name="target">The object to track or <c>null</c>.</param>
        /// <param name="trackResurrection">Indicates when to stop tracking the object. 
        ///     If true, the object is tracked after finalization; if false, the object 
        ///     is only tracked until finalization.</param>
        public WeakReference(T target, bool trackResurrection)
            : base(target, trackResurrection)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <c>WeakReference<![CDATA[<T>]]></c> class, using deserialized
        ///     data from the specified serialization and stream objects.
        /// </summary>
        /// <param name="info">An object that holds all the data needed to serialize or 
        ///     deserialize the current <c>WeakReference<![CDATA[<T>]]></c> object.</param>
        /// <param name="context">Describes the source and destination of the serialized stream
        ///     specified by info.</param>
        /// <exception cref="System.ArgumentNullException">info is <c>null</c>.</exception>
        protected WeakReference(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }

        /// <summary>
        /// Gets or sets the object (the target) referenced by the current <c>WeakReference<![CDATA[<T>]]></c>
        ///     object.
        /// </summary>
        /// <value>null if the object referenced by the current <c>WeakReference<![CDATA[<T>]]></c> object
        ///     has been garbage collected; otherwise, a reference to the object referenced
        ///     by the current <c>WeakReference<![CDATA[<T>]]></c> object.</value>
        /// <exception cref="InvalidOperationException">The reference to the target object is 
        ///     invalid. This exception can be thrown while setting this property if the value 
        ///     is a null reference or if the object has been finalized during the set operation.
        ///     </exception>
        public new T Target
        {
            get { return base.Target as T; }
            set { base.Target = value; }
        }
    }
}

using System;

namespace IMDB.Core.Applications.Common.CQRS
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
    public class DisplayNameAttribute : Attribute
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DisplayNameAttribute"/> class. 
        /// </summary>
        public DisplayNameAttribute() { }

        public string Key { get; set; }
    }
}

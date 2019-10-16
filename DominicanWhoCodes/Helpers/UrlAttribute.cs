using System;
namespace DominicanWhoCodes.Helpers
{
    [AttributeUsage(AttributeTargets.Interface, Inherited = false, AllowMultiple = false)]
    sealed class UrlAttribute : Attribute
    {
        public string Url { get; }

        public UrlAttribute(string url)
        {
            Url = url;
        }
    }
}

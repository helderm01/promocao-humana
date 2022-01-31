using System;
using System.Runtime.Serialization;

namespace PromocaoHumana.Web.Domain.Exceptions
{
    public class ViaCepException : Exception, ISerializable
    {
        public ViaCepException() : base() { }

        public ViaCepException(string message) : base(message) { }
    }
}
using System;
using System.Runtime.Serialization;

namespace PSCredentialManager.Common.Exceptions
{
	public class IncompatibleCredentialException : Exception, ISerializable
	{
		public IncompatibleCredentialException() { }
		public IncompatibleCredentialException(string message) : base(message) { }
		public IncompatibleCredentialException(string message, Exception inner) : base(message, inner) { }
		public IncompatibleCredentialException(SerializationInfo info, StreamingContext context) : base(info, context) { }
	}
}

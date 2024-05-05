using System;

namespace Exceptions
{
	/**
	 * Exception thrown when an FMOD event reference is empty
	 */
	public class EmptyFMODEventReference : Exception
	{
		public EmptyFMODEventReference()
		{
		}
		public EmptyFMODEventReference(string message) : base(message)
		{
		}

		public EmptyFMODEventReference(string message, Exception innerException) : base(message, innerException)
		{
		}
	}
}

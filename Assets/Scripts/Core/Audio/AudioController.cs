using Exceptions;
using FMOD.Studio;
using FMODUnity;

namespace Core.Audio
{
	public class AudioController
	{

		/**
		 * Assumes that the event reference is not null before creating an instance of the event.
		 * <exception cref="EmptyFMODEventReference">Thrown when event reference is null</exception>
		 */
		public EventInstance AssertEvent(EventReference eventReference)
		{
			if (eventReference.IsNull)
			{
				throw new EmptyFMODEventReference("Event is null");
			}

			return RuntimeManager.CreateInstance(eventReference);
		}
	}

}
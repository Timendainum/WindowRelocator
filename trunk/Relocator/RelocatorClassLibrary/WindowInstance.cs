using System;

namespace RelocatorClassLibrary
{
	public class WindowInstance
	{
		public WindowInstance(IntPtr handlerId, string name)
		{
			handerId = handlerId;
			windowName = name;

		}
		
		public IntPtr handerId { get; set; }
		public string windowName { get; set; }

		public override string ToString()
		{
			return windowName;
		}
	}
}

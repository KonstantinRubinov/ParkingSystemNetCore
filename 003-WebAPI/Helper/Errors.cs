using System.Collections.Generic;
using System.Diagnostics;

namespace ParkingSystemCore
{
	public class Errors
	{
		private List<string> errors { get; set; } = new List<string>();

		public void Add(string errorMessage)
		{
			errors.Add(errorMessage);
			Debug.WriteLine("errors: " + errorMessage);
		}
	}
}

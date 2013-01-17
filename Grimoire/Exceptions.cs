using System;
using System.Runtime.InteropServices;

namespace Grimoire
{
	public class GuignolException : Exception
	{
		public GuignolException(){}
		public GuignolException(string Text)
		{
			message=Text;
		}
		string message;
		public new string Message
		{
			get
			{
				return message;
			}
		}
	}
}


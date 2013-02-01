using System;

namespace CoreTweet
{
	public class Status : CoreBase
	{
		internal override CoreBase ConvertBase (dynamic e)
		{
			
		}
	}
	public class Contributors : CoreBase
	{
		public long Id;
		public string Id_Str;
		public string ScreenName;
		internal override CoreBase ConvertBase (dynamic e)
		{
			return new Contributors()
			{
				Id = (long)e.id,
				Id_Str = (string)e.id_str,
				ScreenName = (string)e.screen_name
			};
		}
	}
	public class Coordinates : CoreBase
	{
		internal override CoreBase ConvertBase (dynamic e)
		{
			
		}
	}
}


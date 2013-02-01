using System;

namespace CoreTweet
{
	public class Contributors : CoreBase
	{
		public long Id;
		public string Id_Str;
		public string ScreenName;
		internal override CoreBase Convert (dynamic e)
		{
			return new Contributors()
			{
				Id = (long)e.id,
				Id_Str = (string)e.id_str,
				ScreenName = (string)e.screen_name
			};
		}
	}
}


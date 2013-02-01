using System;
using System.Dynamic;
using System.Reflection;

namespace CoreTweet
{
	public abstract class CoreBase
	{
		internal static T Converter<T>(dynamic e)
			where T : CoreBase
		{
			return (T)((T)Activator.CreateInstance<T>()).Convert(e);
		}
		internal abstract CoreBase Convert(dynamic e);
	}
}


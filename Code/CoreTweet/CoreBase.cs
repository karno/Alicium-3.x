using System;
using System.Dynamic;

namespace CoreTweet
{
	public abstract class CoreBase
	{
		/// <summary>
		/// この子を呼べばTに対応するConvert()を呼んでdynamic objectをstatic objectに変換してくれます
		/// </summary>
		internal static T Converter<T>(dynamic e)
			where T : CoreBase
		{
			return (T)((T)Activator.CreateInstance<T>()).Convert(e);
		}
		/// <summary>
		/// この子をそれぞれのクラスに実装して具体的な変換を行います
		/// </summary>
		internal abstract CoreBase Convert(dynamic e);
	}
}


using System;

namespace CoreTweet
{
    public abstract class CoreBase
    {
        /// <summary>
        /// この子を呼べばTに対応するConvert()を呼んでdynamic objectをstatic objectに変換してくれます
        /// </summary>
        internal static T Convert<T>(dynamic e)
            where T : CoreBase
        {
            var instance = Activator.CreateInstance<T>();
            instance.ConvertBase(e);
            return instance;
        }
        /// <summary>
        /// この子をそれぞれのクラスに実装して具体的な変換を行います
        /// </summary>
        internal abstract void ConvertBase(dynamic e);
    }
}


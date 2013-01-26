using System;
using System.IO;
using System.Text;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;

namespace Grimoire
{
	/// <summary>
	/// Useful functions.
	/// </summary>
    public class Magic
    {
		/// <summary>
		/// Read an instance of class from file written in XML.
		/// </summary>
		/// <returns>
		/// The instance saved in the file.
		/// </returns>
		/// <param name='path'>
		/// Path you want to read.
		/// </param>
		/// <typeparam name='T'>
		/// The 1st type parameter.
		/// </typeparam>
        public static T XmlFRead<T>(string path)
        {
            using (var fs = File.OpenRead(path))
            {
                var f = new System.Xml.Serialization.XmlSerializer(typeof(T));
                T obj = (T)f.Deserialize(fs);
                return obj;
            }
        }
		/// <summary>
		/// Save an instance to file as XML.
		/// </summary>
		/// <param name='obj'>
		/// Object you want to save.
		/// </param>
		/// <param name='path'>
		/// Path you want to save to.
		/// </param>
		/// <typeparam name='T'>
		/// The 1st type parameter.
		/// </typeparam>
        public static void XmlFWrite<T>(T obj, string path)
        {
            using (var fs = File.OpenWrite(path))
            {
                var bf = new System.Xml.Serialization.XmlSerializer(typeof(T));
                bf.Serialize(fs, obj);
            }
        }
		/// <summary>
		/// Encode string to Url.
		/// </summary>
		/// <returns>
		/// The Url.
		/// </returns>
		/// <param name='value'>
		/// String you want to encode.
		/// </param>
        public static string UrlEncode(string value)
        {
            string unreserved = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-_.~";
            StringBuilder result = new StringBuilder();
            byte[] data = Encoding.UTF8.GetBytes(value);
            foreach (byte b in data)
            {
                if (b < 0x80 && unreserved.IndexOf((char)b) != -1)
                    result.Append((char)b);
                else
                    result.Append('%' + String.Format("{0:X2}", (int)b));
            }
            return result.ToString();
        }
        public static string FRead(string path, Encoding e)
        {
            using (var streamReader = new StreamReader(path, e))
            {
                string result = streamReader.ReadToEnd();
                return result;
            }
        }
        public static void FWrite(string value, string path, Encoding e)
        {
            using (var streamWriter = new StreamWriter(File.Create(path), e))
            {
                streamWriter.Write(value);
            }
        }        
	 	public static string[] CutString(string sep, string str)
        {
            string[] result;
            try
            {
                str = str.Replace("\r", "");
                var separator = new string[]
				{
					sep
				};
                var array = str.Split(separator, StringSplitOptions.RemoveEmptyEntries);
                result = array;
            }
            catch
            {
                result = new string[0];
            }
            return result;
        }
    }
}
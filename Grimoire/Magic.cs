using System;
using System.IO;
using System.Text;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;

namespace Grimoire
{
    public class Magic
    {
        public static T XmlFRead<T>(string path)
        {
            using (var fs = File.OpenRead(path))
            {
                var f = new System.Xml.Serialization.XmlSerializer(typeof(T));
                T obj = (T)f.Deserialize(fs);
                return obj;
            }
        }
        public static void XmlFWrite<T>(T obj, string path)
        {
            using (var fs = File.OpenWrite(path))
            {
                var bf = new System.Xml.Serialization.XmlSerializer(typeof(T));
                bf.Serialize(fs, obj);
            }
        }
        public static T XmlDecode<T>(string XML)
        {
            using (var fs = new StringReader(XML))
            {
                var f = new System.Xml.Serialization.XmlSerializer(typeof(T));
                T obj = (T)f.Deserialize(fs);
                return obj;
            }
        }
        public static string XmlEncode<T>(T obj)
        {
            using (var fs = new StringWriter())
            {
                var bf = new System.Xml.Serialization.XmlSerializer(typeof(T));
                bf.Serialize(fs, obj);
                return fs.ToString();
            }
        }
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
        public static string FRead(string path)
        {
            using (var streamReader = new StreamReader(path, Encoding.Unicode))
            {
                string result = streamReader.ReadToEnd();
                return result;
            }
        }
        public static void FWrite(string value, string path)
        {
            using (var streamWriter = new StreamWriter(File.Create(path), Encoding.Unicode))
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
        public static object CreateInstance(string name, params object[] args)
        {
            return Activator.CreateInstance(Type.GetType(name), args);
        }
    }
}
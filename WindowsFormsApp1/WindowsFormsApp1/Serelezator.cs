using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    class Serelezator
    {
		public static byte[] Serialize<figure>(List<figure> objects)
		{
			string str = "";
			foreach (var o in objects)
			{
				string s = "";
				Type objectType = o.GetType();
				s += $"{objectType.FullName}";

				var fields = get(objectType);
				foreach (var f in fields)
				{
					s += $":{f.Name}:{f.GetValue(o)}";
				}
				str += s + " ";
				
			}
			str = str.Remove(str.Length - 1, 1);
			var bytes = Encoding.UTF8.GetBytes(str);
			return bytes;
		}
		public static List<type> Deserialize<type>(byte[] objects)
		{			
			var binString = System.Text.Encoding.Default.GetString(objects);
			string[] elements = binString.Split(' ');
			var figuresList = new List<type>();
			foreach (var element in elements)
			{
				string[] stringFields = element.Split(':');
				Type elementType = Type.GetType(stringFields[0], false, true);
				var figures = (type)Activator.CreateInstance(elementType);

				Dictionary<string, string> Dictelement = new Dictionary<string, string>();
				for (int i = 1; i < stringFields.Length; i += 2)
				{
					Dictelement.Add(stringFields[i], stringFields[i + 1]);
				}
				var fields = get(elementType);
				foreach (var f in fields)
				{
					if (f.FieldType.Equals(typeof(string)))
					{
						f.SetValue(figures, Dictelement[f.Name]);
					}
					else
					{
						f.SetValue(figures, int.Parse(Dictelement[f.Name]));
					}
				}
				figuresList.Add(figures);
			}
			return figuresList;
		}
		private static FieldInfo[] get(Type type)
		{
			List<FieldInfo> listOfFields = new List<FieldInfo>();
			do
			{
				FieldInfo[] infos = type.GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
				listOfFields.AddRange(infos);
				type = type.BaseType;

			} while (type != null);
			FieldInfo[] fields = listOfFields.ToArray();
			return fields;
		}
	}
}
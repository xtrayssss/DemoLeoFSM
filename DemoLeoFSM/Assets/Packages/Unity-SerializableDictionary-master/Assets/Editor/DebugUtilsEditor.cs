﻿using System.Text;
using Packages.Assets.SerializableDictionary.Editor;
using UnityEditor;

namespace Packages.Assets.Editor
{
	public static class DebugUtilsEditor
	{
		public static string ToString(SerializedProperty property)
		{
			StringBuilder sb = new StringBuilder();
			var iterator = property.Copy();
			var end = property.GetEndProperty();
			do
			{
				sb.AppendLine(iterator.propertyPath + " (" + iterator.type + " " + iterator.propertyType + ") = "
				              + SerializableDictionaryPropertyDrawer.GetPropertyValue(iterator)
#if UNITY_5_6_OR_NEWER
				              + (iterator.isArray ? " (" + iterator.arrayElementType + ")" : "")
#endif
				);
			} while(iterator.Next(true) && iterator.propertyPath != end.propertyPath);
			return sb.ToString();
		}
	}
}

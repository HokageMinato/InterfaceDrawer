using UnityEngine;
using UnityEditor;
using System.Linq;
using System.Reflection;
using NMSerializer.Runtime;
using System;
using UnityEngine.UIElements;
using Unity.Properties;

namespace Thor.EditorExtensions
{

    [CustomPropertyDrawer(typeof(SerializedClass),true)]
    public class NMClassDrawer : PropertyDrawer
    {

        #region PRIVATE_SERIALIZED_VARS
        #endregion


        #region PRIVATE_VARS
        private const string NO_ATTRIB_DEFINED = "No attributes defined";

        private bool foldout = false;
        private float foldoutHeightMultiplier;
        #endregion


        #region PRIVATE_PROPERTIES
        #endregion


        #region PUBLIC_VARS
        #endregion


        #region PUBLIC_PROPERTIES
        #endregion


        #region UNITY_CALLBAKCS

        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            base.OnGUI(position, property, label);
            GetBaseTypes(property);


            //CalculateExpandedFoldoutHeight(labels);

            //EditorGUI.BeginProperty(position, label, property);
            //position.height = EditorGUIUtility.singleLineHeight;
            //foldout = EditorGUI.Foldout(position, foldout, label);


            //if (foldout)
            //{
            //    for (int i = 0; i < labels.Length; i++)
            //    {
            //        string item = labels[i];

            //        position.y += GetInterPropertyDifference();
            //        string labelValue = item;
            //        string tupleFieldName = $"v{i + 1}";

            //        SerializedProperty tupleFieldAsProperty = property.FindPropertyRelative(tupleFieldName);
            //        if (tupleFieldAsProperty != null)
            //            EditorGUI.PropertyField(position, property.FindPropertyRelative(tupleFieldName), new GUIContent(labelValue));
            //        else
            //            EditorGUI.LabelField(position, new GUIContent($"Non Serializable Datatype,inspector wont show them, Accessible from .{tupleFieldName} accessor"));

            //    }

            //    SerializedProperty nameMap = property.FindPropertyRelative("nameMap");

            //    if (nameMap.arraySize != labels.Length)
            //    {
            //        nameMap.ClearArray();

            //        for (int i = 0; i < labels.Length; i++)
            //            nameMap.InsertArrayElementAtIndex(i);
            //    }

            //    for (int i = 0; i < labels.Length; i++)
            //    {
            //        SerializedProperty arrayElement = nameMap.GetArrayElementAtIndex(i);
            //        arrayElement.stringValue = labels[i];
            //    }
            //}

            //EditorGUI.EndProperty();

        }

        private void CalculateExpandedFoldoutHeight(string[] labels)
        {
            foldoutHeightMultiplier = (22 + (GetInterPropertyDifference() * labels.Length)) / EditorGUIUtility.singleLineHeight;
        }

        private static float GetInterPropertyDifference()
        {
            return (EditorGUIUtility.singleLineHeight + 2f) * 1.08f;
        }

        private Type GetBaseTypes(SerializedProperty property)
        {

            Debug.Log(property.type);// +" "+ Type.GetType(property.type, true, false));
            Type[] types = Type.GetType(property.type).GetNestedTypes();

            string tp= string.Empty;
            foreach (var item in types)
            {
                tp += item.Name;
            }
            Debug.Log(tp);

            return fieldInfo.ReflectedType;
        }

        //public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
        //{
        //    if (foldout)
        //    {
        //        return foldoutHeightMultiplier * EditorGUIUtility.singleLineHeight; // Account for label and two properties
        //    }
        //    else
        //    {
        //        return EditorGUIUtility.singleLineHeight; // Only account for label
        //    }
        //}

        #endregion


        #region CONSTRUCTOR
        #endregion


        #region PRIVATE_METHODS
        #endregion


        #region PUBLIC_METHODS
        #endregion


        #region EVENT_CALLBACKS
        #endregion


        #region COROUTINES
        #endregion


        #region INNERCLASS_DEFINITIONS
        #endregion


        #region EDITOR_ACCESSORS_OR_HELPERS
#if UNITY_EDITOR

#endif
        #endregion


    }
}

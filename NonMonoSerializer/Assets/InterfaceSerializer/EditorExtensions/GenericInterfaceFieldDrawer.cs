using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityEditor;
using UnityEngine;
using InterfaceDrawer.Runtime;

namespace InterfaceDrawer.EditorExtension
{
    [CustomPropertyDrawer(typeof(InterfaceHolder<>))]
    public class GenericInterfaceFieldDrawer : PropertyDrawer
    {

        #region PRIVATE_SERIALIZED_VARS
        #endregion


        #region PRIVATE_VARS
        private const string NO_ATTRIB_DEFINED = "No attributes defined";
        private string fieldName = string.Empty;
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
            position.height = EditorGUIUtility.singleLineHeight;

            EditorGUI.BeginProperty(position, label, property);
            SerializedProperty InterfaceHolderInstanceField = FindMonobehaviourFieldName(property);
            if (InterfaceHolderInstanceField != null)
            {
                EditorGUI.ObjectField(position, InterfaceHolderInstanceField, GetFieldType(), new GUIContent(GetFieldName()));
            }
            EditorGUI.EndProperty();
        }

        private static SerializedProperty FindMonobehaviourFieldName(SerializedProperty property)
        {
            return property.FindPropertyRelative(InterfaceHolder<IMonoInterface>.InstancePropertyName);
        }

        private Type GetFieldType() 
        {
            return fieldInfo.FieldType.GetGenericArguments()[0];
        }

        private string GetFieldName()
        {
            if (fieldName != string.Empty)
                return fieldName;

            char[] nm = fieldInfo.Name.ToCharArray();
            nm[0] = char.ToUpper(nm[0]);
            fieldName = new string(nm);

            return fieldName;
        }
        
        #endregion


        #region CONSTRUCTOR
        #endregion


        #region PRIVATE_METHODS
        private static float GetInterPropertyDifference()
        {
            return (EditorGUIUtility.singleLineHeight + 2f) * 1.08f;
        }

        private bool logged = false;
        private Type[] GetAllowedTypes()
        {
            InterfaceFieldAttribute typeAttributes = this.fieldInfo.GetCustomAttributes(typeof(InterfaceFieldAttribute), true).FirstOrDefault() as InterfaceFieldAttribute;
            if (typeAttributes == null)
                return new Type[] { typeof(IMonoInterface) };

            return typeAttributes.AllowedInterfaceTypes;
        }

        private bool DoesTypeBelongToAnyTargetType(Type targetType, Type[] interfaceTypes)
        {
            foreach (Type interfaceType in interfaceTypes)
            {
                if (interfaceType.IsAssignableFrom(targetType))
                {
                    return true;
                }
            }

            return false;
        }


        private void LogTypes(Type[] collection)
        {
            if (logged)
                return;
            string items = string.Empty;
            foreach (var item in collection)
            {
                items += $"{item.Name} \n";
            }
            Debug.Log(items);
            logged = true;
        }
        #endregion


        #region PROTECTED_METHODS
        #endregion


        #region PUBLIC_METHODS
        #endregion


        #region EVENT_CALLBACKS
        #endregion


        #region COROUTINES
        #endregion

        #region UI_CALLBACKS
        #endregion

        #region INNERCLASS_DEFINITIONS
        #endregion


        #region EDITOR_ACCESSORS_OR_HELPERS
#if UNITY_EDITOR

#endif
        #endregion


    }
}

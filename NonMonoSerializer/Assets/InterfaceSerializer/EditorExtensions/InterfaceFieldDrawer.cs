using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using UnityEditor;
using UnityEngine;
using Component = UnityEngine.Component;
using InterfaceDrawer.Runtime;

namespace InterfaceDrawer.EditorExtension
{
    [CustomPropertyDrawer(typeof(InterfaceHolder))]
    public class InterfaceFieldDrawer : PropertyDrawer
    {

        #region PRIVATE_SERIALIZED_VARS
        #endregion


        #region PRIVATE_VARS
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
            // LogTypes();
            position.height = EditorGUIUtility.singleLineHeight;

            EditorGUI.BeginProperty(position, label, property);

            SerializedProperty interfaceHolderInstanceField = FindInterfaceHolderProperty(property);
            if (interfaceHolderInstanceField == null)
            {
                Debug.LogError($"InterfaceField Cant be found, Make sure fieldName:{InterfaceHolder.InstancePropertyName} is set in script properly");
                EditorGUI.EndProperty();
                return;
            }

            EditorGUI.ObjectField(position, interfaceHolderInstanceField, new GUIContent(GetFieldName()));
            if (interfaceHolderInstanceField.objectReferenceValue == null)
            {

                EditorGUI.EndProperty();
                return;
            }


            if (DoesValueBelongToAllowedType(interfaceHolderInstanceField))
            {
                EditorGUI.EndProperty();
                return;
            }

            if (IsGameObjectSuppliedAsValue(interfaceHolderInstanceField))
            {
                var foundComponent = FindAllowedTypeInstance_FirstOrDefault(interfaceHolderInstanceField);
                interfaceHolderInstanceField.objectReferenceValue = foundComponent;
            }
            else
            {
                interfaceHolderInstanceField.objectReferenceValue = null;
                EditorGUI.EndProperty();
                return;
            }
        }

        private Component FindAllowedTypeInstance_FirstOrDefault(SerializedProperty interfaceField)
        {
            Type[] allowedTypes = GetAllowedTypes();
            GameObject go = interfaceField.objectReferenceValue as GameObject;
            foreach (var item in allowedTypes)
            {
                var allowedTypeInstance = go.GetComponent(item);
                if (allowedTypeInstance != null)
                {
                    return allowedTypeInstance;
                }
            }
            return null;
        }

        private bool DoesValueBelongToAllowedType(SerializedProperty interfaceField)
        {
            Type objectRefType = interfaceField.objectReferenceValue.GetType();
            Type[] allowedTypes = GetAllowedTypes();
            return DoesTypeBelongToAnyTargetType(objectRefType, allowedTypes);
        }

        private bool IsGameObjectSuppliedAsValue(SerializedProperty interfaceField)
        {
            GameObject go = interfaceField.objectReferenceValue as GameObject;
            return (go != null);
        }

        private string GetFieldName()
        {
            char[] nm = fieldInfo.Name.ToCharArray();
            nm[0] = char.ToUpper(nm[0]);
            return new string(nm);
        }
        #endregion


        #region CONSTRUCTOR
        #endregion


        #region PRIVATE_METHODS
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
        #endregion


        #region PROTECTED_METHODS
        protected virtual SerializedProperty FindInterfaceHolderProperty(SerializedProperty property)
        {
            return property.FindPropertyRelative(InterfaceHolder.InstancePropertyName);
        }

        protected virtual Type[] GetAllowedTypes()
        {
            InterfaceFieldAttribute typeAttributes = this.fieldInfo.GetCustomAttributes(typeof(InterfaceFieldAttribute), true).FirstOrDefault() as InterfaceFieldAttribute;
            if (typeAttributes == null)
                return new Type[] { typeof(IMonoInterface) };

            return typeAttributes.AllowedInterfaceTypes;
        }
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

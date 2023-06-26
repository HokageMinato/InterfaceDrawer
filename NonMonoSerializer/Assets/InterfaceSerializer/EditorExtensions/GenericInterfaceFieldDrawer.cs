using InterfaceDrawer.EditorExtension;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using InterfaceDrawer.Runtime;
using UnityEditor;
using UnityEngine;

namespace InterfaceDrawer.EditorExtension
{
    [CustomPropertyDrawer(typeof(InterfaceHolder<>))]
    public class GenericInterfaceFieldDrawer : InterfaceFieldDrawer
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

        protected override SerializedProperty FindInterfaceHolderProperty(SerializedProperty property)
        {
            return property.FindPropertyRelative(InterfaceHolder<IMonoInterface>.InstancePropertyName);
        }

        protected override Type[] GetAllowedTypes()
        {
            return fieldInfo.FieldType.GetGenericArguments();
        }
        #endregion


        #region CONSTRUCTOR
        #endregion


        #region PRIVATE_METHODS

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

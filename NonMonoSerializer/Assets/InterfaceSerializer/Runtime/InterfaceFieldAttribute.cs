using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace InterfaceDrawer.Runtime
{
    [AttributeUsage(AttributeTargets.Field,AllowMultiple =false,Inherited = true)]
    public class InterfaceFieldAttribute : Attribute
    {

        #region PRIVATE_SERIALIZED_VARS
        #endregion


        #region PRIVATE_VARS
        private Type[] allowedTypes;
        #endregion


        #region PRIVATE_PROPERTIES
        #endregion


        #region PUBLIC_VARS
        #endregion


        #region PUBLIC_PROPERTIES
        public Type[] AllowedInterfaceTypes { get { return allowedTypes; } }
        #endregion


        #region CONSTRUCTOR
        public InterfaceFieldAttribute(Type allowedType)
        {
            CheckType(allowedType);
            allowedTypes = new List<Type>() { allowedType }.ToArray();
        }

        public InterfaceFieldAttribute(Type allowedType1, Type allowedType2)
        {
            CheckType(allowedType1);
            CheckType(allowedType2);
            allowedTypes = new List<Type>() { allowedType1, allowedType2 }.ToArray();
        }

        public InterfaceFieldAttribute(Type allowedType1, Type allowedType2, Type allowedType3)
        {
            CheckType(allowedType1);
            CheckType(allowedType2);
            CheckType(allowedType3);
            allowedTypes = new List<Type>() { allowedType1, allowedType2, allowedType3 }.ToArray();
        }

        public InterfaceFieldAttribute(Type allowedType1, Type allowedType2, Type allowedType3, Type allowedType4)
        {
            CheckType(allowedType1);
            CheckType(allowedType2);
            CheckType(allowedType3);
            CheckType(allowedType4);
            allowedTypes = new List<Type>() { allowedType1, allowedType2, allowedType3, allowedType4 }.ToArray();
        }

        public InterfaceFieldAttribute(Type allowedType1, Type allowedType2, Type allowedType3, Type allowedType4, Type allowedType5)
        {
            CheckType(allowedType1);
            CheckType(allowedType2);
            CheckType(allowedType3);
            CheckType(allowedType4);
            CheckType(allowedType5);
            allowedTypes = new List<Type>() { allowedType1, allowedType2, allowedType3, allowedType4, allowedType5 }.ToArray();
        }

        public InterfaceFieldAttribute(Type allowedType1, Type allowedType2, Type allowedType3, Type allowedType4, Type allowedType5, Type allowedType6)
        {
            CheckType(allowedType1);
            CheckType(allowedType2);
            CheckType(allowedType3);
            CheckType(allowedType4);
            CheckType(allowedType5);
            CheckType(allowedType6);
            allowedTypes = new List<Type>() { allowedType1, allowedType2, allowedType3, allowedType4, allowedType5, allowedType6 }.ToArray();
        }

        public InterfaceFieldAttribute(Type allowedType1, Type allowedType2, Type allowedType3, Type allowedType4, Type allowedType5, Type allowedType6, Type allowedType7)
        {
            CheckType(allowedType1);
            CheckType(allowedType2);
            CheckType(allowedType3);
            CheckType(allowedType4);
            CheckType(allowedType5);
            CheckType(allowedType6);
            CheckType(allowedType7);
            allowedTypes = new List<Type>() { allowedType1, allowedType2, allowedType3, allowedType4, allowedType5, allowedType6, allowedType7 }.ToArray();
        }

        public InterfaceFieldAttribute(Type allowedType1, Type allowedType2, Type allowedType3, Type allowedType4, Type allowedType5, Type allowedType6, Type allowedType7, Type allowedType8)
        {
            CheckType(allowedType1);
            CheckType(allowedType2);
            CheckType(allowedType3);
            CheckType(allowedType4);
            CheckType(allowedType5);
            CheckType(allowedType6);
            CheckType(allowedType7);
            CheckType(allowedType8);
            allowedTypes = new List<Type>() { allowedType1, allowedType2, allowedType3, allowedType4, allowedType5, allowedType6, allowedType7, allowedType8 }.ToArray();
        }

        #endregion


        #region PRIVATE_METHODS
        private static void CheckType(Type interfaceType)
        {
            CheckForNonInterfaceType(interfaceType);
           // CheckForNonInheritenceWith(typeof(IMonoInterface), interfaceType);
        }

        private static void CheckForNonInheritenceWith(Type parentType, Type interfaceType)
        {
            if(!parentType.GetInterfaces().ToList().Contains(interfaceType))
                throw new Exception($"Interface type {interfaceType.Name} doesnt derive from {nameof(IMonoInterface)}");
        }

        private static void CheckForNonInterfaceType(Type interfaceType)
        {
            if (!interfaceType.IsInterface)
                throw new Exception($"Non interface type {interfaceType.Name} provided");
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

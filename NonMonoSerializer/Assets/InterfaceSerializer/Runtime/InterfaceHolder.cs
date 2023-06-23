using System;
using UnityEngine;


namespace InterfaceDrawer.Runtime
{
    [Serializable]
    public class InterfaceHolder
    {

        #region PRIVATE_SERIALIZED_VARS
        [HideInInspector][SerializeField] private UnityEngine.Object instance;
        #endregion

        #region PRIVATE_VARS
        private IMonoInterface cachedVal;
        private bool isValCached = false;
        #endregion


        #region PRIVATE_PROPERTIES
        #endregion


        #region PUBLIC_VARS
        public static string InstancePropertyName { get { return nameof(instance); } }
        #endregion


        #region PUBLIC_PROPERTIES
        public T GetValue<T>() where T : IMonoInterface
        {
            if (!IsValueCached())
                CacheTypeCastedValue();

            return (T)cachedVal ;
        }
        #endregion

        #region PRIVATE_METHODS
        private void CacheTypeCastedValue()
        {
            cachedVal = (IMonoInterface)instance;
            isValCached = true;
        }

        private bool IsValueCached()
        {
            return isValCached;
        }
        #endregion

    }


    [Serializable]
    public class InterfaceHolder<T> where T : IMonoInterface
    {

        #region PRIVATE_SERIALIZED_VARS
        [HideInInspector][SerializeField] private UnityEngine.Object instance;
        #endregion

        #region PRIVATE_VARS
        private T cachedVal;
        private bool isValCached = false;
        #endregion


        #region PRIVATE_PROPERTIES
        #endregion


        #region PUBLIC_VARS
        public static string InstancePropertyName { get { return nameof(instance); } }

        #endregion


        #region PUBLIC_PROPERTIES
        public T Value
        {
            get 
            {
                if (!IsValueCached()) 
                    CacheTypeCastedValue();

                return cachedVal;
            }
        
        }

        private void CacheTypeCastedValue()
        {
            cachedVal = (T)(object)instance;
            isValCached = true;
        }

        private bool IsValueCached()
        {
            return isValCached;
        }
        #endregion

    }

}

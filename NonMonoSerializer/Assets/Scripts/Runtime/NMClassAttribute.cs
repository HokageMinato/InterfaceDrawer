using System;
using System.Collections.Generic;
using UnityEngine;

namespace NMSerializer.Runtime
{
    [AttributeUsage(AttributeTargets.Field, AllowMultiple = false, Inherited = false)]
    public class NMClassAttribute : Attribute
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

		public MonoBehaviour targ;

		public NMClassAttribute(MonoBehaviour target) 
		{
			targ = target;
		}

		#endregion


		#region UNITY_CALLBAKCS

		void Awake()
		{

		}

		void OnEnable()
		{

		}

		void Start()
		{

		}

		void Update()
		{

		}

		void OnDisable()
		{

		}

		void OnDestroy()
		{

		}

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
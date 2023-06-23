using System.Collections.Generic;
using UnityEngine;

public class Triangle : MonoBehaviour, IShape , ICorneredShape 
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
    public GameObject i_gameObject => gameObject;

    public Transform i_Transform => transform;

    public int TotalCorners => 3;

    #endregion


    #region PUBLIC_METHODS
    public void SayName()
    {
        Debug.Log("Im Triangle");
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


    #region PROTECTED_METHODS
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


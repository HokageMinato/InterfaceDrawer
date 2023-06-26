using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using InterfaceDrawer;
using InterfaceDrawer.Runtime;


public interface IShape : IMonoInterface
{
    public void SayName();
}

public interface ICorneredShape : IMonoInterface
{
    public int TotalCorners { get; }
}


public class Example : MonoBehaviour
{
    #region PUBLIC_VARS
    [InterfaceField(typeof(IShape))] //Single Type Restriction
    public InterfaceHolder[] shape1;

    [InterfaceField(typeof(IShape),typeof(ICorneredShape))] //Multiple Types Restriction
    public InterfaceHolder shape2;


    public InterfaceHolder<IShape> shape3; //Generic for optimised access.
                                           //(Presently supports single field only)
    #endregion


    #region PRIVATE_PROPERTIES
    private IShape _shape1 { get { return null; } }
    
    private IShape _shape2 { get { return shape2.GetValue<IShape>(); } }

    private IShape _shape3 { get { return shape3.Value; } }
    #endregion


    private void PrintShapeName(IShape shape)
    {
        shape.SayName();
    }


    #region PUBLIC_METHODS
    public void Start()
    {
        PrintShapeName(_shape1);
        PrintShapeName(_shape2);
        PrintShapeName(_shape3);
        PrintShapeCorners(__shape2);
    }


    private void PrintShapeCorners(ICorneredShape corneredShape) 
    {
        Debug.Log($"Total Corners {corneredShape.TotalCorners}");
    }
    //NOTE:
    //Assign property according to the type you want to inject from inspector.
    //Will throw castException if you assign ICorneredShape and request IShape.
    private ICorneredShape __shape2 { get { return shape2.GetValue<ICorneredShape>(); } }
    #endregion
}


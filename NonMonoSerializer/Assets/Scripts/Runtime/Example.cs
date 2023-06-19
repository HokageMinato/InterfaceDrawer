using NMSerializer.Runtime;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace NMSerializer.Runtime
{
    public class Example : MonoBehaviour
    {
        public int i;
        public ExampleClass exampleClass;
        //public ExampleClassA exA;
        //public ExampleClassB exB;
    }

    [Serializable]
    public class SerializedClass
    {
        public int selectedType;
    }


    [Serializable]
    public class ExampleClass : SerializedClass
    {
        public int basePropInt;
        public float basePropFloat;
        public string basePropString;
        public ExampleClass classRef;
    }

    [Serializable]
    public class ExampleClassA : ExampleClass
    {
        public int ExtraA1;
        public int ExtraA2;
        public int ExtraA3;
        public int ExtraA4;
        public ExampleClass ExtraAOb;
    }

    [Serializable]
    public class ExampleClassB : ExampleClass
    {
        public string ExtraB;
        public string ExtraB1;
        public string ExtraB2;
        public string ExtraB3;
        public ExampleClass ExtraBb;
    }
}
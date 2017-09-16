using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Singleton created to work PoolManager
//Based off of VFS Project
public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{
    public static T instance
    {
        get
        {
            if (_instance == null)
            {                 
                _instance = FindObjectOfType<T>();
            }
            return _instance;
        }
    }

    private static T _instance;
}
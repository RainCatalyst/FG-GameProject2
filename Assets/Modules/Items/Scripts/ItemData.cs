using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "NewItem", menuName = "Data/ItemData")]
    public class ItemData : ScriptableObject
    {
        public string Id => _id;
        public GameObject GameObject => gameObject;

        [SerializeField]
        private string _id;
        [SerializeField]
        public GameObject gameObject;

    public void Print()
    {
        Debug.Log(_id);
    }
    }

using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "NewItem", menuName = "Data")]
    public class ItemData : ScriptableObject
    {
        public string Id => _id;
        public GameObject GameObject => gameObject;
        public bool IsItem => _isItem;
        public string GrindedId => String.IsNullOrEmpty(_grindedId) ? null : _grindedId; //?

        [SerializeField]
        private string _id;
        [SerializeField]
        public GameObject gameObject;
        [SerializeField]
        private bool _isItem;
        [SerializeField]
        private string _grindedId;
    }

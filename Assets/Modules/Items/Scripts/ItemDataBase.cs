using System.Collections.Generic;
using System.Linq;
using UnityEngine;

    public class ItemDatabase : MonoSingleton<ItemDatabase>
    {
        public static ItemData Get(string id) => id == null ? null : _items[id]; //returns a ItemData object. If value of id is null, return null, else return value of the id key from the items dictionary in Instance object.


        protected override void Awake()
        {
            base.Awake();
            LoadItems();
        }

        private void LoadItems()
        {
            _items = new();
            var loadedItems = Resources.LoadAll<ItemData>(_itemsFolder);
            foreach (var item in loadedItems)
            {
                _items.Add(item.Id, item);
            }

            Debug.Log($"Loaded {_items.Count} items.");
        }

        [SerializeField]
        private string _itemsFolder;

        private static Dictionary<string, ItemData> _items = new Dictionary<string, ItemData>();
    }

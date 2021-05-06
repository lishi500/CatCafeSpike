using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : Singleton<InventoryManager>
{
    private float ContinuousCollectMaxTime = 2f;
    private float LastCollectTime;
    private List<StackItem> lastCollectedItems;
    //private UICollectItemController uICollectItemController;

    private List<StackItem> m_tempInventory;
    public List<StackItem> Bag {
        get { return m_tempInventory; }
    }

  

    public delegate void OnItemAddEvent(StackItem item);
    public OnItemAddEvent notifyAddItem;
    public delegate void OnItemRemoveEvent(StackItem item);
    public OnItemRemoveEvent notifyRemoveItem;

    // --------------- test 
    //public TestObj testObj;
    //public StackItem testObj2;
    //public List<TestObj> testObj3;


    // --------------- test 


    public void AddItemList(List<StackItem> items) {
        if (items != null) {
            items.ForEach(item => AddItem(item));
        } 
    }

    public void AddItemSilent(StackItem item) {
        AddItem(item, true);
    }

    public void AddItem(StackItem item, bool silent = false) {
        if (item != null)
        {
            if (!silent) {
                StackItem addedItem = ItemUtils.Instance.MergeAddItem(lastCollectedItems, item, true);
                /*
                FlushUI(addedItem);
                */
            }
          
            AddItemToBag(item);
            // ----------------------------
            //AvaliableItemManager.Instance.AddToTotal(item.item);
            //ActionTracker.Instance.Send(ActionType.Collect, item);
        }
        else {
            Debug.LogError("attempt to add empty item");
        }
    }

    public void AddItemWithoutCollectToBag(StackItem item) {
        if (item != null)
        {
            StackItem addedItem = ItemUtils.Instance.MergeAddItem(lastCollectedItems, item, true);
            /*
            FlushUI(addedItem);
            */
            }
        }

    private void StandardSortInventory() { // highest leve > highest quality
        m_tempInventory.Sort(delegate (StackItem x, StackItem y) {
            if (x.item.level != y.item.level)
            {
                return x.item.level - y.item.level;
            }

            return ItemUtils.Instance.QualityTypeDistance(x.quality, y.quality);
        });
    }


    private void AddItemToBag(StackItem item) {
        ItemUtils.Instance.MergeAddItem(m_tempInventory, item, true);
        StandardSortInventory();
        if (notifyAddItem != null) {
            notifyAddItem(item);
        }
    }

    public List<Item> RetrieveItems(List<StackItem> items, bool allowAbove = false) {
        List<Item> found = RetrieveItems(items);
        // TODO remove multi item

        return found;
    }

    // atomic remove, if not satify, rollback
    public bool RemoveItems(List<StackItem> items) {
        List<Item> found = RetrieveItems(items);
        if (found.Count > 0) {
            items.Select(item => RemoveItem(item));
            return true;
        }

        return false;
    }

    public bool RemoveItem(StackItem item)
    {
        bool removed = ItemUtils.Instance.RemoveItemFromList(Bag, item);
        if (removed) {
            StandardSortInventory();

            if (notifyRemoveItem != null) {
                notifyRemoveItem(item);
            }
        }

        return removed;
    }

    public bool HasEnoughSpace(List<StackItem> items) {
        // TODO , has engough bag space, complete logic
        return true;
    }

    private List<StackItem> RetrieveItem(StackItem item, bool allowAbove = false) {
        List<StackItem> items = ItemUtils.Instance.FindItem(Bag, item, item.stackCount, allowAbove);

        return items;
    }

    /*
    private void FlushUI(StackItem item) {
        if (uICollectItemController != null) {
            LastCollectTime = Time.time;
            uICollectItemController.UpdateItem(item);
        }
    }
    */
   
   /* void OnApplicationQuit()
    {
        ES3.Save("bag", Bag);
        //ES3.Save("testObj", testObj);
        //ES3.Save("testObj2", testObj2);
        //ES3.Save("testObj3", testObj3);

    }*/

    /* We also call OnApplicationPause, which is called when an app goes into the background. */
    //void OnApplicationPause(bool isPaused)
    //{
    //    if (isPaused)
    //        OnApplicationQuit();
    //}

    void LoadInventory() {
        //if (ES3.KeyExists("testObj"))
        //{
        //    Debug.Log("load test Obj");
        //    testObj = ES3.Load<TestObj>("testObj");
        //}
        //else {
        //    testObj = new TestObj();
        //    testObj.a = 55;
        //    testObj.b = gameObject.name;
        //}

        //if (ES3.KeyExists("testObj2"))
        //{
        //    Debug.Log("load test Obj 2");
        //    testObj2 = ES3.Load<StackItem>("testObj2");
        //}
        //else
        //{
        //    testObj2 = new StackItem();
        //    testObj2.stackCount = 15;
        //    testObj2.quality = ItemQualityType.Common;
        //}

        //if (ES3.KeyExists("testObj3"))
        //{
        //    testObj3 = ES3.Load<List<TestObj>>("testObj3");
        //}
        //else {
        //    testObj3 = new List<TestObj>();
        //}

        /*
        if (ES3.KeyExists("bag"))
        {
            tempInventory = ES3.Load<List<StackItem>>("bag", new List<StackItem>());
        }
        else
        {
            tempInventory = new List<StackItem>();
        }*/
    }

    protected override void Awake()
    {
        base.Awake();
        LoadInventory();
        lastCollectedItems = new List<StackItem>();
        /*
        GameObject itemCollectingPanel = GameObject.Find("ItemCollectingPanel");
        if (itemCollectingPanel != null)
        {
            uICollectItemController = itemCollectingPanel.GetComponent<UICollectItemController>();
        } */
    }


    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (lastCollectedItems.Count > 0 && Time.time - LastCollectTime > ContinuousCollectMaxTime) {
            lastCollectedItems.Clear();
        }
    }
}

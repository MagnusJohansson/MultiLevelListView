using System;
using System.Collections.Generic;

namespace MultiLevelListViewApp.Models
{
    public class DataProvider : IDataProvider
    {
        private const int ITEMS_PER_LEVEL = 4;

        private const int MAX_LEVELS = 6;

        public DataProvider()
        {
        }

        public List<BaseItem> GetInitialtems()
        {
            return this.GetSubItems(new GroupItem("root"));
        }

        public List<BaseItem> GetSubItems(BaseItem baseItem)
        {
            List<BaseItem> baseItems;
            BaseItem item;
            int num;
            if (baseItem.GetType() != typeof(GroupItem))
            {
                throw new ArgumentException("GroupItem required");
            }
            GroupItem groupItem = (GroupItem)baseItem;
            if (groupItem.Level < 6)
            {
                List<BaseItem> baseItems1 = new List<BaseItem>(4);
                int level = groupItem.Level + 1;
                int num1 = 0;
                int num2 = 0;
                for (int i = 0; i < 4; i++)
                {
                    if ((i % 2 != 0 ? true : level == 6))
                    {
                        num = num2 + 1;
                        num2 = num;
                        item = new Item(string.Concat("Item: ", num.ToString()));
                    }
                    else
                    {
                        num = num1 + 1;
                        num1 = num;
                        item = new GroupItem(string.Concat("Group ", num.ToString()));
                        ((GroupItem)item).Level = level;
                    }
                    baseItems1.Add(item);
                }
                baseItems = baseItems1;
            }
            else
            {
                baseItems = null;
            }
            return baseItems;
        }

        public bool IsExpandable(BaseItem item)
        {
            return item.GetType() == typeof(GroupItem);
        }
    }
}
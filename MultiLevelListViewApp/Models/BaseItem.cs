namespace MultiLevelListViewApp.Models
{
    public class BaseItem
    {
        public string Name
        {
            get;
            set;
        }

        public BaseItem(string name)
        {
            this.Name = name;
        }

        public static explicit operator BaseItem(Java.Lang.Object v)
        {
            return v.Cast<BaseItem>();
        }
    }
}
namespace MultiLevelListViewApp.Models
{
    public class GroupItem : BaseItem
    {
        public int Level
        {
            get;
            set;
        }

        public GroupItem(string name) : base(name)
        {
            this.Level = 0;
        }
    }
}
using System.Collections.Generic;

namespace MultiLevelListViewApp.Models
{
    public interface IDataProvider
    {
        List<BaseItem> GetInitialtems();

        List<BaseItem> GetSubItems(BaseItem baseItem);

        bool IsExpandable(BaseItem item);
    }
}
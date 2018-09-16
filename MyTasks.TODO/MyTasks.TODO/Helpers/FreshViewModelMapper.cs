using FreshMvvm;
using System;

namespace MyTasks.TODO
{
    public class FreshViewModelMapper : IFreshPageModelMapper
    {
        public string GetPageTypeName(Type pageModelType)
        {
            return pageModelType.AssemblyQualifiedName
                .Replace("ViewModel", "View");
        }
    }
}

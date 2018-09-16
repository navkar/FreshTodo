using static MyTasks.TODO.App;

namespace MyTasks.TODO.ViewModels
{
    public class TabViewModel : FreshMvvm.FreshBasePageModel
    {
        public string Title => "Birdy";

        public TabViewModel()
        {
            
        }

        public override void Init(object initData)
        {
            base.Init(initData);
        }
    }
}
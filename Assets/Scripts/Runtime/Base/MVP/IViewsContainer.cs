using System.Collections.Generic;

public interface IViewsContainer {
    public TView GetView<TView>() where TView : BaseView;
    public List<TView> GetViews<TView>() where TView : BaseView;
}

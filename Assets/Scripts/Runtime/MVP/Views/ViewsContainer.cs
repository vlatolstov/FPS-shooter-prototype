using System;
using System.Collections.Generic;
using System.Linq;

public class ViewsContainer : IViewsContainer
{
    public Dictionary<Type, List<BaseView>> _views = new();

    public ViewsContainer(List<BaseView> views) {
        _views = views.GroupBy(v => v.GetType()).ToDictionary(g => g.Key, g => g.ToList());
    }

    public TView GetView<TView>() where TView : BaseView {
        return _views.ContainsKey(typeof(TView)) ? _views[typeof(TView)].Cast<TView>().FirstOrDefault() : null;
    }

    public List<TView> GetViews<TView>() where TView : BaseView {
        return _views.ContainsKey(typeof(TView)) ? _views[typeof(TView)].Cast<TView>().ToList() : new List<TView>();
    }
}

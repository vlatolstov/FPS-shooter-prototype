using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public abstract class BasePresenter<TModel> where TModel : IModel {
    protected readonly TModel Model;
    protected readonly IViewsContainer ViewsContainer;

    protected BasePresenter(TModel model, IViewsContainer viewsContainer) {
        Model = model;
        ViewsContainer = viewsContainer;
    }
}

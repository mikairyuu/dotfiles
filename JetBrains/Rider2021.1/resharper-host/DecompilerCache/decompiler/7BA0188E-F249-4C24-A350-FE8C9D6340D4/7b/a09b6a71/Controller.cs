// Decompiled with JetBrains decompiler
// Type: Microsoft.AspNetCore.Mvc.Controller
// Assembly: Microsoft.AspNetCore.Mvc.ViewFeatures, Version=5.0.0.0, Culture=neutral, PublicKeyToken=adb9793829ddae60
// MVID: 7BA0188E-F249-4C24-A350-FE8C9D6340D4
// Assembly location: /usr/share/dotnet/shared/Microsoft.AspNetCore.App/5.0.6/Microsoft.AspNetCore.Mvc.ViewFeatures.dll

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading.Tasks;


#nullable enable
namespace Microsoft.AspNetCore.Mvc
{
  public abstract class Controller : 
    ControllerBase,
    IActionFilter,
    IFilterMetadata,
    IAsyncActionFilter,
    IDisposable
  {
    private 
    #nullable disable
    ITempDataDictionary _tempData;
    private DynamicViewData _viewBag;
    private ViewDataDictionary _viewData;

    [ViewDataDictionary]
    public ViewDataDictionary ViewData
    {
      get
      {
        if (this._viewData == null)
          this._viewData = new ViewDataDictionary((IModelMetadataProvider) new EmptyModelMetadataProvider(), this.ControllerContext.ModelState);
        return this._viewData;
      }
      set => this._viewData = value != null ? value : throw new ArgumentException(Resources.ArgumentCannotBeNullOrEmpty, nameof (ViewData));
    }

    public ITempDataDictionary TempData
    {
      get
      {
        if (this._tempData == null)
        {
          HttpContext httpContext = this.HttpContext;
          ITempDataDictionaryFactory dictionaryFactory;
          if (httpContext == null)
          {
            dictionaryFactory = (ITempDataDictionaryFactory) null;
          }
          else
          {
            IServiceProvider requestServices = httpContext.RequestServices;
            dictionaryFactory = requestServices != null ? requestServices.GetRequiredService<ITempDataDictionaryFactory>() : (ITempDataDictionaryFactory) null;
          }
          this._tempData = dictionaryFactory?.GetTempData(this.HttpContext);
        }
        return this._tempData;
      }
      set => this._tempData = value != null ? value : throw new ArgumentNullException(nameof (value));
    }

    public object ViewBag
    {
      get
      {
        if (this._viewBag == null)
          this._viewBag = new DynamicViewData((Func<ViewDataDictionary>) (() => this.ViewData));
        return (object) this._viewBag;
      }
    }

    [NonAction]
    public virtual ViewResult View() => this.View((string) null);

    [NonAction]
    public virtual ViewResult View(string viewName) => this.View(viewName, this.ViewData.Model);

    [NonAction]
    public virtual ViewResult View(object model) => this.View((string) null, model);

    [NonAction]
    public virtual ViewResult View(string viewName, object model)
    {
      this.ViewData.Model = model;
      return new ViewResult()
      {
        ViewName = viewName,
        ViewData = this.ViewData,
        TempData = this.TempData
      };
    }

    [NonAction]
    public virtual PartialViewResult PartialView() => this.PartialView((string) null);

    [NonAction]
    public virtual PartialViewResult PartialView(string viewName) => this.PartialView(viewName, this.ViewData.Model);

    [NonAction]
    public virtual PartialViewResult PartialView(object model) => this.PartialView((string) null, model);

    [NonAction]
    public virtual PartialViewResult PartialView(string viewName, object model)
    {
      this.ViewData.Model = model;
      return new PartialViewResult()
      {
        ViewName = viewName,
        ViewData = this.ViewData,
        TempData = this.TempData
      };
    }

    [NonAction]
    public virtual ViewComponentResult ViewComponent(string componentName) => this.ViewComponent(componentName, (object) null);

    [NonAction]
    public virtual ViewComponentResult ViewComponent(Type componentType) => this.ViewComponent(componentType, (object) null);

    [NonAction]
    public virtual ViewComponentResult ViewComponent(
      string componentName,
      object arguments)
    {
      return new ViewComponentResult()
      {
        ViewComponentName = componentName,
        Arguments = arguments,
        ViewData = this.ViewData,
        TempData = this.TempData
      };
    }

    [NonAction]
    public virtual ViewComponentResult ViewComponent(
      Type componentType,
      object arguments)
    {
      return new ViewComponentResult()
      {
        ViewComponentType = componentType,
        Arguments = arguments,
        ViewData = this.ViewData,
        TempData = this.TempData
      };
    }

    [NonAction]
    public virtual JsonResult Json(object data) => new JsonResult(data);

    [NonAction]
    public virtual JsonResult Json(object data, object serializerSettings) => new JsonResult(data, serializerSettings);

    [NonAction]
    public virtual void OnActionExecuting(ActionExecutingContext context)
    {
    }

    [NonAction]
    public virtual void OnActionExecuted(ActionExecutedContext context)
    {
    }

    [NonAction]
    public virtual Task OnActionExecutionAsync(
      ActionExecutingContext context,
      ActionExecutionDelegate next)
    {
      if (context == null)
        throw new ArgumentNullException(nameof (context));
      if (next == null)
        throw new ArgumentNullException(nameof (next));
      this.OnActionExecuting(context);
      if (context.Result == null)
      {
        Task<ActionExecutedContext> task = next();
        if (!task.IsCompletedSuccessfully)
          return Awaited(this, task);
        this.OnActionExecuted(task.Result);
      }
      return Task.CompletedTask;

      static async Task Awaited(Controller controller, Task<ActionExecutedContext> task)
      {
        Controller controller1 = controller;
        controller1.OnActionExecuted(await task);
        controller1 = (Controller) null;
      }
    }

    public void Dispose() => this.Dispose(true);

    protected virtual void Dispose(bool disposing)
    {
    }
  }
}

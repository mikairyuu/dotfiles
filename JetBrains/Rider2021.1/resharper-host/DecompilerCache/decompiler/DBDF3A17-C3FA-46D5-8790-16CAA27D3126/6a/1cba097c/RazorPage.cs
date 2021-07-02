// Decompiled with JetBrains decompiler
// Type: Microsoft.AspNetCore.Mvc.Razor.RazorPage
// Assembly: Microsoft.AspNetCore.Mvc.Razor, Version=5.0.0.0, Culture=neutral, PublicKeyToken=adb9793829ddae60
// MVID: DBDF3A17-C3FA-46D5-8790-16CAA27D3126
// Assembly location: /usr/share/dotnet/shared/Microsoft.AspNetCore.App/5.0.7/Microsoft.AspNetCore.Mvc.Razor.dll

using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Microsoft.AspNetCore.Mvc.Razor
{
  public abstract class RazorPage : RazorPageBase
  {
    private readonly HashSet<string> _renderedSections = new HashSet<string>((IEqualityComparer<string>) StringComparer.OrdinalIgnoreCase);
    private bool _renderedBody;
    private bool _ignoreBody;
    private HashSet<string> _ignoredSections;

    public HttpContext Context => this.ViewContext?.HttpContext;

    protected virtual IHtmlContent RenderBody()
    {
      if (this.BodyContent == null)
        throw new InvalidOperationException(Resources.FormatRazorPage_MethodCannotBeCalled((object) nameof (RenderBody), (object) this.Path));
      this._renderedBody = true;
      return this.BodyContent;
    }

    public void IgnoreBody() => this._ignoreBody = true;

    public override void DefineSection(string name, RenderAsyncDelegate section)
    {
      if (name == null)
        throw new ArgumentNullException(nameof (name));
      if (section == null)
        throw new ArgumentNullException(nameof (section));
      if (this.SectionWriters.ContainsKey(name))
        throw new InvalidOperationException(Resources.FormatSectionAlreadyDefined((object) name));
      this.SectionWriters[name] = section;
    }

    public bool IsSectionDefined(string name)
    {
      if (name == null)
        throw new ArgumentNullException(nameof (name));
      this.EnsureMethodCanBeInvoked(nameof (IsSectionDefined));
      return this.PreviousSectionWriters.ContainsKey(name);
    }

    public HtmlString RenderSection(string name) => name != null ? this.RenderSection(name, true) : throw new ArgumentNullException(nameof (name));

    public HtmlString RenderSection(string name, bool required)
    {
      if (name == null)
        throw new ArgumentNullException(nameof (name));
      this.EnsureMethodCanBeInvoked(nameof (RenderSection));
      return this.RenderSectionAsyncCore(name, required).GetAwaiter().GetResult();
    }

    public Task<HtmlString> RenderSectionAsync(string name) => name != null ? this.RenderSectionAsync(name, true) : throw new ArgumentNullException(nameof (name));

    public Task<HtmlString> RenderSectionAsync(string name, bool required)
    {
      if (name == null)
        throw new ArgumentNullException(nameof (name));
      this.EnsureMethodCanBeInvoked(nameof (RenderSectionAsync));
      return this.RenderSectionAsyncCore(name, required);
    }

    private async Task<HtmlString> RenderSectionAsyncCore(
      string sectionName,
      bool required)
    {
      RazorPage razorPage = this;
      if (razorPage._renderedSections.Contains(sectionName))
      {
        // ISSUE: explicit non-virtual call
        throw new InvalidOperationException(Resources.FormatSectionAlreadyRendered((object) "RenderSectionAsync", (object) __nonvirtual (razorPage.Path), (object) sectionName));
      }
      RenderAsyncDelegate renderAsyncDelegate;
      // ISSUE: explicit non-virtual call
      if (__nonvirtual (razorPage.PreviousSectionWriters).TryGetValue(sectionName, out renderAsyncDelegate))
      {
        razorPage._renderedSections.Add(sectionName);
        await renderAsyncDelegate();
        return HtmlString.Empty;
      }
      if (required)
      {
        ViewContext viewContext = razorPage.ViewContext;
        throw new InvalidOperationException(Resources.FormatSectionNotDefined((object) viewContext.ExecutingFilePath, (object) sectionName, (object) viewContext.View.Path));
      }
      return (HtmlString) null;
    }

    public void IgnoreSection(string sectionName)
    {
      if (sectionName == null)
        throw new ArgumentNullException(nameof (sectionName));
      if (!this.PreviousSectionWriters.ContainsKey(sectionName))
        throw new InvalidOperationException(Resources.FormatSectionNotDefined((object) this.ViewContext.ExecutingFilePath, (object) sectionName, (object) this.ViewContext.View.Path));
      if (this._ignoredSections == null)
        this._ignoredSections = new HashSet<string>((IEqualityComparer<string>) StringComparer.OrdinalIgnoreCase);
      this._ignoredSections.Add(sectionName);
    }

    public override void EnsureRenderedBodyOrSections()
    {
      if (this.PreviousSectionWriters != null && this.PreviousSectionWriters.Count > 0)
      {
        IEnumerable<string> strings = this.PreviousSectionWriters.Keys.Except<string>((IEnumerable<string>) this._renderedSections, (IEqualityComparer<string>) StringComparer.OrdinalIgnoreCase);
        string[] strArray = this._ignoredSections == null ? strings.ToArray<string>() : strings.Except<string>((IEnumerable<string>) this._ignoredSections, (IEqualityComparer<string>) StringComparer.OrdinalIgnoreCase).ToArray<string>();
        if (strArray.Length != 0)
          throw new InvalidOperationException(Resources.FormatSectionsNotRendered((object) this.Path, (object) string.Join(", ", strArray), (object) "IgnoreSection"));
      }
      else if (this.BodyContent != null && !this._renderedBody && !this._ignoreBody)
        throw new InvalidOperationException(Resources.FormatRenderBodyNotCalled((object) "RenderBody", (object) this.Path, (object) "IgnoreBody"));
    }

    public override void BeginContext(int position, int length, bool isLiteral)
    {
    }

    public override void EndContext()
    {
    }

    private void EnsureMethodCanBeInvoked(string methodName)
    {
      if (this.PreviousSectionWriters == null)
        throw new InvalidOperationException(Resources.FormatRazorPage_MethodCannotBeCalled((object) methodName, (object) this.Path));
    }
  }
}

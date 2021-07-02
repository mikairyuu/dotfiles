// Decompiled with JetBrains decompiler
// Type: Microsoft.AspNetCore.Components.NavigationManager
// Assembly: Microsoft.AspNetCore.Components, Version=5.0.0.0, Culture=neutral, PublicKeyToken=adb9793829ddae60
// MVID: 6F87A0E4-7855-4AD1-AAA3-90037B1B1EA9
// Assembly location: /usr/share/dotnet/shared/Microsoft.AspNetCore.App/5.0.6/Microsoft.AspNetCore.Components.dll

using Microsoft.AspNetCore.Components.Routing;
using System;


#nullable enable
namespace Microsoft.AspNetCore.Components
{
  public abstract class NavigationManager
  {
    private EventHandler<LocationChangedEventArgs>? _locationChanged;
    private System.Uri? _baseUri;
    private string? _uri;
    private bool _isInitialized;

    public event EventHandler<LocationChangedEventArgs> LocationChanged
    {
      add
      {
        this.AssertInitialized();
        this._locationChanged += value;
      }
      remove
      {
        this.AssertInitialized();
        this._locationChanged -= value;
      }
    }

    public string BaseUri
    {
      get
      {
        this.AssertInitialized();
        return this._baseUri.OriginalString;
      }
      protected set
      {
        if (value != null)
          value = NavigationManager.NormalizeBaseUri(value);
        this._baseUri = new System.Uri(value, UriKind.Absolute);
      }
    }

    public string Uri
    {
      get
      {
        this.AssertInitialized();
        return this._uri;
      }
      protected set
      {
        NavigationManager.Validate(this._baseUri, value);
        this._uri = value;
      }
    }

    public void NavigateTo(string uri, bool forceLoad = false)
    {
      this.AssertInitialized();
      this.NavigateToCore(uri, forceLoad);
    }

    protected abstract void NavigateToCore(string uri, bool forceLoad);

    protected void Initialize(string baseUri, string uri)
    {
      if (uri == null)
        throw new ArgumentNullException(nameof (uri));
      if (baseUri == null)
        throw new ArgumentNullException(nameof (baseUri));
      this._isInitialized = !this._isInitialized ? true : throw new InvalidOperationException("'" + this.GetType().Name + "' already initialized.");
      this.BaseUri = baseUri;
      this.Uri = uri;
    }

    protected virtual void EnsureInitialized()
    {
    }

    public System.Uri ToAbsoluteUri(string relativeUri)
    {
      this.AssertInitialized();
      return new System.Uri(this._baseUri, relativeUri);
    }

    public string ToBaseRelativePath(string uri)
    {
      if (uri.StartsWith(this._baseUri.OriginalString, StringComparison.Ordinal))
        return uri.Substring(this._baseUri.OriginalString.Length);
      int length = uri.IndexOf('#');
      if (((length < 0 ? uri : uri.Substring(0, length)) + "/").Equals(this._baseUri.OriginalString, StringComparison.Ordinal))
        return uri.Substring(this._baseUri.OriginalString.Length - 1);
      throw new ArgumentException(string.Format("The URI '{0}' is not contained by the base URI '{1}'.", (object) uri, (object) this._baseUri));
    }

    internal static string NormalizeBaseUri(string baseUri)
    {
      int num = baseUri.LastIndexOf('/');
      if (num >= 0)
        baseUri = baseUri.Substring(0, num + 1);
      return baseUri;
    }

    protected void NotifyLocationChanged(bool isInterceptedLink)
    {
      try
      {
        EventHandler<LocationChangedEventArgs> locationChanged = this._locationChanged;
        if (locationChanged == null)
          return;
        locationChanged((object) this, new LocationChangedEventArgs(this._uri, isInterceptedLink));
      }
      catch (Exception ex)
      {
        throw new LocationChangeException("An exception occurred while dispatching a location changed event.", ex);
      }
    }

    private void AssertInitialized()
    {
      if (!this._isInitialized)
        this.EnsureInitialized();
      if (!this._isInitialized)
        throw new InvalidOperationException("'" + this.GetType().Name + "' has not been initialized.");
    }

    private static bool TryGetLengthOfBaseUriPrefix(System.Uri baseUri, string uri, out int length)
    {
      if (uri.StartsWith(baseUri.OriginalString, StringComparison.Ordinal))
      {
        length = baseUri.OriginalString.Length;
        return true;
      }
      int length1 = uri.IndexOf('#');
      if (((length1 < 0 ? uri : uri.Substring(0, length1)) + "/").Equals(baseUri.OriginalString, StringComparison.Ordinal))
      {
        length = baseUri.OriginalString.Length - 1;
        return true;
      }
      length = 0;
      return false;
    }

    private static void Validate(System.Uri? baseUri, string uri)
    {
      if (!(baseUri == (System.Uri) null) && uri != null && !NavigationManager.TryGetLengthOfBaseUriPrefix(baseUri, uri, out int _))
        throw new ArgumentException(string.Format("The URI '{0}' is not contained by the base URI '{1}'.", (object) uri, (object) baseUri));
    }
  }
}

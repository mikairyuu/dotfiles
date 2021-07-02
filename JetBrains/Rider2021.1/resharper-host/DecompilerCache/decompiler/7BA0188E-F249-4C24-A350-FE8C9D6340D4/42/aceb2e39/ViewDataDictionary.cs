// Decompiled with JetBrains decompiler
// Type: Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary
// Assembly: Microsoft.AspNetCore.Mvc.ViewFeatures, Version=5.0.0.0, Culture=neutral, PublicKeyToken=adb9793829ddae60
// MVID: 7BA0188E-F249-4C24-A350-FE8C9D6340D4
// Assembly location: /usr/share/dotnet/shared/Microsoft.AspNetCore.App/5.0.6/Microsoft.AspNetCore.Mvc.ViewFeatures.dll

using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ModelBinding.Metadata;
using Microsoft.Extensions.Internal;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;

namespace Microsoft.AspNetCore.Mvc.ViewFeatures
{
  public class ViewDataDictionary : 
    IDictionary<string, object>,
    ICollection<KeyValuePair<string, object>>,
    IEnumerable<KeyValuePair<string, object>>,
    IEnumerable
  {
    private readonly IDictionary<string, object> _data;
    private readonly Type _declaredModelType;
    private readonly IModelMetadataProvider _metadataProvider;

    public ViewDataDictionary(
      IModelMetadataProvider metadataProvider,
      ModelStateDictionary modelState)
      : this(metadataProvider, modelState, typeof (object))
    {
    }

    public ViewDataDictionary(ViewDataDictionary source)
      : this(source, source.Model, source._declaredModelType)
    {
    }

    internal ViewDataDictionary(IModelMetadataProvider metadataProvider)
      : this(metadataProvider, new ModelStateDictionary())
    {
    }

    protected ViewDataDictionary(IModelMetadataProvider metadataProvider, Type declaredModelType)
      : this(metadataProvider, new ModelStateDictionary(), declaredModelType)
    {
    }

    protected ViewDataDictionary(
      IModelMetadataProvider metadataProvider,
      ModelStateDictionary modelState,
      Type declaredModelType)
      : this(metadataProvider, modelState, declaredModelType, (IDictionary<string, object>) new Dictionary<string, object>((IEqualityComparer<string>) StringComparer.OrdinalIgnoreCase), new TemplateInfo())
    {
      if (metadataProvider == null)
        throw new ArgumentNullException(nameof (metadataProvider));
      if (modelState == null)
        throw new ArgumentNullException(nameof (modelState));
      this.ModelExplorer = !(declaredModelType == (Type) null) ? this._metadataProvider.GetModelExplorerForType(declaredModelType, (object) null) : throw new ArgumentNullException(nameof (declaredModelType));
    }

    protected ViewDataDictionary(ViewDataDictionary source, Type declaredModelType)
      : this(source, source.Model, declaredModelType)
    {
    }

    protected ViewDataDictionary(ViewDataDictionary source, object model, Type declaredModelType)
      : this(source._metadataProvider, source.ModelState, declaredModelType, (IDictionary<string, object>) new CopyOnWriteDictionary<string, object>((IDictionary<string, object>) source, (IEqualityComparer<string>) StringComparer.OrdinalIgnoreCase), new TemplateInfo(source.TemplateInfo))
    {
      if (source == null)
        throw new ArgumentNullException(nameof (source));
      Type type1 = model?.GetType();
      Type type2 = type1;
      if ((object) type2 == null)
        type2 = declaredModelType;
      Type modelType = type2;
      this.ModelExplorer = source.ModelMetadata.MetadataKind != ModelMetadataKind.Type || !(source.ModelMetadata.ModelType == typeof (object)) || !(modelType != typeof (object)) ? (declaredModelType.IsAssignableFrom(source.ModelMetadata.ModelType) ? (!(type1 != (Type) null) || source.ModelMetadata.ModelType.IsAssignableFrom(type1) ? (model != source.ModelExplorer.Model ? new ModelExplorer(this._metadataProvider, source.ModelExplorer.Container, source.ModelMetadata, model) : source.ModelExplorer) : this._metadataProvider.GetModelExplorerForType(type1, model)) : this._metadataProvider.GetModelExplorerForType(modelType, model)) : this._metadataProvider.GetModelExplorerForType(modelType, model);
      if (model == null)
        return;
      this.EnsureCompatible(model);
    }

    private ViewDataDictionary(
      IModelMetadataProvider metadataProvider,
      ModelStateDictionary modelState,
      Type declaredModelType,
      IDictionary<string, object> data,
      TemplateInfo templateInfo)
    {
      this._metadataProvider = metadataProvider;
      this.ModelState = modelState;
      this._declaredModelType = declaredModelType;
      this._data = data;
      this.TemplateInfo = templateInfo;
    }

    public object Model
    {
      get => this.ModelExplorer.Model;
      set => this.SetModel(value);
    }

    public ModelStateDictionary ModelState { get; }

    public ModelMetadata ModelMetadata => this.ModelExplorer.Metadata;

    public ModelExplorer ModelExplorer { get; set; }

    public TemplateInfo TemplateInfo { get; }

    public object this[string index]
    {
      get
      {
        object obj;
        this._data.TryGetValue(index, out obj);
        return obj;
      }
      set => this._data[index] = value;
    }

    public int Count => this._data.Count;

    public bool IsReadOnly => this._data.IsReadOnly;

    public ICollection<string> Keys => this._data.Keys;

    public ICollection<object> Values => this._data.Values;

    internal IDictionary<string, object> Data => this._data;

    public object Eval(string expression) => this.GetViewDataInfo(expression)?.Value;

    public string Eval(string expression, string format) => ViewDataDictionary.FormatValue(this.Eval(expression), format);

    public static string FormatValue(object value, string format)
    {
      if (value == null)
        return string.Empty;
      return string.IsNullOrEmpty(format) ? Convert.ToString(value, (IFormatProvider) CultureInfo.CurrentCulture) : string.Format((IFormatProvider) CultureInfo.CurrentCulture, format, value);
    }

    public ViewDataInfo GetViewDataInfo(string expression) => ViewDataEvaluator.Eval(this, expression);

    protected virtual void SetModel(object value)
    {
      Type type = value?.GetType();
      if (this.ModelMetadata.MetadataKind == ModelMetadataKind.Type && this.ModelMetadata.ModelType == typeof (object) && (type != (Type) null && type != typeof (object)))
        this.ModelExplorer = this._metadataProvider.GetModelExplorerForType(type, value);
      else if (type != (Type) null && !this.ModelMetadata.ModelType.IsAssignableFrom(type))
        this.ModelExplorer = this._metadataProvider.GetModelExplorerForType(type, value);
      else if (value == this.Model)
      {
        if (value == null && !this.ModelMetadata.IsReferenceOrNullableType && this._declaredModelType != this.ModelMetadata.ModelType)
          this.ModelExplorer = this._metadataProvider.GetModelExplorerForType(this._declaredModelType, value);
      }
      else
        this.ModelExplorer = new ModelExplorer(this._metadataProvider, this.ModelExplorer.Container, this.ModelMetadata, value);
      this.EnsureCompatible(value);
    }

    private void EnsureCompatible(object value)
    {
      if (!this.IsCompatibleWithDeclaredType(value))
        throw new InvalidOperationException(value != null ? Resources.FormatViewData_WrongTModelType((object) value.GetType(), (object) this._declaredModelType) : Resources.FormatViewData_ModelCannotBeNull((object) this._declaredModelType));
    }

    private bool IsCompatibleWithDeclaredType(object value) => value == null ? this.ModelMetadata.IsReferenceOrNullableType : this._declaredModelType.IsAssignableFrom(value.GetType());

    public void Add(string key, object value)
    {
      if (key == null)
        throw new ArgumentNullException(nameof (key));
      this._data.Add(key, value);
    }

    public bool ContainsKey(string key) => key != null ? this._data.ContainsKey(key) : throw new ArgumentNullException(nameof (key));

    public bool Remove(string key) => key != null ? this._data.Remove(key) : throw new ArgumentNullException(nameof (key));

    public bool TryGetValue(string key, out object value) => key != null ? this._data.TryGetValue(key, out value) : throw new ArgumentNullException(nameof (key));

    public void Add(KeyValuePair<string, object> item) => this._data.Add(item);

    public void Clear() => this._data.Clear();

    public bool Contains(KeyValuePair<string, object> item) => this._data.Contains(item);

    public void CopyTo(KeyValuePair<string, object>[] array, int arrayIndex)
    {
      if (array == null)
        throw new ArgumentNullException(nameof (array));
      this._data.CopyTo(array, arrayIndex);
    }

    public bool Remove(KeyValuePair<string, object> item) => ((ICollection<KeyValuePair<string, object>>) this._data).Remove(item);

    IEnumerator<KeyValuePair<string, object>> IEnumerable<KeyValuePair<string, object>>.GetEnumerator() => this._data.GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator() => (IEnumerator) this._data.GetEnumerator();
  }
}

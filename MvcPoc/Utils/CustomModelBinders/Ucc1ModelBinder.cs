using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web.Mvc;
using MvcPoc.Web.Models;

namespace MvcPoc.Web.Utils.CustomModelBinders
{
    public class Ucc1ModelBinder : IModelBinder
    {
        private string _stateCode;

        public string StateCode
        {
            get { return _stateCode; }
            set { _stateCode = value; }
        }

        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            try
            {
                StateCode = controllerContext.HttpContext.Request.Form["StateCode"];
                Dictionary<string, string> dicFormCollection = GetFormDictionay(controllerContext);
                return GetObjectFromDictionary(dicFormCollection, typeof(Ucc1Model));
            }
            catch (Exception exception)
            {
                return null;
            }

        }

        private Dictionary<string, string> GetFormDictionay(ControllerContext controllerContext)
        {
            Dictionary<string, string> dicFromCollection = new Dictionary<string, string>();
            foreach (string key in controllerContext.HttpContext.Request.Form.Keys)
            {
                dicFromCollection.Add(key, controllerContext.HttpContext.Request.Form[key]);
            }
            return dicFromCollection;
        }


        private dynamic GetObjectFromDictionary(Dictionary<string, string> data, Type type)
        {
            var instanceObject =(type.Name.Contains("Ucc1Model") || type.Name.Contains("Ucc1DebtorModel"))
                                ? Activator.CreateInstance(type, new object[] { StateCode }) 
                                : Activator.CreateInstance(type);
            var dictionaryKeys = data.Keys.ToList();

            foreach (var dictionaryKey in dictionaryKeys)
            {
                string dictionaryValue = null;

                if (!data.TryGetValue(dictionaryKey, out dictionaryValue)) continue;
                var matchPropertyKey = GetMatchofString(dictionaryKey, @"^[^.]*");
                var matchPropertyName = GetMatchofString(dictionaryKey, @"^[^[]*");

                var property = instanceObject.GetType().GetProperty(matchPropertyName);
                if (property == null) continue;

                var typeCode = Type.GetTypeCode(property.PropertyType);
                object value = null;

                if (property.PropertyType.IsEnum)
                    value = Enum.ToObject(property.PropertyType, Int32.Parse(dictionaryValue));
                else if (typeCode == TypeCode.Boolean || property.PropertyType == typeof (bool?))
                {
                    int numericValue;
                    if (Int32.TryParse(dictionaryValue, out numericValue))
                        value = Convert.ToBoolean(numericValue);
                    else
                        value = string.IsNullOrWhiteSpace(dictionaryValue)
                                    ? (object) null
                                    : Convert.ToBoolean(dictionaryValue);

                }
                else if (typeCode == TypeCode.String)
                    value = dictionaryValue;
                else if (property.PropertyType.IsArray)
                {
                    //get all the entries that have the same property type
                    var dictionaryOfAllObjects =
                        new SortedDictionary<string, string>(data.Where(dv => dv.Key.StartsWith(matchPropertyName))
                                                                 .ToDictionary(dv => dv.Key, dv => dv.Value),
                                                             new NaturalComparer());

                    var arrayList = new List<dynamic>();
                    foreach (var arrayDictionaryKeys in dictionaryOfAllObjects.Keys.ToList())
                    {
                        string arraydictionaryValue = null;
                        if (!dictionaryOfAllObjects.TryGetValue(arrayDictionaryKeys, out arraydictionaryValue))
                            continue;
                        var matchPropertyArrayKey = String.Format("{0}.",
                                                                  GetMatchofString(arrayDictionaryKeys, @"^[^.]*"));
                        arrayList.Add(GetObjectFromDictionary(
                            dictionaryOfAllObjects.Where(dv => dv.Key.StartsWith(matchPropertyArrayKey))
                                                  .ToDictionary(dv => dv.Key.Split('.')[1], dv => dv.Value),
                            property.PropertyType.GetElementType()));
                        foreach (
                            var itemsToRemove in
                                data.Where(dv => dv.Key.StartsWith(matchPropertyArrayKey))
                                    .ToDictionary(dv => dv.Key, dv => dv.Value))
                        {
                            data.Remove(itemsToRemove.Key);
                            dictionaryOfAllObjects.Remove(itemsToRemove.Key);
                        }
                    }
                    var returnArray = Array.CreateInstance(property.PropertyType.GetElementType(), arrayList.Count());
                    var i = 0;
                    foreach (var item in arrayList)
                    {
                        returnArray.SetValue(item, i);
                        i++;
                    }
                    value = returnArray;
                }
                else if (typeCode == TypeCode.Object)
                {
                    var dictionaryOfObject =
                        data.Where(dv => dv.Key.StartsWith(matchPropertyKey))
                            .ToDictionary(dv => dv.Key.Split('_')[1], dv => dv.Value);
                    value = GetObjectFromDictionary(dictionaryOfObject, property.PropertyType);
                    foreach (
                        var itemsToRemove in
                            data.Where(dv => dv.Key.StartsWith(matchPropertyKey))
                                .ToDictionary(dv => dv.Key, dv => dv.Value))
                    {
                        data.Remove(itemsToRemove.Key);
                    }
                }
                if (property.GetSetMethod() != null)
                    property.SetValue(instanceObject, value, null);
            }
            return instanceObject;
        }

        private string GetMatchofString(string baseString, string regularExpression)
        {
            return Regex.Match(baseString, regularExpression).ToString();
        }

        public object Dictionary { get; set; }
    }

    public class NaturalComparer : IComparer<string>
    {
        public int Compare(string x, string y)
        {
            if (x == null && y == null) return 0;
            if (x == null) return -1;
            if (y == null) return 1;

            int lx = x.Length, ly = y.Length;

            for (int mx = 0, my = 0; mx < lx && my < ly; mx++, my++)
            {
                if (char.IsDigit(x[mx]) && char.IsDigit(y[my]))
                {
                    long vx = 0, vy = 0;
                    for (; mx < lx && char.IsDigit(x[mx]); mx++)
                        vx = vx*10 + x[mx] - '0';
                    for (; my < ly && char.IsDigit(y[my]); my++)
                        vy = vy*10 + y[my] - '0';
                    if (vx != vy)
                        return vx > vy ? 1 : -1;
                }
                if (mx < lx && my < ly && x[mx] != y[my])
                    return x[mx] > y[my] ? 1 : -1;
            }

            return lx - ly;
        }
    }
}
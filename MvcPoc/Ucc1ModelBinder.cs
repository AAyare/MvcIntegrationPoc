using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcPoc.Web.Models;
using MvcPoc.Web.Models.Debtor;


namespace MvcPoc.Web
{
    public class Ucc1ModelBinder : IModelBinder
    {
        public Ucc1ModelBinder()
        {
           
        }
     
        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            try
            {
               Ucc1Model ucc1Model = new Ucc1Model(controllerContext.HttpContext.Request.Form["StateCode"]);
               foreach (string key in controllerContext.HttpContext.Request.Form.Keys)
               {
                  System.Reflection.PropertyInfo propertyInfo = ucc1Model.GetType().GetProperty(key);
                   if (propertyInfo != null)
                   {
                       propertyInfo.SetValue(ucc1Model, Convert.ChangeType(controllerContext.HttpContext.Request.Form[key], propertyInfo.PropertyType), null);
                   }
               }

               int i = 0;
               while (true)
               {
                   if (controllerContext.HttpContext.Request.Form["Ucc1Debtors[" + i + "].StateCode"] != null)
                       i = i + 1;
                   else
                       break;
               }

               List<Ucc1DebtorModel> lstDebtors = new List<Ucc1DebtorModel>();
               Ucc1DebtorModel ucc1DebtorModel;

               for (int j = 0; j < i; j = j + 1)
               {
                   ucc1DebtorModel = new Ucc1DebtorModel(ucc1Model.StateCode);

                   lstDebtors.Add(ucc1DebtorModel);
               }
               if (lstDebtors.Count > 0)
                   ucc1Model.Ucc1Debtors = lstDebtors;
                return ucc1Model;
            }
            catch (Exception exception)
            {
                return null;
            }

        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ClotherApp.Models
{
    public static class SelectListExtension
    {
        public static SelectList ToSelectList<T>(this IEnumerable<T> items, string dataValueField, string dataTextField)
        {
            return ToSelectList(items, dataValueField, dataTextField, null);
        }

        public static SelectList ToSelectList<T>(this IEnumerable<T> items, string dataValueField, string dataTextField, object selectedValue)
        {
            return new SelectList(items, dataValueField, dataTextField, selectedValue);
        }
    }
}
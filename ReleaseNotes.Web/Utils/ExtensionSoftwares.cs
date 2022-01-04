using Microsoft.AspNetCore.Mvc.Rendering;
using System.Linq;

namespace ReleaseNotes.Web.Utils
{
    public static class ExtensionSoftwares
    {
        public static IEnumerable<SelectListItem> GetEnumValueSelectList<TEnum>(this IHtmlHelper htmlHelper) where TEnum : struct
        {
            return new SelectList(Enum.GetNames(typeof(TEnum)).OfType<Enum>()
                .Select(x =>
                new SelectListItem
                {
                    Text = x.ToString(),
                    Value = x.ToString()
                }), "Value", "text");
        }
    }
}

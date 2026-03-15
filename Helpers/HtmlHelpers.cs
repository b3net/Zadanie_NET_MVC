using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;

namespace Project.Helpers
{
    public static class HtmlHelpers
    {
        public static IHtmlString TruncateHtml(this HtmlHelper html, string input, int length = 100)
        {
            if (string.IsNullOrEmpty(input))
                return MvcHtmlString.Empty;

            string plainText = Regex.Replace(input, "<.*?>", string.Empty);
            
            plainText = HttpUtility.HtmlDecode(plainText);

            if (plainText.Length <= length)
            {
                return new MvcHtmlString(HttpUtility.HtmlEncode(plainText));
            }

            string truncated = plainText.Substring(0, length).TrimEnd() + "...";
            return new MvcHtmlString(HttpUtility.HtmlEncode(truncated));
        }
        
        public static IHtmlString SortIcon(this HtmlHelper html, string column, string currentSort)
        {
            if (string.IsNullOrEmpty(currentSort) && column == "date")
            {
                return new MvcHtmlString("<i class=\"bi bi-sort-down sort-indicator\"></i>");
            }

            if (currentSort == column)
            {
                return new MvcHtmlString("<i class=\"bi bi-sort-up sort-indicator\"></i>");
            }

            if (currentSort == column + "_desc")
            {
                return new MvcHtmlString("<i class=\"bi bi-sort-down sort-indicator\"></i>");
            }

            return new MvcHtmlString("<i class=\"bi bi-hash sort-indicator\" style=\"opacity: 0.2\"></i>");
        }
    }
}

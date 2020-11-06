using Microsoft.AspNetCore.Html;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace ICanHazDadJokeMVC.Helpers
{
    public static class HtmlHelpers
    {
        public static HtmlString DisplayFormattedData(string sentence, string word)
        {
            HtmlString result = new HtmlString(sentence);
            if (!string.IsNullOrEmpty(sentence))
            {
                if (sentence.Contains(word))
                {
                    string replaced = sentence.Replace(word, string.Format("<strong>{0}</strong>", word));
                    result = new HtmlString(replaced);
                }
            }
            return result;
        }
    }
}

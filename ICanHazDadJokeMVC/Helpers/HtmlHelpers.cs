using Microsoft.AspNetCore.Html;

namespace ICanHazDadJokeMVC.Helpers
{
    public static class HtmlHelpers
    {
        public static HtmlString DisplayFormattedData(string sentence, string word)
        {
            HtmlString result = new HtmlString(sentence);
            if (!string.IsNullOrEmpty(sentence))
            {
                if (!string.IsNullOrEmpty(word) && sentence.ToLower().Contains(word.ToLower()))
                {
                    int beginPos = sentence.ToLower().IndexOf(word.ToLower());
                    int endPos = beginPos + word.Length;
                    string formatted = sentence.Insert(endPos, "</strong>").Insert(beginPos, "<strong>");
                    result = new HtmlString(formatted);
                }
            }
            return result;
        }
    }
}

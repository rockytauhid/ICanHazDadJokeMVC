using System.Collections.Generic;

namespace ICanHazDadJokeMVC.Models
{
    public class ICanHazDadJokeModel
    {
        /// <summary>
        /// ICanHazDadJoke specific Id
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Joke content
        /// </summary>
        public string Joke { get; set; }

        /// <summary>
        /// Http Status Code
        /// </summary>
        public int Status { get; set; }
    }

    public class ICanHazDadJokeListModel
    {
        public ICanHazDadJokeListModel()
        {
            Results = new List<ICanHazDadJokeModel>();
            ShortJokes = new List<ICanHazDadJokeModel>();
            MediumJokes = new List<ICanHazDadJokeModel>();
            LongJokes = new List<ICanHazDadJokeModel>();
            if (Results.Count > 1)
                GroupByLength(Results);
        }

        /// <summary>
        /// Http Status Code
        /// </summary>
        public string Status { get; set; }

        /// <summary>
        /// Short joke which is less 10 words (requirement)
        /// </summary>
        public int ShortJokeLimit { get; } = 10;

        /// <summary>
        /// Medium joke which is less 20 words (requirement)
        /// </summary>
        public int MediumJokeLimit { get; } = 20;

        /// <summary>
        /// Search term
        /// </summary>
        public string SearchTerm { get; set; }

        /// <summary>
        /// List of Jokes
        /// </summary>
        public IList<ICanHazDadJokeModel> Results { get; set; }

        /// <summary>
        /// List of short length jokes
        /// </summary>
        public IList<ICanHazDadJokeModel> ShortJokes { get; set; }

        /// <summary>
        /// List of medium length jokes
        /// </summary>
        public IList<ICanHazDadJokeModel> MediumJokes { get; set; }

        /// <summary>
        /// List of long length jokes
        /// </summary>
        public IList<ICanHazDadJokeModel> LongJokes { get; set; }

        private void GroupByLength(IList<ICanHazDadJokeModel> vModelList)
        {
            foreach (ICanHazDadJokeModel model in vModelList)
            {
                int wordCount = WordCount(model.Joke);

                if (wordCount < ShortJokeLimit)
                {
                    ShortJokes.Add(model);
                }
                else if (wordCount > ShortJokeLimit && wordCount < MediumJokeLimit)
                {
                    MediumJokes.Add(model);
                }
                else
                {
                    LongJokes.Add(model);
                }
            }
        }

        private int WordCount(string vJokes)
        {
            int result = 1;
            foreach (char i in vJokes)
            {
                foreach (char j in vJokes)
                {
                    if (char.IsWhiteSpace(i))
                        result++;
                }
            }
            return result;
        }
    }
}

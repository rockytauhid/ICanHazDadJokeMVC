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
            ShortJokes = new List<ICanHazDadJokeModel>();
            MediumJokes = new List<ICanHazDadJokeModel>();
            LongJokes = new List<ICanHazDadJokeModel>();
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

        private IList<ICanHazDadJokeModel> _Results;
        /// <summary>
        /// List of Jokes
        /// </summary>
        public IList<ICanHazDadJokeModel> Results 
        {
            get { return _Results; }
            set
            {
                _Results = value;
                if (_Results.Count > 1)
                    GroupByLength(_Results);
            } 
        }

        /// <summary>
        /// List of short length jokes
        /// </summary>
        public IList<ICanHazDadJokeModel> ShortJokes { get; }

        /// <summary>
        /// List of medium length jokes
        /// </summary>
        public IList<ICanHazDadJokeModel> MediumJokes { get; }

        /// <summary>
        /// List of long length jokes
        /// </summary>
        public IList<ICanHazDadJokeModel> LongJokes { get; }

        private void GroupByLength(IList<ICanHazDadJokeModel> vModelList)
        {
            foreach (ICanHazDadJokeModel model in vModelList)
            {
                int count = model.Joke.Split(' ').Length;

                if (count < ShortJokeLimit)
                    ShortJokes.Add(model);
                else if (count > ShortJokeLimit && count < MediumJokeLimit)
                    MediumJokes.Add(model);
                else
                    LongJokes.Add(model);
            }
        }
    }
}

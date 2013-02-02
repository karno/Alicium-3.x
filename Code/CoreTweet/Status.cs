using System;

namespace CoreTweet
{
    public class Status : CoreBase
    {
        /// <summary>
        /// Identification code of this status.
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// Nullable. An collection of brief user objects (usually only one) indicating users who contributed to the authorship of the tweet, on behalf of the official tweet author.
        /// </summary>
        public Contributors[] Contributors { get; set; }

        /// <summary>
        /// Nullable. Represents the geographic location of this Tweet as reported by the user or client application.
        /// </summary>
        public Coordinates Coordinates { get; set; }

        /// <summary>
        /// Time when this Tweet was created.
        /// </summary>
        public DateTime CreatedAt { get; set; }

        /// <summary>
        /// Details the Tweet ID of the user's own retweet (if existent) of this Tweet.
        /// </summary>
        /// <remarks>
        /// Only surfaces on methods supporting the include_my_retweet parameter, when set to true. 
        /// </remarks>
        public long[] CurrentUserRetweet { get; set; }

        /// <summary>
        /// Entities which have been parsed out of the text of the Tweet. 
        /// </summary>
        public Entity[] Entities { get; set; }

        /// <summary>
        /// Nullable. Perspectival. Indicates whether this Tweet has been favorited by the authenticating user.
        /// </summary>
        public bool IsFavorited { get; set; }

        /// <summary>
        /// Whether direct message or not
        /// </summary>
        public bool IsDirectMessage { get; set; }

        /// <summary>
        /// User
        /// </summary>
        public User User { get; set; }

        /// <summary>
        /// Undecoded text
        /// </summary>
        public string Text { get; set; }

        /// <summary>
        /// Status is favorited
        /// </summary>
        public bool IsFavored { get; set; }


        internal override void ConvertBase(dynamic e)
        {

        }
    }
    public class Contributors : CoreBase
    {
        public long Id { get; set; }
        public string ScreenName { get; set; }

        internal override void ConvertBase(dynamic e)
        {
            this.Id = e.id;
            this.ScreenName = e.screen_name;
        }
    }

    public class Coordinates : CoreBase
    {
        public double Longtitude { get; set; }

        public double Latitude { get; set; }

        public string Type { get; set; }

        internal override void ConvertBase(dynamic e)
        {
            Longtitude = e.coordinates[0];
            Latitude = e.coordinates[1];
            Type = e.type;
        }
    }
}


using System;

namespace CoreTweet
{
    public class User : CoreBase
    {
        public bool ContributorsEnabled;
        public DateTime CreatedAt;
        public bool DefaultProfile;
        public bool DefaultProfileImage;
        public string Description;
        internal override void ConvertBase(dynamic e)
        {

        }
    }
}


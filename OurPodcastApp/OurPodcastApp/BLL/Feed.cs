using System;
using System.Collections.Generic;

namespace OurPodcastApp {
    public class Feed : Entity, ITitleable {
        public int EpisodeCount { get; set; }
        public string Title { get; set; }
        public string UpdateFrequency { get; set; }
        public string Genre { get; set; }
        public string FeedURL { get; set; }
        public DateTime LastCheckForUpdates { get; set; }
        public EpisodeList Episodes { get; set; }

        public override string EntityType() {
            return "A feed.\n";
        }
    }

    public class FeedList : List<Feed> {
        public FeedList() {
            // Constructors'R'Us
        }
    }
}
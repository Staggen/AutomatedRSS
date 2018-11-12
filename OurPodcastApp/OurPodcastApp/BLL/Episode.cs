using System.Collections.Generic;

namespace OurPodcastApp {
    public class Episode : Entity, ITitleable {
        public string Title { get; set; }
        public string Description { get; set; }

        public override string EntityType() {
            return "An episode.\n";
        }
    }

    public class EpisodeList : List<Episode> {
        public EpisodeList() {
            // Constructors'R'Us
        }
    }
}
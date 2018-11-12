using System;

namespace OurPodcastApp {
    class GenreException : Exception {
        public GenreException() : base("Serialization failed!") {

        }

        public GenreException(string message) : base(message) {

        }
    }
}
namespace OurPodcastApp {
    public class Frequencies {
        public static string[] frequencyList = {
            "Ten minutes",
            "One hour",
            "One day",
            "One week",
            "One month"
        };

        public enum Frequency {
            min,
            hr,
            day,
            week,
            month,
        }

        public static string GetFrequency(Frequency name) {
            return frequencyList[(int)name];
        }

        public static string[] ReadFrequencies() {
            return frequencyList;
        }
    }
}
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;

namespace Domain {
    public class Page {
        static Regex _redirectRegex = new Regex(@"^#REDIRECT \[\[(.*?)]]", RegexOptions.Compiled);
        public string _id { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }

        public string Redirect {
            get {
                var match = _redirectRegex.Match(Text);
                if (match.Success)
                    return match.Groups[1].Value;
                return null;
            }
        }

        public static string GenerateIdHash(string input) {
            var bytes = Encoding.UTF8.GetBytes(input.ToLowerInvariant());
            using (var provider = new SHA1CryptoServiceProvider()) {
                var hash = provider.ComputeHash(bytes);

                return hash.Aggregate(
                    new StringBuilder(),
                    (s, b) => {
                        s.Append(b.ToString("x2"));
                        return s;
                    }).ToString();
            }
        }
    }


}
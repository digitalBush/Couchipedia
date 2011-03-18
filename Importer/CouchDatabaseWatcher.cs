using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Timers;
using System.Net;

namespace Importer {
    public class CouchDatabaseWatcher {

        public Uri Uri  { get; set; }
        public CouchDatabaseWatcher(string database) {
            Uri = new Uri("http://" + database );
        }

        public Action<DatabaseStats> OnUpdate { get; set; }

        Timer timer;
        public void Start(int interval) {
            timer = new Timer(interval);
            timer.Elapsed += new ElapsedEventHandler(timer_Elapsed);
            timer.Start();

        }

        void timer_Elapsed(object sender, ElapsedEventArgs e) {
            WebClient c=new WebClient();
            OnUpdate(c.DownloadString(Uri).FromJson<DatabaseStats>());
        }
    }
}

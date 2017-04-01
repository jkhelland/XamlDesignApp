using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XamlDesignApp
{
    public class MessageData
    {
        public string id { get; set; }

        public DateTime createdAt { get; set; }

        public DateTime updatedAt { get; set; }

        public bool deleted { get; set; }

        public string userid { get; set; }

        public string eventid { get; set; }

        public string comment { get; set; }

        public string userName { get; set; }
    }
}

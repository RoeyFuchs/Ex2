using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex2.Models {
    class AutoPilotModel {

        public AutoPilotModel() {
            Sent = true;
            Text = String.Empty;
        }


        public string Text { get; set; }
        public string[] GetCommands() {
           return Text.Split(new[] { Environment.NewLine},
                                StringSplitOptions.None
                                );
        }
        public bool Sent { get; set; }
    }

    
}

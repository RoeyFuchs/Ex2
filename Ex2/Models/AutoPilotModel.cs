using System;

namespace Ex2.Models {
    class AutoPilotModel {

        public AutoPilotModel() {
            Sent = true;
            Text = String.Empty;
        }

        public string Text { get; set; }
        //split by new line char
        public string[] GetCommands() {
            return Text.Split(new[] { Environment.NewLine },
                                 StringSplitOptions.None
                                 );
        }
        public bool Sent { get; set; }
    }

}

namespace StageGeyser.SectionTemplates;
using System.Collections.Generic;
using StageGeyser.Geyser;

public partial class TitlePage : Section {
    Dictionary<string,string> elementDic = new Dictionary<string,string>(){
        {@"^\..*","Title"},
        {@"^!.*","Subtitle"},
        {@"^@.*","Credit"},
        {@"===","PageBreak"},
        {@"^/.*","Note"},
    };
    public TitlePage() {
    }
}

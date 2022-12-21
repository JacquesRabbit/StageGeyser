using Avalonia.Controls;
using Avalonia;
using Avalonia.Media;
using ReactiveUI;
using System.Xml;
using System.Collections.Generic;
using System;
namespace StageGeyser.Geyser;
public enum ScriptFont {
    StageClassic,
    ScreenClassic,
}

public class GeyserElement {
    public ScriptFont style;
    List<GeyserElement> children = new List<GeyserElement>();
    public XmlNode xmlNode;
    public GeyserElement(XmlNode xmlNode) {
        this.xmlNode = xmlNode;
        style = ScriptFont.StageClassic;
    }
    protected XmlAttribute? FindAttribute(string attributeName) {
        if (xmlNode.Attributes == null) {return null;} 
        else if (xmlNode.Attributes.GetNamedItem(attributeName) is XmlAttribute attr) {
            return attr;
        }
        return null;
    }
}
public class GeyserSection : GeyserElement {
    List<GeyserElement> contents = new List<GeyserElement>();

    protected GeyserSection(XmlNode xmlNode) : base(xmlNode) {}
    protected void Initialise() {

    }
    protected XmlNode? FindChild(string nodeName){
        XmlNode? newNode = xmlNode.SelectSingleNode(nodeName);
        return newNode;
    }
    protected XmlNodeList? FindChildren(string nodeName){
        XmlNodeList? newNode = xmlNode.SelectNodes(nodeName);
        return newNode;
    }
    public Control GenerateControl() => new Control();
}

public class DisplayElement : GeyserElement {
    protected DisplayElement(XmlNode xmlNode) : base(xmlNode) {}
}
public class Script : GeyserSection {
    
    List<GeyserSection> sections = new List<GeyserSection>();
    StackPanel visibleElements = new StackPanel();
    
    private TitlePage? titlePage;
    private CharacterList? characterList;
    private SongList? songList;
    private Preface? preface;
    public string? name;
    public string? author;
    
    public Script(XmlNode xmlNode) : base(xmlNode){
        this.xmlNode = xmlNode;
        XmlAttributeCollection? scriptAttributes = this.xmlNode.Attributes;
        if (FindAttribute("name") is XmlAttribute nameAttribute) {
            name = nameAttribute.Value;
        }
        if (FindAttribute("author") is XmlAttribute authorAttribute) {
            author = authorAttribute.Value;
        }
        Initialise();
    }

    new private void Initialise()
    {
        if (FindChild("TitlePage") is XmlNode titlePageNode) {
            titlePage = new TitlePage(titlePageNode);
            sections.Add(titlePage);
        }
        if (FindChild("CharacterList") is XmlNode characterListNode) {
            characterList = new CharacterList(characterListNode);
            sections.Add(characterList);
        }
        if (FindChild("SongList") is XmlNode songListNode) {
            songList = new SongList(songListNode);
            sections.Add(songList);
        }
        if (FindChild("Preface") is XmlNode prefaceNode) {
            preface = new Preface(prefaceNode);
            sections.Add(preface);
        }
        if(FindChildren("Act") is XmlNodeList sceneNodeList) {
            foreach (XmlNode node in sceneNodeList) {
                sections.Add(new Act(node));
            }
        }
    }
    new Control GenerateControl() {
        StackPanel docControl = new StackPanel();
        foreach (GeyserSection sec in sections) {
            sec.GenerateControl();
        }
        return docControl;
    }
}

public class TitlePage : GeyserSection {
    public string? title;
    public string? subtitle;
    public List<Credit>? credits;
    public TitlePage(XmlNode xmlNode) : base(xmlNode){
        Initialise();
    }
    new private void Initialise() {
        if(FindChild("Title") is XmlNode titleNode) {
            title = titleNode.InnerText;
        }
        if(FindChild("Subtitle") is XmlNode subtitleNode) {
            subtitle = subtitleNode.InnerText;
        }
    }
    new public Control GenerateControl() {
        DockPanel page = new DockPanel();
        page.Height = 1123.2; // 11.7 in
        page.Width = 796.8; // 8.3 in
        Thickness pageMargin = new Thickness(384, 336, 96, 96); // 4 in (left), 3.5 in (top), 1 in, 1 in (right, bottom)
        page.Margin = pageMargin;
        if(!String.IsNullOrWhiteSpace(title)) {
            Label titleControl = new Label();
            titleControl.FontFamily = FontFamily.Parse("Courier");
            titleControl.Content = title;
            page.Children.Add(titleControl);
        }
        return page;
    }
}
public class CharacterList : GeyserSection {
    public CharacterList(XmlNode xmlNode) : base(xmlNode){}
}
public class SceneList : GeyserSection {
    SceneList(XmlNode xmlNode) : base(xmlNode) {}
}
public class SongList : GeyserSection {
    public SongList(XmlNode xmlNode) : base(xmlNode){}
}
public class Preface : GeyserSection {
    public Preface(XmlNode xmlNode) : base(xmlNode){}
}
public class Act : GeyserSection {
    public Act(XmlNode xmlNode) : base(xmlNode){}
}
public class Scene : GeyserSection {
    public Scene(XmlNode xmlNode) : base(xmlNode){}
}
public class Character : GeyserElement {
    Character(XmlNode xmlNode) : base(xmlNode){}
}
public class Name : GeyserElement {
    Name(XmlNode xmlNode) : base(xmlNode){}
}
public class Credit : GeyserElement {
    public string subject;
    public string? prefix;
    public string? postfix;

    public Credit(XmlNode xmlNode, string subject, string? prefix, string? postfix) : base(xmlNode) {
        this.subject = subject;
        this.prefix = prefix;
        this.postfix = postfix;
    }
}

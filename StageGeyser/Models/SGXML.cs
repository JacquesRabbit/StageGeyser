using Avalonia.Controls;
using System.Xml;
using StageGeyser.Geyser;
namespace StageGeyser.SGXML;

static class SGXMLParser {
    public static XmlNode ReadFile(string filePath) {
        XmlDocument document = new XmlDocument();
        document.Load(filePath);
        if(document.FirstChild != null) {
            XmlNode script = document.FirstChild;
            return script;
        }
        return document;
    }
}

using System.Text.RegularExpressions;
using ReactiveUI;
using System;
using System.Collections.Generic;
using Avalonia.Controls;
using StageGeyser.Models;
namespace StageGeyser.Geyser;

public class GeyserDocument : ReactiveObject {
    static string[] newlines = new string[] { "\r\n", "\r", "\n" };
    public List<Section> sections;
    /* Pages are defined as StackPanel controls with dimensions 796.8 x 1123.2, which are the dimensions of an A4 piece of paper
    in RIP. They are stored in a single StackPanel, so that the ViewModel can bind to them directly. */
    public StackPanel pages;
    public GeyserDocument() {
        sections = new List<Section>();
        pages = new StackPanel();
    }
    
        
    public async void LoadFromFile() {
        string fileContent = await FileManager.Open();
            //Create an array of sections to add to
            List<Section> newSections = new List<Section>();
            //Split the string file into an array
            string[] lines = fileContent.Split(newlines, System.StringSplitOptions.None);
            //Record the index of the start and end of the current Section
            int sectionStart = 0;
            int sectionEnd;
            bool startAssigned = false;
            for (int i = 0; i < lines.Length; i++)
            {
                //The line being operated on.
                string line = lines[i];
                //The same line without any whitespace characters, given a value when needed.
                string lineNWS;
                switch (line) 
                {
                    case "{":
                        sectionStart = i + 1;
                        startAssigned = true;
                        break;
                    case "}":
                        Section newSec = new Section();
                        if(startAssigned) {
                            sectionEnd = i;
                            for (int j = sectionStart; j < sectionEnd; j++) {
                                line = lines[j];
                                if(line.Contains(":") &&!line.Contains(@"\:")) {
                                    lineNWS = Regex.Replace(line, @"\s+" ,"");
                                    string propKey = lineNWS.Split(':', 2, System.StringSplitOptions.RemoveEmptyEntries)[0];
                                    string propVal = lineNWS.Split(':', 2, System.StringSplitOptions.RemoveEmptyEntries)[1];
                                    newSec.properties.Add(propKey.Trim(),propVal.Trim());
                                } else {
                                    newSec.lines.Add(line);
                                }
                            }
                        }
                        newSections.Add(newSec);
                        break;
                }
            }
            this.sections = newSections;
        
    }
    public void RenderSections() {
        
    }
}

public class Section : ContentControl {
    public List<String> lines;
    public Dictionary<string,string> properties;
    
    public Section() {
        lines = new List<String>();
        properties = new Dictionary<string, string>();
    }
}
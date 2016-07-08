using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Xml.Linq;

namespace TreeViewDemo
{
    class DemoModel : INotifyPropertyChanged
    {
        public DemoModel()
        {
            Load();
        }

        private void Load()
        {
            System.Xml.Linq.XDocument xdoc = System.Xml.Linq.XDocument.Load("Gesture.xml");
            System.Xml.Linq.XElement xeRoot = xdoc.Root;

            foreach (var e in xeRoot.Elements())
            {
                
                string name = e.Attribute("Name").Value;
                int ID = Convert.ToInt32(e.Attribute("ID").Value);
                Gesture aGesture = new Gesture(name, ID);

                foreach (var t in e.Elements())
                {
                    int num = Convert.ToInt32(t.Attribute("Number").Value);
                    Segment aSegment = new Segment(num);
                    foreach (var x in t.Elements())
                    {
                        int Type = Convert.ToInt32(x.Attribute("Type").Value);
                        int Joint0 = Convert.ToInt32(x.Attribute("Joint0").Value);
                        int Joint1 = Convert.ToInt32(x.Attribute("Joint1").Value);
                        float Number = (float)Convert.ToDouble(x.Attribute("Number").Value);
                        Condition aCondition = new Condition(Type, Joint0, Joint1, Number);
                        aSegment.Conditions.Add(aCondition);
                    }
                    aGesture.Segments.Add(aSegment);
                }
                Gestures.Add(aGesture);
            }
        }

        public void save()
        {
            XDocument xdocument = new XDocument();
            XElement eRoot = new XElement("Set");
            xdocument.Add(eRoot);

            foreach( var e in Gestures )
            {
                XElement ele1 = new XElement("Gesture");
                ele1.SetAttributeValue("Name", e.Name);
                ele1.SetAttributeValue("ID", e.ID);
                ele1.SetAttributeValue("NumberOfSegments", e.NumberOfSegments());
                foreach( var t in e.Segments )
                {
                    XElement ele2 = new XElement("Segment");
                    ele2.SetAttributeValue("Number", t.Number);
                    ele2.SetAttributeValue("NumberOfConditions", t.Conditions.Count);
                    ele1.Add(ele2);
                    foreach( var s in t.Conditions )
                    {
                        XElement ele3 = new XElement("Condition");
                        ele3.SetAttributeValue("Type",s.Type);
                        ele3.SetAttributeValue("Joint0",s.Joint0);
                        ele3.SetAttributeValue("Joint1",s.Joint1);
                        ele3.SetAttributeValue("Number",s.Number);
                        ele2.Add(ele3);
                    }
                }
                eRoot.Add(ele1);
            }
            xdocument.Save("Gesture.xml");
        }

        public ObservableCollection<Gesture> Gestures { get; } = new ObservableCollection<Gesture>();

        private void OnPropertyChanged(string aPropertyName) { PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(aPropertyName)); }
        public event PropertyChangedEventHandler PropertyChanged;
    }
}

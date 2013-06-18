using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows;
using System.Reflection;
using System.ComponentModel;

namespace WPFXilix
{
    public class Language: INotifyPropertyChanged
    {
        private FileSystemWatcher watcher = new FileSystemWatcher();
        private Dictionary<string, string> labels = new Dictionary<string, string>();
        private int langIndex = 1; //English

        public Language()
        {
            try
            {
                if (File.Exists("xilix.csv"))
                {
                    watcher.Path = ".";
                    watcher.Filter = Path.GetFileName("xilix.csv");
                    watcher.NotifyFilter = NotifyFilters.LastWrite;
                    watcher.Changed += new FileSystemEventHandler(watcher_Changed);
                    watcher.EnableRaisingEvents = true;
                    LoadLanguage();
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex);
                MessageBox.Show(ex.ToString());
            }
        }

        private bool showRawCodes = false;
        public bool ShowRawCodes
        {
            get { return showRawCodes; }
            set 
            { 
                showRawCodes = value;
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs("Item[]"));
            }
        }

        public int LanguageIndex
        {
            get { return langIndex; }
            set
            {
                langIndex = value;
                LoadLanguage();
            }
        }

        void watcher_Changed(object sender, FileSystemEventArgs e)
        {
            LoadLanguage();
        }

        private void LoadLanguage()
        {
            Dictionary<string, string> tmpLoad = new Dictionary<string, string>();
            if (!File.Exists("xilix.csv")) return;
            using (StreamReader reader = File.OpenText("xilix.csv"))
            {
                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();
                    if (!string.IsNullOrWhiteSpace(line))
                    {
                        string[] parts = line.Split('\t');
                        if (parts.Length > 1 && langIndex > 0)
                        {
                            string key = parts[0];
                            
                            string text = parts[1];//English default


                            if (langIndex > 0 && langIndex < parts.Length)
                                text = parts[langIndex];

                            tmpLoad.Add(key, text);
                        }
                    }
                }
            }
            labels = tmpLoad;

            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs("Item[]"));

        }

        public string this[string key]
        {
            get
            {
                if (showRawCodes) return string.Format("{{{0}}}", key);
                string text;
                if (labels != null && labels.TryGetValue(key, out text))
                    return text;

                //Return the bit after
                string[] parts = key.Split('.');

                return parts[parts.Length - 1];
            }
            set
            {
                
                if (labels != null)
                {
                    {
                        labels[key] = value;
                    }
                    if (PropertyChanged != null)
                        PropertyChanged(this, new PropertyChangedEventArgs("Item[]"));
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}

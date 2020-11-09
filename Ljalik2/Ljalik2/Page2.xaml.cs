using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Ljalik2
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Page2 : ContentPage
    {
        TimePicker tpicker;
        Entry entry;
        DatePicker dpicker;
        Editor editor;
        Picker Picker;
        public Page2()
        {
            Grid gr = new Grid
            {
                RowDefinitions =
                {
                    new RowDefinition { Height = new GridLength(1, GridUnitType.Star) },
                    new RowDefinition { Height = new GridLength(1, GridUnitType.Star) },
                    new RowDefinition { Height = new GridLength(1, GridUnitType.Star) },
                },
                    ColumnDefinitions =
                {
                    new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star)},
                    new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star)},
                }
            };

            Picker = new Picker
            {
                Title = "Keeled"
            };
            Picker.Items.Add("C#");
            Picker.Items.Add("Python");
            Picker.Items.Add("C++");
            Picker.Items.Add("VisualBasic");
            Picker.Items.Add("Java");

            gr.Children.Add(Picker, 0, 0);
            Picker.SelectedIndexChanged += Picker_SelectedIndexChanged;
            editor = new Editor { Placeholder = "Vali keel \nimikirjast" };
            gr.Children.Add(editor, 1, 0);

            dpicker = new DatePicker
            {
                Format = "0",
                MinimumDate = DateTime.Now.AddDays(-10),    
                MaximumDate = DateTime.Now.AddDays(10)      
            };
            dpicker.DateSelected += dpicker_dateselected;
            gr.Children.Add(dpicker, 1, 1);

            tpicker = new TimePicker()
            {
                //Time = new TimeSpan(18,0,0)
                Time = new TimeSpan(DateTime.Now.Hour,DateTime.Now.Minute,DateTime.Now.Second)
            };
            gr.Children.Add(tpicker, 1, 1);

            entry = new Entry { Text = "Vali kuupäev või kellaaeg" };    
            gr.Children.Add(entry, 0, 1);   
            Content = gr;
        }

        private void dpicker_dateselected(object sender, DateChangedEventArgs e)
        {
            entry.Text = "Sinu kuupäev:\n" + e.NewDate.ToString();
        }

        private void Picker_SelectedIndexChanged(object sender, EventArgs e)
        {
            editor.Text = "Oli valitud" + Picker.Items[Picker.SelectedIndex];
        }
    }
}
           
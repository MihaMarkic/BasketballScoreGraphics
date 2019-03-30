using Avalonia.Controls;
using Avalonia.Data;
using Avalonia.Markup.Xaml;
using Avalonia.Media;
using System;
using System.Linq;
using System.Reflection;

namespace BasketballScoreGraphics.Avalonia
{
    public class TeamController : UserControl
    {
        readonly DropDown teamColorPicker;
        public TeamController()
        {
            InitializeComponent();
            uint index = 0;
            teamColorPicker = this.FindControl<DropDown>("TeamColorPicker");
            teamColorPicker.Items = ColorItem.Items;
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}
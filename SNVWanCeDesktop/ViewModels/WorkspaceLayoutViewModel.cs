using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WanCeDesktopApp.Common.DAO;

namespace WanCeDesktopApp.ViewModels
{
    public class WorkspaceLayoutViewModel
    {
        public ObservableCollection<LayoutInfo> LayoutInfos { get; set; }
        public WorkspaceLayoutViewModel()
        {
            LayoutInfos = new ObservableCollection<LayoutInfo>();
            LayoutInfos.Add(new LayoutInfo() { Id = 0, Type = "ChartLine" });
            LayoutInfos.Add(new LayoutInfo() { Id = 1, Type = "ChartBoxOutline" });
            LayoutInfos.Add(new LayoutInfo() { Id = 2, Type = "ClipboardEditOutline" });
            LayoutInfos.Add(new LayoutInfo() { Id = 3, Type = "FormatAlignCenter" });
            LayoutInfos.Add(new LayoutInfo() { Id = 4, Type = "Magnify" });
            LayoutInfos.Add(new LayoutInfo() { Id = 0, Type = "ChartLine" });
            LayoutInfos.Add(new LayoutInfo() { Id = 1, Type = "ChartBoxOutline" });
            LayoutInfos.Add(new LayoutInfo() { Id = 2, Type = "ClipboardEditOutline" });
            LayoutInfos.Add(new LayoutInfo() { Id = 3, Type = "FormatAlignCenter" });
            LayoutInfos.Add(new LayoutInfo() { Id = 4, Type = "Magnify" });
            LayoutInfos.Add(new LayoutInfo() { Id = 0, Type = "ChartLine" });
            LayoutInfos.Add(new LayoutInfo() { Id = 1, Type = "ChartBoxOutline" });
            LayoutInfos.Add(new LayoutInfo() { Id = 2, Type = "ClipboardEditOutline" });
            LayoutInfos.Add(new LayoutInfo() { Id = 3, Type = "FormatAlignCenter" });
            LayoutInfos.Add(new LayoutInfo() { Id = 4, Type = "Magnify" });
            LayoutInfos.Add(new LayoutInfo() { Id = 0, Type = "ChartLine" });
            LayoutInfos.Add(new LayoutInfo() { Id = 1, Type = "ChartBoxOutline" });
            LayoutInfos.Add(new LayoutInfo() { Id = 2, Type = "ClipboardEditOutline" });
            LayoutInfos.Add(new LayoutInfo() { Id = 3, Type = "FormatAlignCenter" });
            LayoutInfos.Add(new LayoutInfo() { Id = 4, Type = "Magnify" });
            LayoutInfos.Add(new LayoutInfo() { Id = 0, Type = "ChartLine" });
            LayoutInfos.Add(new LayoutInfo() { Id = 1, Type = "ChartBoxOutline" });
            LayoutInfos.Add(new LayoutInfo() { Id = 2, Type = "ClipboardEditOutline" });
            LayoutInfos.Add(new LayoutInfo() { Id = 3, Type = "FormatAlignCenter" });
            LayoutInfos.Add(new LayoutInfo() { Id = 4, Type = "Magnify" });
            LayoutInfos.Add(new LayoutInfo() { Id = 5, Type = "ChartLine" });
        }
    }
}

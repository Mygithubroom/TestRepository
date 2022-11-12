using MaterialDesignThemes.Wpf;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using WanCeDesktopApp.Common.Enum;

namespace WanCeDesktopApp.Common
{
    internal class ExtPackIcon : Control
    {
        private static readonly Lazy<
            IDictionary<ExtPackIconKind, string>
        > _dataIndex = new(ExtPackIconDataFactory.Create);

        static ExtPackIcon()
        {
            DefaultStyleKeyProperty.OverrideMetadata(
                typeof(ExtPackIcon),
                new FrameworkPropertyMetadata(typeof(ExtPackIcon))
            );
        }

        public static readonly DependencyProperty KindProperty =
            DependencyProperty.Register(
                nameof(Kind),
                typeof(ExtPackIconKind),
                typeof(ExtPackIcon),
                new PropertyMetadata(
                    default(ExtPackIconKind),
                    KindPropertyChangedCallback
                )
            );

        private static void KindPropertyChangedCallback(
            DependencyObject dependencyObject,
            DependencyPropertyChangedEventArgs dependencyPropertyChangedEventArgs
        ) => ((ExtPackIcon)dependencyObject).UpdateData();

        /// <summary>
        /// Gets or sets the icon to display.
        /// </summary>
        public ExtPackIconKind Kind
        {
            get => (ExtPackIconKind)GetValue(KindProperty);
            set => SetValue(KindProperty, value);
        }

        private static readonly DependencyPropertyKey DataPropertyKey =
            DependencyProperty.RegisterReadOnly(
                nameof(Data),
                typeof(string),
                typeof(ExtPackIcon),
                new PropertyMetadata("")
            );

        // ReSharper disable once StaticMemberInGenericType
        public static readonly DependencyProperty DataProperty =
            DataPropertyKey.DependencyProperty;

        /// <summary>
        /// Gets the icon path data for the current <see cref="Kind"/>.
        /// </summary>
        [TypeConverter(typeof(GeometryConverter))]
        public string? Data
        {
            get => (string?)GetValue(DataProperty);
            private set => SetValue(DataPropertyKey, value);
        }

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            UpdateData();
        }

        private void UpdateData()
        {
            string? data = null;
            _dataIndex.Value?.TryGetValue(Kind, out data);
            Data = data;
        }
    }
}

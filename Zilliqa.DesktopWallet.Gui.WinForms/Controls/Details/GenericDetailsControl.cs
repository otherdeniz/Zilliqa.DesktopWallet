﻿using System.ComponentModel;
using System.Reflection;
using Zilliqa.DesktopWallet.ApiClient;
using Zilliqa.DesktopWallet.Core;
using Zilliqa.DesktopWallet.Core.Data.Model;
using Zilliqa.DesktopWallet.Core.ViewModel.DataSource;
using Zilliqa.DesktopWallet.Core.ViewModel.ValueModel;
using Zilliqa.DesktopWallet.Gui.WinForms.Controls.Details.PropertyRow;
using Zilliqa.DesktopWallet.Gui.WinForms.Controls.GridView;
using Zilliqa.DesktopWallet.Gui.WinForms.Controls.Values;
using Zilliqa.DesktopWallet.ViewModelAttributes;

namespace Zilliqa.DesktopWallet.Gui.WinForms.Controls.Details
{
    public partial class GenericDetailsControl : DetailsBaseControl
    {
        private object? _viewModel;

        public GenericDetailsControl()
        {
            InitializeComponent();
        }

        public void LoadGenericViewModel(object viewModel)
        {
            _viewModel = viewModel;
            var viewModelType = viewModel.GetType();
            var propertiesHeight = 0;
            propertiesHeight += AddControls(panelProperties, _viewModel);
            propertiesHeight += AddHeader(viewModelType, viewModel);
            var hasTabs = AddTabs(viewModel);
            splitterTabs.Visible = hasTabs;
            panelTabs.Visible = hasTabs;
            panelProperties.Height = propertiesHeight;
        }

        private int AddHeader(Type viewModelType, object viewModelObject)
        {
            if (viewModelType.GetCustomAttribute(typeof(DetailsTitleAttribute)) 
                is DetailsTitleAttribute detailsTitleAttribute)
            {
                var titleText = viewModelType.GetProperty(detailsTitleAttribute.TitleProperty)
                    ?.GetValue(viewModelObject)?.ToString() ?? "";
                var subTitleText = viewModelType.GetProperty(detailsTitleAttribute.SubTitleProperty)
                    ?.GetValue(viewModelObject)?.ToString() ?? "";
                var imagePropertyValue = viewModelType.GetProperty(detailsTitleAttribute.Image48Property)
                    ?.GetValue(viewModelObject);
                var image48 = imagePropertyValue is IconModel iconModel 
                    ? iconModel.Icon48 
                    : imagePropertyValue as Image;
                var control = new TitleTextWithIcon48Panel
                {
                    Dock = DockStyle.Top
                };
                control.LoadValues(titleText, subTitleText, image48);
                panelProperties.Controls.Add(control);
                return control.Height;
            }

            return 0;
        }

        private bool AddTabs(object viewModelObject)
        {
            var hasTabs = false;
            var vmType = viewModelObject.GetType();
            foreach (var propertyInfo in vmType.GetProperties())
            {
                if (propertyInfo.GetCustomAttribute(typeof(DetailsChildObjectAttribute))
                    is DetailsChildObjectAttribute detailsChildObjectAttribute)
                {
                    var propertyValue = propertyInfo.GetValue(viewModelObject);
                    if (propertyValue != null)
                    {
                        var pageControl = ValueSelectionHelper.CreateDisplayControl(propertyValue);
                        AddTab(detailsChildObjectAttribute.DisplayName, pageControl);
                        hasTabs = true;
                    }
                }
            }
            foreach (var methodInfo in vmType.GetMethods())
            {
                if (methodInfo.GetCustomAttribute(typeof(DetailsGridViewAttribute))
                    is DetailsGridViewAttribute detailsGridViewAttribute)
                {
                    var gridView = new GridViewControl();
                    var button = AddTab(detailsGridViewAttribute.DisplayName, gridView);
                    Task.Run(() =>
                    {
                        var dataSource = methodInfo.Invoke(viewModelObject, new object?[]{});
                        if (dataSource is IPageableDataSource pageableDataSource)
                        {
                            WinFormsSynchronisationContext.ExecuteSynchronized(() =>
                            {
                                button.Tag ??= button.Text;
                                button.Text = $"{button.Tag} ({pageableDataSource.RecordCount:#,##0})";
                                gridView.LoadData(pageableDataSource);
                            });
                        }
                    });
                    hasTabs = true;
                }

            }
            return hasTabs;
        }

        private ToolStripButton AddTab(string name, Control pageControl)
        {
            var isFirst = panelTabPages.Controls.Count == 0;
            pageControl.Dock = DockStyle.Fill;
            pageControl.Visible = false;
            panelTabPages.Controls.Add(pageControl);
            var button = new ToolStripButton
            {
                Text = name
            };
            button.Click += (sender, args) => TabButtonClick(button, pageControl);
            var seperator = new ToolStripSeparator();
            toolStripTabs.Items.Add(button);
            toolStripTabs.Items.Add(seperator);
            if (isFirst)
            {
                TabButtonClick(button, pageControl);
            }
            return button;
        }

        private void TabButtonClick(ToolStripButton button, Control tabPageControl)
        {
            foreach (var item in toolStripTabs.Items)
            {
                if (item is ToolStripButton itemButton)
                {
                    itemButton.Checked = false;
                    itemButton.Font = new Font(itemButton.Font, FontStyle.Regular);
                }
            }
            button.Checked = true;
            button.Font = new Font(button.Font, FontStyle.Bold);

            foreach (Control pageControl in panelTabPages.Controls)
            {
                pageControl.Visible = false;
            }
            tabPageControl.Visible = true;
        }

        private int AddControls(Control toPanel, object viewModelObject)
        {
            var height = 0;
            var vmType = viewModelObject.GetType();
            var vmBaseType = vmType.BaseType;
            foreach (var propertyInfo in vmType.GetProperties().Reverse())
            {
                var parentPropertyInfo = vmBaseType?.GetProperty(propertyInfo.Name);
                var propertyDisplayName = propertyInfo.Name;
                if ((propertyInfo.GetCustomAttribute(typeof(DisplayNameAttribute))
                     ?? parentPropertyInfo?.GetCustomAttribute(typeof(DisplayNameAttribute)))
                    is DisplayNameAttribute displayNameAttribute)
                {
                    propertyDisplayName = displayNameAttribute.DisplayName;
                }

                string? formatString = null;
                if ((propertyInfo.GetCustomAttribute(typeof(GridViewFormatAttribute))
                     ?? parentPropertyInfo?.GetCustomAttribute(typeof(GridViewFormatAttribute)))
                    is GridViewFormatAttribute gridViewFormatAttribute)
                {
                    formatString = gridViewFormatAttribute.Format;
                }

                var propertyValue = propertyInfo.GetValue(viewModelObject);

                if ((propertyInfo.GetCustomAttribute(typeof(DetailsPropertyAttribute))
                     ?? parentPropertyInfo?.GetCustomAttribute(typeof(DetailsPropertyAttribute)))
                    is DetailsPropertyAttribute detailsPropertyAttribute
                    && propertyValue != null)
                {
                    if (detailsPropertyAttribute.PropertyType == DetailsPropertyType.AutoDetect
                        || detailsPropertyAttribute.PropertyType == DetailsPropertyType.Text)
                    {
                        if (propertyValue is decimal decimalValue && formatString != null)
                        {
                            propertyValue = decimalValue.ToString(formatString);
                        }
                        else if (propertyValue is DateTime dateTimeValue && formatString != null)
                        {
                            propertyValue = dateTimeValue == DateTime.MinValue
                                ? "-"
                                : dateTimeValue.ToString(formatString);
                        }
                    }

                    var rowControl = CreateRowControl(propertyDisplayName, propertyValue, detailsPropertyAttribute);
                    if (rowControl != null)
                    {
                        rowControl.Dock = DockStyle.Top;
                        rowControl.Font = new Font(Font, FontStyle.Regular);
                        rowControl.NameMinWidth = 120;
                        toPanel.Controls.Add(rowControl);
                        height += rowControl.Height;
                    }
                }
                if ((propertyInfo.GetCustomAttribute(typeof(DetailsChildPropertiesAttribute))
                     ?? parentPropertyInfo?.GetCustomAttribute(typeof(DetailsChildPropertiesAttribute)))
                    is DetailsChildPropertiesAttribute detailsObjectAttribute 
                    && propertyValue != null)
                {
                    if (!string.IsNullOrEmpty(detailsObjectAttribute.GroupName))
                    {
                        var groupPanel = new GroupBox
                        {
                            Text = detailsObjectAttribute.GroupName,
                            Font = new Font(Font, FontStyle.Bold),
                            Dock = DockStyle.Top
                        };
                        var subHeight = 0;
                        subHeight += AddControls(groupPanel, propertyValue);
                        if (subHeight > 0)
                        {
                            groupPanel.Height = subHeight + 20;
                            toPanel.Controls.Add(groupPanel);
                            height += subHeight + 20;
                        }
                    }
                    else
                    {
                        height += AddControls(toPanel, propertyValue);
                    }
                }
            }

            return height;
        }

        private PropertyRowBase? CreateRowControl(string title, object value, DetailsPropertyAttribute detailsPropertyAttribute)
        {
            var propertyType = detailsPropertyAttribute.PropertyType;
            if (propertyType == DetailsPropertyType.AutoDetect)
            {
                if (value is AddressValue)
                {
                    propertyType = DetailsPropertyType.Address;
                }
                else if (value is string stringValue)
                {
                    propertyType = stringValue.StartsWith("http") 
                        ? DetailsPropertyType.Url 
                        : DetailsPropertyType.Text;
                }
            }

            switch (propertyType)
            {
                case DetailsPropertyType.Text:
                    var valueText = value.ToString();
                    if (!string.IsNullOrEmpty(valueText))
                    {
                        var textControl = new PropertyRowText();
                        textControl.LoadValue(title, valueText);
                        return textControl;
                    }
                    break;
                case DetailsPropertyType.Address:
                    if (value is AddressValue addressValue)
                    {
                        var textControl = new PropertyRowAddress();
                        textControl.LoadValue(title, addressValue);
                        return textControl;
                    }
                    if (value is Address address)
                    {
                        var textControl = new PropertyRowAddress();
                        textControl.LoadValue(title, address);
                        return textControl;
                    }
                    if (value is string addressString && !string.IsNullOrEmpty(addressString))
                    {
                        var textControl = new PropertyRowAddress();
                        textControl.LoadValue(title, addressString);
                        return textControl;
                    }
                    break;
                case DetailsPropertyType.TextList:
                    if (value is IEnumerable<string> stringEnumerable)
                    {
                        var stringArray = stringEnumerable.ToArray();
                        if (stringArray.Any())
                        {
                            var textControl = new PropertyRowTextList();
                            textControl.LoadValue(title, stringArray);
                            return textControl;
                        }
                    }
                    break;
                case DetailsPropertyType.AddressList:
                    if (value is IEnumerable<string> addressEnumerable)
                    {
                        var stringArray = addressEnumerable.ToArray();
                        if (stringArray.Any())
                        {
                            var textControl = new PropertyRowAddressList();
                            textControl.LoadValue(title, stringArray);
                            return textControl;
                        }
                    }
                    break;
                case DetailsPropertyType.Url:
                    if (!string.IsNullOrEmpty(value.ToString()))
                    {
                        var urlControl = new PropertyRowUrl();
                        urlControl.LoadValue(title, value.ToString() ?? "");
                        return urlControl;
                    }
                    break;

            }
            return null;
        }

    }
}

using System.ComponentModel;
using System.Reflection;
using Zilliqa.DesktopWallet.ApiClient;
using Zilliqa.DesktopWallet.Core.Data.Model;
using Zilliqa.DesktopWallet.Core.ViewModel.ValueModel;
using Zilliqa.DesktopWallet.Gui.WinForms.Controls.Details.PropertyRow;
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
                        rowControl.NameMinWidth = 100;
                        toPanel.Controls.Add(rowControl);
                        height += rowControl.Height;
                    }
                }
                if ((propertyInfo.GetCustomAttribute(typeof(DetailsObjectAttribute))
                     ?? parentPropertyInfo?.GetCustomAttribute(typeof(DetailsObjectAttribute)))
                    is DetailsObjectAttribute detailsObjectAttribute 
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

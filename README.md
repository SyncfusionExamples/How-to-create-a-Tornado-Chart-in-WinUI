# How to create a Tornado Chart in WinUI

This article explains how to create a tornado chart using the [Column chart](https://help.syncfusion.com/winui/cartesian-charts/column) in [WinUI charts](https://www.syncfusion.com/winui-controls/charts).

The tornado chart is a special type of bar chart, where the bars extended from the defined baseline, which is also used to compare the data among different types of data or categories. The bars in the tornado chart are horizontal; this chart is basically used to show the impact, such as how a condition will impact the outcome. 

You can achieve the tornado chart using [column charts](https://help.syncfusion.com/winui/cartesian-charts/column) by following the steps below:

### Step 1:
Create [ColumnSeries](https://help.syncfusion.com/cr/winui/Syncfusion.UI.Xaml.Charts.ColumnSeries.html) with binding of [ItemsSource](https://help.syncfusion.com/cr/winui/Syncfusion.UI.Xaml.Charts.ChartSeriesBase.html#Syncfusion_UI_Xaml_Charts_ChartSeriesBase_ItemsSource), [XBindingPath](https://help.syncfusion.com/cr/winui/Syncfusion.UI.Xaml.Charts.ChartSeriesBase.html#Syncfusion_UI_Xaml_Charts_ChartSeriesBase_XBindingPath), and [YBindingPath](https://help.syncfusion.com/cr/winui/Syncfusion.UI.Xaml.Charts.XyDataSeries.html?tabs=tabid-1#Syncfusion_UI_Xaml_Charts_XyDataSeries_YBindingPath) properties.

### Step 2:
Set the [SfCartesianChart](https://help.syncfusion.com/cr/winui/Syncfusion.UI.Xaml.Charts.SfCartesianChart.html) [IsTranposed](https://help.syncfusion.com/cr/winui/Syncfusion.UI.Xaml.Charts.SfCartesianChart.html#Syncfusion_UI_Xaml_Charts_SfCartesianChart_IsTransposed) and [EnableSideBySideSeriesPlacement](https://help.syncfusion.com/cr/winui/Syncfusion.UI.Xaml.Charts.SfCartesianChart.html#Syncfusion_UI_Xaml_Charts_SfCartesianChart_EnableSideBySideSeriesPlacement) property value as false to create columns as horizontal bar and to avoid segments arranged side by side.

### Step 3:
Display the model data values in the bar segment by setting the [ColumnSeries](https://help.syncfusion.com/cr/winui/Syncfusion.UI.Xaml.Charts.ColumnSeries.html) [ShowDataLabels](https://help.syncfusion.com/cr/winui/Syncfusion.UI.Xaml.Charts.DataMarkerSeries.html#Syncfusion_UI_Xaml_Charts_DataMarkerSeries_ShowDataLabels) property value as `true` and customize the data label by using the [CartesianDataLabelSettings](https://help.syncfusion.com/cr/winui/Syncfusion.UI.Xaml.Charts.CartesianDataLabelSettings.html) class [ContentTemplate](https://help.syncfusion.com/cr/winui/Syncfusion.UI.Xaml.Charts.ChartDataLabelSettings.html#Syncfusion_UI_Xaml_Charts_ChartDataLabelSettings_ContentTemplate) property as demonstrated in the code example below.

**[XAML]**
```
<chart:SfCartesianChart IsTransposed="True" EnableSideBySideSeriesPlacement="False">
    <chart:SfCartesianChart.Resources>
        <ResourceDictionary>
            <viewModel:ValueConverter x:Key="ValueConverter"/>
            <DataTemplate x:Key="dataLabelTemplate">
                <Grid>
                    <TextBlock Text="{Binding Converter={StaticResource ValueConverter}}" FontSize="12"/>
                </Grid>
            </DataTemplate>
        </ResourceDictionary>
    </chart:SfCartesianChart.Resources>
   …
    <chart:SfCartesianChart.Series>
        <chart:ColumnSeries  XBindingPath="Year" YBindingPath="Export"
                             ItemsSource="{Binding Data}" ShowDataLabels="True" Label="Export">
            <chart:ColumnSeries.DataLabelSettings>
                <chart:CartesianDataLabelSettings Position="Outer" 
                             ContentTemplate="{StaticResource dataLabelTemplate}"/>
            </chart:ColumnSeries.DataLabelSettings>
        </chart:ColumnSeries>
        <chart:ColumnSeries  XBindingPath="Year" YBindingPath="Import"
                             ItemsSource="{Binding Data}" ShowDataLabels="True" Label="Import">
            <chart:ColumnSeries.DataLabelSettings>
                <chart:CartesianDataLabelSettings Position="Outer" 
                             ContentTemplate="{StaticResource dataLabelTemplate}"/>
            </chart:ColumnSeries.DataLabelSettings>
        </chart:ColumnSeries>
    </chart:SfCartesianChart.Series>
</chart:SfCartesianChart>
```

### Step 4:
Using `IValueConverter`, we can customize the negative values into absolute values as per the code example below.

**[C#]**
```
public class ValueConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, string language)
    {
        //Change the negative values into absolute value.
        return Math.Abs(System.Convert.ToDouble(value));
    }

    public object ConvertBack(object value, Type targetType, object parameter, string language)
    {
        return value;
    }
}
```

### Step 5:
Similarly, we can customize the axis label using the [LabelTemplate](https://help.syncfusion.com/cr/winui/Syncfusion.UI.Xaml.Charts.ChartAxis.html#Syncfusion_UI_Xaml_Charts_ChartAxis_LabelTemplate) property of the axis and by using a converter to display absolute values as per the below code example.

**[XAML]**
```
<chart:SfCartesianChart.YAxes>
    <chart:NumericalAxis>
        <chart:NumericalAxis.LabelTemplate>
            <DataTemplate>
                <TextBlock Text="{Binding Content, Converter={StaticResource ValueConverter}}"/>
            </DataTemplate>
        </chart:NumericalAxis.LabelTemplate>
    </chart:NumericalAxis>
</chart:SfCartesianChart.YAxes>
```

## Output:

![WinUI Tornado Chart](https://user-images.githubusercontent.com/53489303/183808346-d19e7b46-0499-408e-ad69-9e4c20292652.png)

KB article - [How to create a Tornado Chart in WinUI (SfCartesianChart)?](https://www.syncfusion.com/kb/13591/how-to-create-a-tornado-chart-in-winuisfcartesianchart)

## See also

[How to create a Column Chart in WinUI?](https://www.syncfusion.com/kb/13539/how-to-create-a-column-chart-in-winui)

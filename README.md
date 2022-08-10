# How to create a Tornado Chart in WinUI

This article explains how to create a tornado chart using the Column chart in WinUI charts.

The tornado chart is a special type of bar chart, where the bars extended from the defined baseline, which is also used to compare the data among different types of data or categories. The bars in the tornado chart are horizontal and this chart is basically used to show the impact such as how a condition will impact the result on the outcome. 

You can achieve the tornado chart using column charts by following the below steps.

### Step 1:
Create ColumnSeries with binding of ItemsSource, XBindingPath, and YBindingPath properties.

### Step 2:
Set the SfCartesianChart IsTranposed and EnableSideBySideSeriesPlacement property value as false to create columns as horizontal bar and to avoid segments arrange in side by side.

### Step 3:
Display the model data values in the bar segment by setting the ColumnSeries ShowDataLabels property value as true and customize the data label by using the CartesianDataLabelSettings class ContentTemplate property as demonstrated in the below code example.

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
Using IValueConverter we can customize the negative values into absolute values as per below code snippet.

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

## Output:

![WinUI Tornado Chart](https://user-images.githubusercontent.com/53489303/183808346-d19e7b46-0499-408e-ad69-9e4c20292652.png)

## See also

[How to create a Column Chart in WinUI?](https://www.syncfusion.com/kb/13539/how-to-create-a-column-chart-in-winui)

# How to bind ViewModel data to Accordion in Xamarin.Forms (SfAccordion)

You can populate the Xamarin.Forms [Accordion](https://help.syncfusion.com/xamarin/accordion/getting-started?) from ViewModel by using [BindableLayout.ItemSource](https://help.syncfusion.com/xamarin/accordion/bindablelayout?) property.

You can also refer the following article.

https://www.syncfusion.com/kb/11404/how-to-bind-viewmodel-data-to-accordion-in-xamarin-forms-sfaccordion 

**C#**

Creating the **ViewModel** to populate the **Contacts** property.
``` c#
public class ViewModel : INotifyPropertyChanged
{
    public ObservableCollection<ContactInfo> Contacts { get; set; }
    public Command<object> TapCommand { get; set; }
 
    public ViewModel()
    {
        Contacts = new ObservableCollection<ContactInfo>();
        TapCommand = new Command<object>(OnTapped);
        Contacts.Add(new ContactInfo() { Type = "A", Contacts = new ObservableCollection<Contact>() { new Contact() { ContactName = "Adam" }, new Contact { ContactName = "Aaron" } } });
        Contacts.Add(new ContactInfo() { Type = "B", Contacts = new ObservableCollection<Contact>() { new Contact() { ContactName = "Bolt" }, new Contact { ContactName = "Bush" } } });
        Contacts.Add(new ContactInfo() { Type = "C", Contacts = new ObservableCollection<Contact>() { new Contact() { ContactName = "Clark" }, new Contact { ContactName = "Clara" } } });
    }
 
    public event PropertyChangedEventHandler PropertyChanged;
 
    public void OnPropertyChanged(string name)
    {
        if (this.PropertyChanged != null)
            this.PropertyChanged(this, new PropertyChangedEventArgs(name));
    }
}
```
**XAML**

Binding the **ViewModel** Contacts property to **ItemSource** for **Accordion**
``` xml
<ContentPage.BindingContext>
    <local:ViewModel/>
</ContentPage.BindingContext>
<ContentPage.Content>
    <StackLayout>
        <syncfusion:SfAccordion x:Name="Accordion" BindableLayout.ItemsSource="{Binding Contacts}" ExpandMode="SingleOrNone" >
            <BindableLayout.ItemTemplate>
                <DataTemplate>
                    <syncfusion:AccordionItem  >
                        <syncfusion:AccordionItem.Header >
                            <Grid HeightRequest="60">
                                <Label Text="{Binding Type}" VerticalTextAlignment="Center" HorizontalTextAlignment="Center"/>
                            </Grid>
                        </syncfusion:AccordionItem.Header>
                        <syncfusion:AccordionItem.Content>
                            <Grid x:Name="mainGrid" Padding="4" HeightRequest="135" >
                                <sflistview:SfListView AllowGroupExpandCollapse="True" IsScrollingEnabled="False" x:Name="listView" IsScrollBarVisible="False" AutoFitMode="DynamicHeight"
                                ItemSpacing="3" ItemsSource="{Binding Contacts}" >
                                    <sflistview:SfListView.ItemTemplate>
                                        <DataTemplate>
                                            <Grid HeightRequest="60" >
                                                <Label Text="{Binding ContactName}"/>
                                                <Grid.GestureRecognizers>
                                                    <TapGestureRecognizer Command="{Binding Path=BindingContext.TapCommand, Source={x:Reference Accordion}}" CommandParameter="{Binding .}" />
                                                </Grid.GestureRecognizers>
                                            </Grid>
                                        </DataTemplate>
                                    </sflistview:SfListView.ItemTemplate>
                                </sflistview:SfListView>
                            </Grid>
                        </syncfusion:AccordionItem.Content>
                    </syncfusion:AccordionItem>
                </DataTemplate>
            </BindableLayout.ItemTemplate>
        </syncfusion:SfAccordion>
    </StackLayout>
</ContentPage.Content>
```

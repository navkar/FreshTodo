## Xamarin App with navigation drawer menu using FreshMVVM library - Screenshots 
| Navigation Drawer | Flip | Swipe Deck |
| --- | --- | --- |
| ![Slider Menu](Screenshots/Capture-2.PNG?raw=true "Slider menu") | ![Slider Menu](Screenshots/Capture-3.PNG?raw=true) | ![Slider Menu](Screenshots/Capture-1.PNG?raw=true) |

## List of NUGETS used

This app uses the following NUGETS

* Acr.UserDialogs
* Ansuria.XFGloss
* PropertyChanged.Fody
* Com.Airbnb.Xamarin.Forms.Lottie
* Fusillade
* CardsView
* Polly
* FreshMvvm
* ModernHttpClient-updated
* Plugin.Connectivity
* Refit.HttpClientFactory
* Newtonsoft.Json
* Xam.Plugin.Connectivity


### Resources

* [Android Asset Studio](http://romannurik.github.io/AndroidAssetStudio/icons-launcher.htm)
* [Lottie Animation Files](https://www.lottiefiles.com)

### Android Toolbar 

#### How to change the status bar color?

**color.xml**

```xml
<?xml version="1.0" encoding="utf-8"?>
<resources>
    <color name="launcher_background">#FFFFFF</color>
    <color name="colorPrimary">#B06AB3</color>
    <color name="colorPrimaryDark">#303F9F</color>
    <color name="colorAccent">#FF4081</color>
</resources>
```

Use this 

```xml
<item name="android:statusBarColor">@color/colorPrimary</item>
```

OR

```xml
<item name="android:statusBarColor">@android:color/white</item>
```


#### Adding custom fonts in Android?

```xml
<StackLayout Padding="5">
    <Label Text="USER NAME" FontFamily="IndieFlower.ttf#Regular" FontSize="Medium" TextColor="White" />
    <Entry Text="{Binding Username}" WidthRequest="200"/>
    <Label Text="PASSWORD" FontFamily="IndieFlower.ttf#Regular" FontSize="Medium" TextColor="White" />
    <Entry Text="{Binding Password}" IsPassword="true" WidthRequest="200"/>
    <Button Text="Login" FontFamily="IndieFlower.ttf#Regular" Command="{Binding LoginCommand}" />
</StackLayout>
```

### Quick look at BaseViewModel

```csharp
   public class BaseViewModel : FreshMvvm.FreshBasePageModel
    {
        public IApiManager ApiManager;
        IApiService<ITaskToDoApi> todoApi = new ApiService<ITaskToDoApi>(Config.ApiUrl);
        public IUserDialogs PageDialog = null;

        public bool IsBusy { get; set; }
        public BaseViewModel(IUserDialogs dialogs)
        {
            ApiManager = new ApiManager(todoApi);
            PageDialog = dialogs;
        }

        public async Task RunSafe(Task task, bool ShowLoading = true, string loadingMessage = null)
        {
            try
            {
                if (IsBusy) return;
                Debug.WriteLine("Run Safe - begin try");
                IsBusy = true;
                if (ShowLoading) PageDialog.ShowLoading(loadingMessage ?? "Working");
                await task;
                Debug.WriteLine("Run Safe - end try");
            }
            catch (Exception e)
            {
                IsBusy = false;
                PageDialog.HideLoading();
                Debug.WriteLine(e.Message + e.StackTrace);
                await App.Current.MainPage.DisplayAlert("Error", "Check your internet connection", "OK");
            }
            finally
            {
                Debug.WriteLine("Run Safe - finally");
                IsBusy = false;
                if (ShowLoading) PageDialog.HideLoading();
            }
        }
    }
```

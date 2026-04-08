# UnityUI
Unity UI styles for WPF application.

This WPF style was inspired by Unity Engine Editor interface, firstly for developing external tools for Unity Editor tools.

> [!NOTE]
> This project is not *owned, sponsored nor endorsed* by Unity Software Inc.

# Installation
1. Install `craftersmine.Ui.Unity` NuGet package
   ```powershell
   Install-Package craftersmine.UI.Unity
   ```
2. Create `ResourceDictionary` in your `App.xaml`
   ```xaml
   <Application.Resources>
      <ResourceDictionary>
         <ResourceDictionary.MergedDictionaries>
            <ResourceDictionary Source="pack://application:,,,/craftersmine.UI.Unity;component/DarkTheme.xaml"/>
            <ResourceDictionary Source="pack://application:,,,/craftersmine.UI.Unity;component/UnityUI.xaml"/>
         </ResourceDictionary.MergedDictionaries>
      </ResourceDictionary>
   </Application.Resources>
   ```
> [!TIP]
> You can specify your custom accent color using
> ```xaml
> <Color x:Key="UnityUIAccentColor">#3A79BB</Color>
> ```
3. Use styles. To override window style, use `Style="{DynamicResource UnityWindowStyle}"`
   
   More info at project [📗 Wiki](https://github.com/craftersmine/Ui.Unity/wiki)

# Contributing
I'm always open for contributions to my projects. However, please look into [Contributing guidelines](https://github.com/craftersmine/Ui.Unity/blob/master/CONTRIBUTING.md) and [Code of Conduct](https://github.com/craftersmine/Ui.Unity/blob/master/CODE_OF_CONDUCT.md)

# Funding
If you like this library, you can donate me using `❤️ Sponsor` button at the top of the page or using links in `Sponsor this project` sidebar section. This keeps me motivated to continue to support my projects for everyone.

# Sample images
## Groups and Boxes
![Groups and boxes](https://github.com/craftersmine/UI.Unity/blob/master/Resources/Previews/Groups%20and%20Boxes.png?raw=true)
## Menus and Toolbars
![Menus and Toolbars](https://github.com/craftersmine/UI.Unity/blob/master/Resources/Previews/Menu%20and%20Toolbars.png?raw=true)
## Tabs and TabControls
![Tabs and TabControls](https://github.com/craftersmine/UI.Unity/blob/master/Resources/Previews/Tabs%20and%20TabControls.png?raw=true)
## Buttons and toggles
![Buttons and toggles](https://github.com/craftersmine/UI.Unity/blob/master/Resources/Previews/Buttons%20and%20Toggles.png?raw=true)
## Textboxes
![Textboxes](https://github.com/craftersmine/UI.Unity/blob/master/Resources/Previews/Textboxes.png?raw=true)
## Sliders and progressbars
![Sliders and ProgressBars](https://github.com/craftersmine/UI.Unity/blob/master/Resources/Previews/Sliders%20and%20ProgressBars.png?raw=true)
## Comboboxes and expanders
![Comboboxes and expanders](https://github.com/craftersmine/UI.Unity/blob/master/Resources/Previews/Comboboxes%20and%20expanders.png?raw=true)
## ScrollBar and ScrollViewer
![ScrollBar and ScrollViewer](https://github.com/craftersmine/UI.Unity/blob/master/Resources/Previews/Scrollbars%20and%20ScrollViewer.png?raw=true)
## ListViews and TreeViews
![ListViews and TreeViews](https://github.com/craftersmine/UI.Unity/blob/master/Resources/Previews/ListViews%20and%20TreeViews.png?raw=true)
## Custom ListBox
![Custom ListBox](https://github.com/craftersmine/UI.Unity/blob/master/Resources/Previews/Custom%20ListBoxes.png?raw=true)
## Other custom controls
![Other custom controls](https://github.com/craftersmine/UI.Unity/blob/master/Resources/Previews/Custom%20Controls.png?raw=true)

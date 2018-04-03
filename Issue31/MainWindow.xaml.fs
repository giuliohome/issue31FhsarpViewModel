namespace mvce

open MainViewModel
open FsXaml

type MainWindowBase = XAML<"MainWindow.xaml">


type MainWindow() =
    inherit MainWindowBase()

    override this.OnLoaded (_,_) =
        this.DataContext <- MainViewModel()


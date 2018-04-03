open System
open FsXaml
open mvce

type App = XAML<"App.xaml">

[<STAThread>]
[<EntryPoint>]
let main argv = 
    Wpf.installSynchronizationContext ()
    let mainWin = MainWindow()
    mainWin
    |> App().Run 
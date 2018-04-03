module MainViewModel

open ViewModule
open ViewModule.FSharp
open System.Collections.ObjectModel
open DB

type MainViewModel() as self = 
    inherit ViewModelBase()
    let newBookCmd = 
        self.Factory.CommandSyncChecked(
            (fun () -> self.Add2Recents (RecentFile("new","path"))), 
            (fun () -> true ), 
            [  ])
    let clearRecentsCmd = 
        self.Factory.CommandSyncChecked(
            (fun () -> self.ClearRecents()), 
            (fun () -> self.RecentsNotEmpty  ), 
            [ <@@ self.RecentsNotEmpty @@>])

    let recents = ObservableCollection<RecentFile>(getRecent())     

    do
        recents.CollectionChanged.Add  (fun _ -> self.RaisePropertyChanged(<@ self.RecentsNotEmpty @>))

    member x.Recents = recents 
    member x.Add2Recents r = x.Recents.Insert(0,r)
        
        
    member x.ClearRecents() = x.Recents.Clear()
    member x.RecentsNotEmpty = x.Recents.Count > 0
    
    member x.NewBookCmd = newBookCmd
    member x.ClearRecentsCmd = clearRecentsCmd
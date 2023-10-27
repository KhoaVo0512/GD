function SetupPuzzle() {
    PopupControlSetupPuzzle.Show();
}

function onCancelClickSetupPuzzle(s, e) {
    PopupControlSetupPuzzle.Hide();
}

function OnToolbarItemClick(s, e) {
    var index = gvPuzzle.GetFocusedRowIndex();
}

function OnGridFocusedRowChanged(s, e) {
    s.GetRowValues(s.GetFocusedRowIndex(), 'ID;Suggest', OnGetRowValues);
}

function OnGetRowValues(values) {
    
}

function CFOnBeginCallBack(s, e) {
   
}

function CFOnEndCallBack(s, e) {
   
}

function CFInitGridview(s, e) {
    gvPuzzle.PerformCallback({});
}

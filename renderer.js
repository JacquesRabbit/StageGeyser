const contentElement = document.getElementById('content')
const fileOpen = "";

window.electronAPI.openFile((_event, value) => {
    contentElement.innerHTML = value
    updateWindow
})
function updateWindow() {
    if(fileOpen = "") {
        contentElement.innerHTML = "<button onclick='closeWindow()'>Open a File</button>"
    }
}
function closeWindow() {
    contentElement.innerHTML = ""
    updateWindow
}
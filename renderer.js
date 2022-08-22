const filePathElement = document.getElementById('filePath')

window.electronAPI.openFile((_event, value) => {
    filePathElement.innerText = value
})

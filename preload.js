const { contextBridge, ipcRenderer} = require('electron')

contextBridge.exposeInMainWorld('electronAPI', {
  openFile: (text) => ipcRenderer.on('open-file', text),
  closeFile: () => ipcRenderer.on("close-file"),
})
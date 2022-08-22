const { contextBridge, ipcRenderer} = require('electron')

contextBridge.exposeInMainWorld('electronAPI', {
  openFile: (text) => ipcRenderer.on('update-counter', text)
})
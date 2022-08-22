//Declare dependencies
const {app, BrowserWindow, ipcMain, dialog, Menu, MenuItem} = require('electron')
const path = require('path')
const fs = require("fs")
//Declare the window creating function
var window
function createWindow () {
  const mainWindow = new BrowserWindow({
    width: 800,
    height: 600,
    webPreferences: {
      preload: path.join(__dirname, 'preload.js')
    }
  })
  mainWindow.loadFile('index.html')
  window = mainWindow
}
//Create the main window when the app is ready
app.whenReady().then(() => {
  createWindow()
  app.on('activate', function () {
    //Open main window if app is activated without any windows open
    if (BrowserWindow.getAllWindows().length === 0) createWindow()
  })
})
//App qill not close when all windows close on MacOS
app.on('window-all-closed', function () {
  if (process.platform !== 'darwin') app.quit()
})
//
const menu = Menu.buildFromTemplate([
    {
      label: app.name,
      submenu: [
      {
        click: async () => {
            let {canceled, filePaths} = await dialog.showOpenDialog()
            if(canceled) {
                return
            } else {
                let output = fs.readFileSync(filePaths[0])
                return output
            }

            window.webContents.send("openFile", fs.readFileSync)
        },
        label: 'Open',
      },
      ]
    }
])
Menu.setApplicationMenu(menu)
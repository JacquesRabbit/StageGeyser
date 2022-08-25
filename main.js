//Declare dependencies
const {app, BrowserWindow, ipcMain, dialog, Menu} = require('electron')
const path = require('path')
const fs = require("fs")
const { Fountain } = require('fountain-js')
const fountain = new Fountain
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
                let fileHTML = fountain.parse(fs.readFileSync(filePaths[0], {
                  encoding: "ascii"
                })).html
                output = fileHTML.script

            window.webContents.send("open-file", output)
            }
        },
        label: 'Open',
      },
      {
        click: async () => {
          window.webContents.send("close-file")
      },
      label: 'Close',
      }
      ]
    }
])
Menu.setApplicationMenu(menu)
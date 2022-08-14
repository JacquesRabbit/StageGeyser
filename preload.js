window.addEventListener('DOMContentLoaded', () => {
    const replaceText = (dep, selector, text) => {
      const element = document.getElementById(selector)
      if (element) element.innerText = (dep + " " + text)
    }
  
    for (const dependency of ['Chrome', 'Node', 'Electron']) {
      replaceText(dependency, `${dependency.toLowerCase()}-version`, process.versions[dependency.toLowerCase()])
    }
  })

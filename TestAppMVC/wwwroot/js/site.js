document.querySelector("#dark-mode-toggle").addEventListener("click", function () {
    const htmlElement = document.documentElement;

    if (htmlElement.getAttribute("data-theme") === "light") {
        htmlElement.setAttribute("data-theme", "dark");
    } else {
        htmlElement.setAttribute("data-theme", "light");
    }
});
// document.querySelector connects to id dark-mode-toggle
// addEventLister listener for a click-event.
//gets the html element to be able to modify the attribut, it saves it in a const called htmlElement
//if the html has a attribute called data-theme and it is set to dark, then it will set data-theme to light
//if its not dark it will set it to dark:
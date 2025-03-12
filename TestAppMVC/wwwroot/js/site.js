document.querySelector("#mini-menu-dark-mode-toggle").addEventListener("click", function () {
    const htmlElement = document.documentElement;

    if (htmlElement.getAttribute("data-theme") === "dark") {
        htmlElement.setAttribute("data-theme", "light");
    } else {
        htmlElement.setAttribute("data-theme", "dark");
    }
});
// document.querySelector connects to id dark-mode-toggle
// addEventLister listener for a click-event.
//gets the html element to be able to modify the attribut, it saves it in a const called htmlElement
//if the html has a attribute called data-theme and it is set to dark, then it will set data-theme to light
//if its not dark it will set it to dark:



const miniMenuCard = document.querySelector(".mini-menu-card");//Selects the mini menu card element from the HTML
const menuTriggers = document.querySelectorAll(".menu-trigger");// when using several triggers like gear and avatar. selects all element with that class

//iterates through all menu-triggers and adds click even listener to each
menuTriggers.forEach(trigger => {
    trigger.addEventListener("click", function (event) {//added event and stop propagation to be able to get the menu to show. could also use "&& !event.target.closest(".menu-trigger")" on line 30 after target
        event.stopPropagation();
        miniMenuCard.classList.toggle("show"); // toggles between the show and ''
    });
});

document.addEventListener("click", function (event) {//event is an object that contains info of the click, like what element was clicked on
    if (!miniMenuCard.contains(event.target)) {
        miniMenuCard.classList.remove("show"); // if I click outside the menu it will remove show
    }
});
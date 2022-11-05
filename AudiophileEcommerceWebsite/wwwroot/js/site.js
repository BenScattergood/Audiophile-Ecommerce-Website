
const app = {
    hamburger: document.querySelector(".hamburger"),
    navFilter: document.querySelector(".nav__filter"),
    navMenu: document.querySelector(".navbar__menu"),
    body: document.querySelector(".body"),
}

app.hamburger.addEventListener("click", function() {
    app.navFilter.classList.toggle("hidden");
    app.navMenu.classList.toggle("hidden");
    app.body.classList.toggle("overflow-y-hidden");
})
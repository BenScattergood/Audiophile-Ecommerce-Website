
const app = {
    hamburger: document.querySelector(".hamburger"),
    navFilter: document.querySelector(".nav__filter"),
    navMenu: document.querySelector(".navbar__menu"),
}

app.hamburger.addEventListener("click", function() {
    app.navFilter.classList.toggle("hidden");
    app.navMenu.classList.toggle("hidden");
})

const app = {
    hamburger: document.querySelector(".hamburger"),
    navFilter: document.querySelector(".nav__filter"),
    navMenu: document.querySelector(".navbar__menu"),
    body: document.querySelector(".body"),
    ShoppingBasketSummary: document.querySelector("#ShoppingBasketSummary"),
    AddToCart: document.querySelector("#add-to-cart"),
    productName: document.querySelector("#product-name"),
    incrementerValue: document.querySelector("#incrementer-value"),
}

app.hamburger.addEventListener("click", function () {
    app.navFilter.classList.toggle("hidden");
    app.navMenu.classList.toggle("hidden");
    app.body.classList.toggle("overflow-y-hidden");
    app.body.classList.toggle("overflow-x-hidden");
});

app.AddToCart.addEventListener("click", function () {
    AjaxShoppingBasketRefresh();
})

function AjaxShoppingBasketRefresh() {
    console.log("inside");

    $.ajax({
        url: "/ShoppingBasket/AddToShoppingBasket",
        type: "Get",
        data: {
            pieName: app.productName.textContent,
            quantity: app.incrementerValue.textContent
        },
        success: function (response) {
            app.ShoppingBasketSummary.innerHTML = response;
            console.log("back");
        },
        error: function (response) {
            console.log(response);
            console.log("error");
        },
        failure: function (response) {
            console.log(response);
            console.log("failure");
        }
    })
}

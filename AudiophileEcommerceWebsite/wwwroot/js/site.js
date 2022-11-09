const app = {
    hamburger: document.querySelector(".hamburger"),
    navFilter: document.querySelector(".nav__filter"),
    navMenu: document.querySelector(".navbar__menu"),
    body: document.querySelector(".body"),
    ShoppingBasketSummary: document.querySelector("#ShoppingBasketSummary"),
    AddToCart: document.querySelector("#add-to-cart"),
    productName: document.querySelector("#product-name"),
    incrementerValue: document.querySelector("#incrementer-value"),
    RemoveAllBasket: document.querySelector("#clear-basket"),
    cartIcon: document.querySelector("#shopping-cart-icon"),
}

const incrementer = {
    productIncrement: document.querySelector("#product-increment"),
    productDecrement: document.querySelector("#product-decrement"),
    productIncrementerValue: document.querySelector("#product-incrementer-value"),
    BasketIncrements: document.querySelectorAll(".basket-increment"),
    BasketDecrements: document.querySelectorAll(".basket-decrement"),
    BasketIncrementerValues: document.querySelectorAll(".basket-incrementer-value"),
}


//IncrementerProduct
function CurrentQuantityToNum() {
    return Math.floor(incrementer.productIncrementerValue.textContent);
}

//incrementerbasket

document.addEventListener('click', function (e) {
    if (event.target.classList.contains('basket-increment')) {
        const pieName = event.target.parentElement
            .parentElement.children[1].children[0]
            .textContent;

        AjaxShoppingBasketRefresh(1, pieName);
    }

    if (event.target.classList.contains('basket-decrement')) {
        const pieName = event.target.parentElement
            .parentElement.children[1].children[0]
            .textContent;

        AjaxShoppingBasketRefresh(-1, pieName);
    }

    if (event.target.id == 'product-increment') {
        var currentQuantity = CurrentQuantityToNum();

        if (currentQuantity == 10) {
            return;
        }
        currentQuantity++;
        incrementer.productIncrementerValue.textContent = currentQuantity;

    }
    if (event.target.id == 'product-decrement') {
        var currentQuantity = CurrentQuantityToNum();

        if (currentQuantity == 1) {
            return;
        }
        currentQuantity--;
        incrementer.productIncrementerValue.textContent = currentQuantity;
    }

    if (event.target.id == "add-to-cart") {
        AjaxShoppingBasketRefresh(
            incrementer.productIncrementerValue.textContent,
            app.productName.textContent);
        ToggleBasket();
        return;
    }

    if (event.target.id == "shopping-cart-icon" &&
        app.navMenu.classList.contains("hidden")) {
        ToggleBasket();
        return;
    }

    //removeAll
    if (event.target.id == "clear-basket") {
        $.ajax({
            url: "/ShoppingBasket/ClearBasket",
            type: "Get",
            success: function (response) {
                app.ShoppingBasketSummary.innerHTML = response;
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
    else if (!app.ShoppingBasketSummary.contains(e.target) &&
        !app.ShoppingBasketSummary.classList.contains("invisible")) {
        HideBasket();
        return;
    }
})

//Ajax AddValueToBasket

function AjaxShoppingBasketRefresh(incrementValue, pieName) {
    $.ajax({
        url: "/ShoppingBasket/UpdateShoppingBasketItemHome",
        type: "Get",
        data: {
            pieName: pieName,
            quantity: incrementValue,
        },
        success: function (response) {
            app.ShoppingBasketSummary.innerHTML = response;
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

//Navbar menu

app.hamburger.addEventListener("click", function () {
    if (app.navMenu.classList.contains("hidden")) {
        //currently closed
        app.navMenu.classList.remove("hidden");
        CloseBasket();
        OpenPopup();
    }
    else {
        //currently open
        app.navMenu.classList.add("hidden");
        ClosePopup();
    }
    
});

function ToggleBasket() {
    if (app.ShoppingBasketSummary.classList.contains("invisible")) {
        //currently closed
        app.ShoppingBasketSummary.classList.remove("invisible");
        OpenPopup();
    }
    else {
        //currently open
        CloseBasket();
        ClosePopup();
    }
}

function HideBasket() {
    CloseBasket();
    ClosePopup();
}

function OpenPopup() {
    
    app.navFilter.classList.remove("hidden");
    app.body.classList.add("overflow-y-hidden");
    app.body.classList.remove("overflow-x-hidden");
}

function ClosePopup() {
    
    app.navFilter.classList.add("hidden");
    app.body.classList.remove("overflow-y-hidden");
    app.body.classList.add("overflow-x-hidden");
}

function CloseBasket() {
    app.ShoppingBasketSummary.classList.add("invisible");
}

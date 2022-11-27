const app = {
    hamburger: document.querySelector(".hamburger"),
    navFilter: document.querySelector(".nav__filter"),
    navFilterAll: document.querySelector(".nav__filter-all"),
    navMenu: document.querySelector(".navbar__menu"),
    body: document.querySelector(".body"),
    ShoppingBasketSummary: document.querySelector("#ShoppingBasketSummary"),
    AddToCart: document.querySelector("#add-to-cart"),
    productName: document.querySelector("#product-name"),
    incrementerValue: document.querySelector("#incrementer-value"),
    RemoveAllBasket: document.querySelector("#clear-basket"),
    cartIcon: document.querySelector("#shopping-cart-icon"),
    sectionEMoney: document.querySelector(".form__section__e-money"),
    sectionCash: document.querySelector(".form__section__cash"),
    radioDivEMoney: document.querySelector("#e-money"),
    radioDivCash: document.querySelector("#cash"),
    logoutPopup: document.querySelector(".LoginPartial__Logout-form"),
    userAvatar: document.querySelector(".nav__avatar-img"),
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

document.onwheel = function (e) {
    if (!app.ShoppingBasketSummary.contains(e.target) &&
        !app.ShoppingBasketSummary.classList.contains("invisible")) {
        HideBasket();
        return;
    }
}

document.addEventListener('click', function (e) {
    if (!app.ShoppingBasketSummary.contains(e.target) &&
        !app.ShoppingBasketSummary.classList.contains("invisible")) {
        HideBasket();
        return;
    }

    //avatar popup
    if (document.querySelector(".LoginPartial__Logout-form") != null) {
        if (!app.logoutPopup.contains(e.target) &&
            !app.logoutPopup.classList.contains("hidden")) {
            HideLogoutPopup();
            return;
        }
        if (app.userAvatar.contains(e.target) &&
            app.logoutPopup.classList.contains("hidden")) {
            app.logoutPopup.classList.toggle("hidden");
            return;
        }
    }
    //

    if (event.target.classList.contains('basket-increment')) {
        const productName = event.target.parentElement
            .parentElement.children[1].children[0]
            .textContent;

        AjaxShoppingBasketRefresh(1, productName);
    }

    if (event.target.classList.contains('basket-decrement')) {
        const productName = event.target.parentElement
            .parentElement.children[1].children[0]
            .textContent;

        AjaxShoppingBasketRefresh(-1, productName);
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
        window.scrollTo({ top: 0, behaviour: 'smooth' });
        ToggleBasket();
        return;
    }

    if (event.target.id == "shopping-cart-icon" &&
        app.navMenu.classList.contains("hidden")) {
        ToggleBasket();
        return;
    }

    if (event.target.id == "cash" || event.target.id == "cash-text") {        
        document.querySelector(".cash-radio").click();
        return;
    }

    if (event.target.id == "e-money" || event.target.id == "e-money-text") {
        document.querySelector(".e-money-radio").click();
        return;
    }

    if (event.target.classList.contains("cash-radio")) {
        app.sectionEMoney.classList.add("hidden");
        app.sectionCash.classList.remove("hidden");
        app.radioDivCash.classList.add("beige-border");
        app.radioDivEMoney.classList.remove("beige-border");
    }

    if (event.target.classList.contains("e-money-radio")) {
        app.sectionCash.classList.add("hidden");
        app.sectionEMoney.classList.remove("hidden");
        app.radioDivEMoney.classList.add("beige-border");
        app.radioDivCash.classList.remove("beige-border");
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
})

//Ajax AddValueToBasket

function AjaxShoppingBasketRefresh(incrementValue, productName) {
    $.ajax({
        url: "/ShoppingBasket/UpdateShoppingBasketItemHome",
        type: "Get",
        data: {
            productName: productName,
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
        app.navFilter.classList.remove("hidden");
        OpenPopup();
    }
    else {
        //currently open
        app.navMenu.classList.add("hidden");
        ClosePopup();
        app.navFilter.classList.add("hidden");
    }
    
});

//basket

function ToggleBasket() {
    if (app.ShoppingBasketSummary.classList.contains("invisible")) {
        //currently closed
        app.ShoppingBasketSummary.classList.remove("invisible");
        app.navFilterAll.classList.remove("hidden");
        OpenPopup();
    }
    else {
        //currently open
        HideBasket();
    }
}

function HideBasket() {
    CloseBasket();
    ClosePopup();
    app.navFilterAll.classList.add("hidden");
}

function OpenPopup() {
    
    app.body.classList.add("overflow-y-hidden");
    /*app.body.classList.remove("overflow-x-hidden");*/
}

function ClosePopup() {
    app.navFilterAll.classList.add("hidden");
    app.navFilter.classList.add("hidden");
    app.body.classList.remove("overflow-y-hidden");
    /*app.body.classList.add("overflow-x-hidden");*/
}

function CloseBasket() {
    app.ShoppingBasketSummary.classList.add("invisible");
}

//logout popup

//app.userAvatar.addEventListener("click", function () {
//    app.logoutPopup.classList.toggle("hidden");
//})

function ShowLogoutPopup() {
    app.logoutPopup.classList.remove("hidden");
}

function HideLogoutPopup() {
    app.logoutPopup.classList.add("hidden");
}
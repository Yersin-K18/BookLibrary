
window.addEventListener('load',
    function () {
        var addWishlistButtons = document.querySelectorAll("#tg-bestsellingbooksslider > div.owl-stage-outer > div > div > div > div > figure > a");

        addWishlistButtons.forEach(e => {
            var id = e.getAttribute("bookid");
            e.addEventListener("click", function (event) {
                fetch('/Wishlist/AddWishList/' + id, {
                    method: 'POST',
                    headers: {
                        'Content-Type': 'application/x-www-form-urlencoded; charset=UTF-8'
                    },
                    body: ''
                })
                    .then(function (response) {
                        if (response.ok) {
                            // Done
                            fetch('/Wishlist/NumberBookInWishList', {
                                method: 'POST',
                                headers: {
                                    'Content-Type': 'application/x-www-form-urlencoded; charset=UTF-8'
                                },
                                body: ''
                            }).then(response => {
                                response.text().then(data => {
                                    var number = document.querySelector("#tg-wishlisst > span.tg-themebadge");
                                    number.innerHTML = data;
                                })
                            })
                        } else {
                            // Xử lý lỗi nếu có
                        }
                    })
                    .catch(function (error) {
                        console.error(error);
                    });
            });
        });

        var wishlistButton = document.querySelector("#tg-header > div.tg-middlecontainer > div > div > div > div.tg-wishlistandcart > div.dropdown.tg-themedropdown.tg-wishlistdropdown");

        wishlistButton.addEventListener("click", function () {
            fetch('/Wishlist/Index', {
                method: 'POST',
                headers: {
                    'Content-Type': 'application/x-www-form-urlencoded; charset=UTF-8'
                },
                body: ''
            })
                .then(res => {
                    res.text().then(html => {
                        const parser = new DOMParser();
                        const newDocument = parser.parseFromString(html, 'text/html');
                        wishlistButton.innerHTML = newDocument.body.querySelector("div").innerHTML;
                    })
                })
        })
    }, false);
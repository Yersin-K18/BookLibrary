window.onload = () => {
    var bookPriceElement = document.querySelector(".tg-bookprice ins");
    var bookTitleElement = document.querySelector(".tg-booktitle h3 a");
    var btnElementElement = document.querySelector(".tg-priceandbtn .tg-btn");
    var bookWriterElement = document.querySelector(".tg-bookwriter a");
    var figureElement = document.querySelector("figure > img");


    fetch("/Featured/GetFeatured", {
        "headers": {
            "accept": "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,image/apng,*/*;q=0.8,application/signed-exchange;v=b3;q=0.7",
            "accept-language": "vi,en-US;q=0.9,en;q=0.8",
            "sec-ch-ua": "\"Chromium\";v=\"110\", \"Not A(Brand\";v=\"24\", \"Microsoft Edge\";v=\"110\"",
            "sec-ch-ua-mobile": "?0",
            "sec-ch-ua-platform": "\"Windows\"",
            "sec-fetch-dest": "document",
            "sec-fetch-mode": "navigate",
            "sec-fetch-site": "none",
            "sec-fetch-user": "?1",
            "upgrade-insecure-requests": "1"
        },
        "referrerPolicy": "strict-origin-when-cross-origin",
        "body": null,
        "method": "GET",
        "mode": "cors",
        "credentials": "omit"
    }).then(res => {
        res.text().then(html => {
            const parser = new DOMParser();
            const newDocument = parser.parseFromString(html, 'text/html');

            var id = newDocument.querySelector(".tg-bglight").getAttribute("book-id");
            var figureElementNew = newDocument.querySelector(".tg-featureditm figure img");
            var bookTitleElementNew = newDocument.querySelector(".tg-featureditm .tg-booktitle a");
            var bookPriceElementNew = newDocument.querySelector(".tg-featureditm .tg-bookprice ins");
            var bookWriterElementNew = newDocument.querySelector(".tg-bookwriter a");
            var btnElementNew = newDocument.querySelector(".tg-btn");

            figureElement.innerHTML = figureElementNew.innerHTML;
            bookPriceElement.innerHTML = bookPriceElementNew.innerHTML;
            bookTitleElement.innerHTML = bookTitleElementNew.innerHTML;
            bookWriterElement.innerHTML = bookWriterElementNew.innerHTML;
            btnElementElement.setAttribute("href", "/ShoppingCart/AddCart?BookID=" + id + "&strURL=" + window.location.href);
        });
    })
}

